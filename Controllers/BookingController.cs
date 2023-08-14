using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ_Masstransit_WebAPI.Models;
using RabbitMQ_Masstransit_WebAPI.Services.Abstract;

namespace RabbitMQ_Masstransit_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {

        private readonly IMessageProducer messageProducer;
        private readonly ILogger logger;

        // in memory db
        public static readonly List<Booking> bookings = new();

        public BookingController(ILogger<BookingController> logger, IMessageProducer messageProducer)
        {
            this.messageProducer = messageProducer;
            this.logger = logger;
        }

        [HttpPost("Add")]
        public IActionResult Add(Booking booking)
        {
            if (!ModelState.IsValid) { return BadRequest(); }

            bookings.Add(booking);

            messageProducer.SendMessage(booking);

            return Ok();
        }

    }
}
