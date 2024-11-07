using GymScheduler.Domain.Models;
using GymScheduler.Events.Client;
using MediatR;

namespace GymScheduler.Application.Features.Events.Queries
{
    public class GetByDateHandler : IRequestHandler<GetByDateRequest, List<Event>>
    {
        private readonly IEventClient _eventsClient;

        public GetByDateHandler(IEventClient eventsClient)
        {
            _eventsClient = eventsClient;
        }

        public Task<List<Event>> Handle(GetByDateRequest request, CancellationToken cancellationToken)
        {
            return _eventsClient.GetAsync(request.Start, request.End);
        }
    }
}
