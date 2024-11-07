using MediatR;

namespace GymScheduler.Application.Features.Events.Commands
{
    public class DeleteRequest : IRequest
    {
        public string Id { get; set; }

        public DeleteRequest()
        {
            Id = "";
        }
    }
}
