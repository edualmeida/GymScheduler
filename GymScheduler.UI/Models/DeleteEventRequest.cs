namespace GymScheduler.Models
{
    public class DeleteEventRequest
    {
        public string EventId { get; set; }

        public DeleteEventRequest()
        {
            EventId = "";
        }
    }
}
