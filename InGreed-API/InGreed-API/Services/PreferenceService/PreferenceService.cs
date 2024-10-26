using InGreed_API.DataContext;
using InGreed_API.Dtos.Requests;
using InGreed_API.Dtos.Results;
using InGreed_API.Enums;
using InGreed_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace InGreed_API.Services.PreferenceService
{
    public class PreferenceService(
        InGreedDataContext context) : IPreferenceService
    {
        public async Task<ResultBase> AddPreference(PreferenceRequest request)
        {
            Preference? p = await context.Preferences.SingleOrDefaultAsync(p => p.UserId == request.UserId && p.IngredientId == request.IngredientId);
            if (p != null && p.PreferenceType != request.Type)
            {
                p.PreferenceType = (PreferenceEnum)request.Type!;
                await context.SaveChangesAsync();
                return new ResultBase(true);
            }

            Preference pref = new Preference
            {
                PreferenceType = (PreferenceEnum)request.Type!,
                UserId = request.UserId,
                IngredientId = request.IngredientId
            };

            await context.Preferences.AddAsync(pref);
            await context.SaveChangesAsync();

            return new ResultBase(true);
        }

        public async Task<List<Preference>> GetPreference(MultiplePreferenceRequest request)
        {
            var preferenceList = await context.Preferences.Where(p => p.UserId == request.UserId && request.IngredientIds.Contains(p.IngredientId)).ToListAsync();
            return preferenceList;
        }

        public async Task<List<Preference>> GetUserPreference(int userId)
        {
            var preferenceList = await context.Preferences.Where(p => p.UserId == userId).ToListAsync();
            return preferenceList;
        }
        public async Task<ResultBase> RemovePreference(PreferenceRequest request)
        {
            Preference? p = await context.Preferences.SingleOrDefaultAsync(p => p.UserId == request.UserId && p.IngredientId == request.IngredientId);
            if(p == null)
                return new ResultBase(false); 

            context.Preferences.Remove(p);
            await context.SaveChangesAsync();

            return new ResultBase(true);
        }
    }
}
