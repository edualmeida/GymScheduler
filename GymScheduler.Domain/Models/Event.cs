namespace GymScheduler.Domain.Models
{
    public class Event
    {
        public string Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }
        public bool AllDay { get; set; }

        public Event()
        {
            Id = "";
        }
    }
}
