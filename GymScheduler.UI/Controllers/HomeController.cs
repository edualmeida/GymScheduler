using AutoMapper;
using GymScheduler.Application.Features.Events.Commands;
using GymScheduler.Application.Features.Events.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using GymScheduler.Models;

namespace GymScheduler.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IMediator mediator, IMapper mapper, ILogger<HomeController> logger)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public IActionResult Index()
        {
            return View();
        }

        //[HttpGet]
        //public IActionResult GetCalendarEvents([FromQuery] string start, [FromQuery] string end)
        //{
        //    string[] dateFormat = { "r", "R", "ddd, dd MMM yyyy HH:mm:ss" };

        //    DateTime parsedStart;

        //    if (!DateTime.TryParseExact(start, dateFormat, CultureInfo.InvariantCulture,
        //            DateTimeStyles.AssumeUniversal, out parsedStart))
        //        throw new Exception($"Could not parse {start}");

        //    List<Event> events = _DA.GetCalendarEvents(
        //        DateTime.SpecifyKind(parsedStart, DateTimeKind.Utc),
        //        DateTime.SpecifyKind(parsedEnd, DateTimeKind.Utc));

        //    return Json(events);
        //}

        [HttpGet]
        public async Task<IActionResult> GetCalendarEvents(string start, string end)
        {
            var events = await _mediator.Send(new GetByDateRequest()
            {
                Start = DateTime.SpecifyKind(DateTime.Parse(start), DateTimeKind.Utc),
                End = DateTime.SpecifyKind(DateTime.Parse(end), DateTimeKind.Utc),
            });

            return Json(_mapper.Map<List<EventVm>>(events));
        }

        [HttpPost]
        public async Task<IActionResult> UpdateEvent([FromBody] EventVm evt)
        {
            string message = String.Empty;

            await _mediator.Send(_mapper.Map<UpdateRequest>(evt));

            return Json(new { message });
        }

        [HttpPost]
        public async Task<IActionResult> AddEvent([FromBody] EventVm newEvent)
        {
            string message = String.Empty;
            string eventId = Guid.NewGuid().ToString();
            var createRequest = _mapper.Map<CreateRequest>(newEvent);

            createRequest.Id = eventId;
            await _mediator.Send(createRequest);

            return Json(new { message, eventId });
        }

        [HttpPost]
        public async Task<IActionResult> DeleteEvent([FromBody] DeleteEventRequest request)
        {
            string message = String.Empty;

            await _mediator.Send(new DeleteRequest()
            {
                Id = request.EventId
            });

            return Json(new { message });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}