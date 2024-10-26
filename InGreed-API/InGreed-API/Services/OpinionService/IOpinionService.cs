using InGreed_API.Dtos.Requests;
using InGreed_API.Dtos.Responses;
using InGreed_API.Dtos.Results;

namespace InGreed_API.Services.OpinionService
{
    public interface IOpinionService
    {
        Task<List<OpinionResponse>> GetOpinionsForProduct(int productId);
        Task<ResultBase> AddOpinion(OpinionRequest opinionRequest);
        Task<ResultBase> ModifyOpinion(OpinionRequest opinionRequest);
        Task<ResultBase> RemoveOpinion(DeleteOpinionRequest opinionRequest);
    }
}
