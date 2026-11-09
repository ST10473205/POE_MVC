using POE.Models;
using System.Collections.Generic;

namespace POE.Services
{
    public interface IRaceDayService
    {
        IEnumerable<EventModel> GetAllEvents();
        EventModel? GetEventById(int id);
        EventModel AddEvent(EventModel eventModel);
        UserModel? Authenticate(string username, string password);
    }
}