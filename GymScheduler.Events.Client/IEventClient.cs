using GymScheduler.Domain.Models;

namespace GymScheduler.Events.Client
{
    public interface IEventClient
    {
        public Task<List<Event>> GetAsync(DateTime start, DateTime end);
        public Task CreateAsync(Event newEvent);
        public Task UpdateAsync(Event existentEvent);
        public Task DeleteAsync(string id);
    }
}
