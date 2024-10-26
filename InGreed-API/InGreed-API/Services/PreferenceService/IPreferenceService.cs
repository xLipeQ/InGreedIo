using InGreed_API.Dtos.Requests;
using InGreed_API.Dtos.Results;
using InGreed_API.Models;

namespace InGreed_API.Services.PreferenceService
{
    public interface IPreferenceService
    {
        Task<ResultBase> AddPreference(PreferenceRequest request);
        Task<List<Preference>> GetPreference(MultiplePreferenceRequest request);
        Task<List<Preference>> GetUserPreference(int userId);
        Task<ResultBase> RemovePreference(PreferenceRequest request);
    }
}
