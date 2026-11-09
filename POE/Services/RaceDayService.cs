using POE.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace POE.Services
{
    public class RaceDayService : IRaceDayService
    {
        private static readonly List<EventModel> _events = new()
        {
            new EventModel 
                { Id = 1, Title = "City Marathon",
                Description = "Annual city run",  
                EventDate = DateTime.Now.AddDays(10), 
                Location = "Downtown", DistanceKm = 42.2 },

            new EventModel 
            { Id = 2, Title = "Coastal Trail",
                Description = "Scenic beach run",
                EventDate = DateTime.Now.AddDays(20), 
                Location = "Beachfront", DistanceKm = 15.0,
                ImageUrl= "/images/coastal.webp"}
        };
        
        private static readonly List<UserModel> _users = new()
        {
            new UserModel { Id = 1, Username = "organiser1", PasswordHash = "password123", Role = "Organiser" },
            new UserModel { Id = 2, Username = "participant1", PasswordHash = "password123", Role = "Participant" }
        };

        public IEnumerable<EventModel> GetAllEvents() => _events;

        // Allow nullable return if ID is not found
        public EventModel? GetEventById(int id) => _events.FirstOrDefault(e => e.Id == id);

        public EventModel AddEvent(EventModel eventModel)
        {
            // Simplified count check to address the CA1860 performance suggestion
            eventModel.Id = _events.Count > 0 ? _events.Max(e => e.Id) + 1 : 1;
            _events.Add(eventModel);
            return eventModel;
        }

        // Allow nullable return if authentication fails
        public UserModel? Authenticate(string username, string password)
        {
            return _users.FirstOrDefault(u => u.Username == username && u.PasswordHash == password);
        }
    }
}