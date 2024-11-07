using GymScheduler.Domain.Models;
using System.Net.Http.Json;
using System.Text.Json;

namespace GymScheduler.Events.Client
{
    public class EventClient: IEventClient
    {
        private readonly HttpClient _client;

        public EventClient(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task CreateAsync(Event newEvent)
        {
            //using StringContent jsonContent = new(JsonSerializer.Serialize(newEvent), Encoding.UTF8, "application/json");

            using HttpResponseMessage response = await _client.PostAsJsonAsync("", newEvent);

            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync();
        }

        public async Task DeleteAsync(string id)
        {
            using HttpResponseMessage response = await _client.DeleteAsync(id);

            response.EnsureSuccessStatusCode();

            //var jsonResponse = await response.Content.ReadAsStringAsync();
        }

        public async Task<List<Event>> GetAsync(DateTime start, DateTime end)
        {
            var httpResponse = await _client.GetAsync($"daterange?start={start}&end={end}");

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot retrieve records");
            }

            var content = await httpResponse.Content.ReadAsStringAsync();

            if (string.IsNullOrWhiteSpace(content))
            {
                return new List<Event>();
            }

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var deserialized = JsonSerializer.Deserialize<List<Event>>(content, options);

            if (null == deserialized)
            {
                throw new Exception($"Could not deserialize content: {content}");
            }

            return deserialized;
        }

        public async Task UpdateAsync(Event existentEvent)
        {
            using HttpResponseMessage response = await _client.PutAsJsonAsync(existentEvent.Id, existentEvent);

            response.EnsureSuccessStatusCode();

            //var jsonResponse = await response.Content.ReadAsStringAsync();
        }
    }
}
