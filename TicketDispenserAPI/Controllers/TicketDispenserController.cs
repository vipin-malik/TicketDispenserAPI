using Microsoft.AspNetCore.Mvc;
using TicketDispenserAPI.Services;

namespace TicketDispenserAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TicketDispenserController : ControllerBase
    {
        private readonly ITicketService _ticketService;        

        public TicketDispenserController(ITicketService ticketService)
        {
            _ticketService = ticketService;            
        }

        [HttpGet]
        public ActionResult<int> GetTicketNumber()
        {
            return 0;
        }
    }
}