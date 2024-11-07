using GymScheduler.Domain.Models;
using MediatR;

namespace GymScheduler.Application.Features.Events.Commands
{
    public class UpdateRequest : Event, IRequest
    {
    }
}
