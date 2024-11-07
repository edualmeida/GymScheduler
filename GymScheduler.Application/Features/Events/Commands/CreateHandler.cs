using GymScheduler.Events.Client;
using MediatR;

namespace GymScheduler.Application.Features.Events.Commands
{
    public class CreateHandler : IRequestHandler<CreateRequest>
    {
        private readonly IEventClient _eventsClient;

        public CreateHandler(IEventClient eventsClient)
        {
            _eventsClient = eventsClient;
        }

        public Task Handle(CreateRequest request, CancellationToken cancellationToken)
        {
            return _eventsClient.CreateAsync(request);
        }
    }
}
