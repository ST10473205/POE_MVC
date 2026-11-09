using POE_MVC.Models;

namespace POE_MVC.Services
{
    public interface IRaceApiClient
    {
        Task<IEnumerable<EventViewModel>> GetEventsAsync();
        Task<EventViewModel?> GetEventByIdAsync(int id);
        Task<bool> AddEventAsync(EventViewModel model);
        Task<AuthResponseDto?> LoginAsync(LoginViewModel model);
        Task<bool> RegisterUserForEventAsync(CreateEnrolmentViewModel model, string username);

        // Add these three new declarations:
        Task<List<ParticipantResultDto>> GetParticipantResultsAsync(string username);
        Task<UserProfileDto?> GetUserProfileAsync(string username);
        Task<bool> UpdateUserProfileAsync(UserProfileDto model);
    }
}