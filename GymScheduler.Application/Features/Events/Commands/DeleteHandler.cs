using GymScheduler.Events.Client;
using MediatR;

namespace GymScheduler.Application.Features.Events.Commands
{
    public class DeleteHandler : IRequestHandler<DeleteRequest>
    {
        private readonly IEventClient _eventsClient;

        public DeleteHandler(IEventClient eventsClient)
        {
            _eventsClient = eventsClient;
        }

        public Task Handle(DeleteRequest request, CancellationToken cancellationToken)
        {
            return _eventsClient.DeleteAsync(request.Id);
        }
    }
}
