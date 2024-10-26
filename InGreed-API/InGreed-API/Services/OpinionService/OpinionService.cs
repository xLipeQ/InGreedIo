using InGreed_API.DataContext;
using InGreed_API.Dtos.Requests;
using InGreed_API.Dtos.Responses;
using InGreed_API.Dtos.Results;
using InGreed_API.Models;
using Microsoft.EntityFrameworkCore;

namespace InGreed_API.Services.OpinionService
{
    public class OpinionService(
        InGreedDataContext inGreedDataContext
        ): IOpinionService
    {
        public static int MinRating = 1;
        public static int MaxRating = 5;

        public async Task<List<OpinionResponse>> GetOpinionsForProduct(int productId)
        {
            var opinions = await inGreedDataContext.Opinions
                .Include(o => o.User)
                .Where(o => o.ProductId == productId)
                .Select(o => new OpinionResponse { UserId = o.User.Id, Content = o.Comment, Rating = o.Rating, Username = o.User.Username })
                .ToListAsync();

            return opinions;
        }
        public async Task<ResultBase> AddOpinion(OpinionRequest opinionRequest)
        {
            var opinion = await inGreedDataContext.Opinions
                .FirstOrDefaultAsync(o => o.ProductId == opinionRequest.ProductId && o.UserId == opinionRequest.UserId);

            if (opinion != null)
                return new ResultBase(false, "Opinion already exists");

            if (opinionRequest.Rating < MinRating || opinionRequest.Rating > MaxRating)
                return new ResultBase(false, $"Rating in not in range ({MinRating},{MaxRating})");

            opinion = new Opinion()
            {
                ProductId = opinionRequest.ProductId,
                UserId = opinionRequest.UserId,
                Comment = opinionRequest.Comment,
                Rating = opinionRequest.Rating
            };

            await inGreedDataContext.Opinions.AddAsync(opinion);
            await inGreedDataContext.SaveChangesAsync();

            return new ResultBase(true);
        }

        public async Task<ResultBase> ModifyOpinion(OpinionRequest opinionRequest)
        {
            var opinion = await inGreedDataContext.Opinions
                .FirstOrDefaultAsync(o => o.ProductId == opinionRequest.ProductId && o.UserId == opinionRequest.UserId);

            if (opinion == null)
                return new ResultBase(false, "This opinion doesn't exist");

            if (opinionRequest.Rating < MinRating || opinionRequest.Rating > MaxRating)
                return new ResultBase(false, $"Rating in not in range ({MinRating},{MaxRating})");

            opinion.Comment = opinionRequest.Comment;
            opinion.Rating = opinionRequest.Rating;

            await inGreedDataContext.SaveChangesAsync();

            return new ResultBase(true);
        }

        public async Task<ResultBase> RemoveOpinion(DeleteOpinionRequest opinionRequest)
        {
            var opinion = await inGreedDataContext.Opinions
                .FirstOrDefaultAsync(o => o.ProductId == opinionRequest.ProductId && o.UserId == opinionRequest.UserId);

            if (opinion == null)
                return new ResultBase(false);

            inGreedDataContext.Opinions.Remove(opinion);
            await inGreedDataContext.SaveChangesAsync();

            return new ResultBase(true);
        }
    }
}
