using GymScheduler.Domain.Models;
using MediatR;

namespace GymScheduler.Application.Features.Events.Queries
{
    public class GetByDateRequest : IRequest<List<Event>>
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}
