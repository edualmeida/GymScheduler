using GymScheduler.Domain.Models;
using MediatR;

namespace GymScheduler.Application.Features.Events.Commands
{
    public class CreateRequest : Event, IRequest
    {
    }
}
