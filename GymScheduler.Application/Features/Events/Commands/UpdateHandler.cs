using GymScheduler.Events.Client;
using MediatR;

namespace GymScheduler.Application.Features.Events.Commands
{
    public class UpdateHandler : IRequestHandler<UpdateRequest>
    {
        private readonly IEventClient _eventsClient;

        public UpdateHandler(IEventClient eventsClient)
        {
            _eventsClient = eventsClient;
        }

        public Task Handle(UpdateRequest request, CancellationToken cancellationToken)
        {
            return _eventsClient.UpdateAsync(request);
        }
    }
}
