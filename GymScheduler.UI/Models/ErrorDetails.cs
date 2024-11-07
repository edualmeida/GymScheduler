using System.Text.Json;

namespace GymScheduler.UI.Models
{
    public class ErrorDetails
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }

        public ErrorDetails()
        {
            Message = "";
        }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
