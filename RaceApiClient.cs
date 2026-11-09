using System.Net.Http.Json;
using POE_MVC.Models;

namespace POE_MVC.Services
{
    public class RaceApiClient(IHttpClientFactory httpClientFactory) : IRaceApiClient
    {
        private readonly HttpClient _httpClient = httpClientFactory.CreateClient("RaceDayAPI");

        public async Task<IEnumerable<EventViewModel>> GetEventsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<EventViewModel>>("api/events") ?? [];
        }

        public async Task<EventViewModel?> GetEventByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<EventViewModel>($"api/events/{id}");
        }

        public async Task<bool> AddEventAsync(EventViewModel model)
        {
            var response = await _httpClient.PostAsJsonAsync("api/events", model);
            return response.IsSuccessStatusCode;
        }

        public async Task<AuthResponseDto?> LoginAsync(LoginViewModel model)
        {
            var response = await _httpClient.PostAsJsonAsync("api/auth/login", model);
            if (!response.IsSuccessStatusCode) return null;
            return await response.Content.ReadFromJsonAsync<AuthResponseDto>();
        }

        public async Task<bool> RegisterUserForEventAsync(CreateEnrolmentViewModel model, string username)
        {
            var enrolmentPayload = new
            {
                Username = username,
                EventId = model.EventId,
                CategoryName = model.CategoryName,
                EmergencyContact = model.EmergencyContact
            };

            var response = await _httpClient.PostAsJsonAsync("api/events/enrol", enrolmentPayload);
            return response.IsSuccessStatusCode;
        }
        public async Task<List<ParticipantResultDto>> GetParticipantResultsAsync(string username)
        {
            return await _httpClient.GetFromJsonAsync<List<ParticipantResultDto>>($"api/participants/{Uri.EscapeDataString(username)}/results") ?? [];
        }

        public async Task<UserProfileDto?> GetUserProfileAsync(string username)
        {
            return await _httpClient.GetFromJsonAsync<UserProfileDto>($"api/participants/{Uri.EscapeDataString(username)}");
        }

        public async Task<bool> UpdateUserProfileAsync(UserProfileDto model)
        {
            var response = await _httpClient.PutAsJsonAsync("api/participants/update", model);
            return response.IsSuccessStatusCode;
        }
    }
}