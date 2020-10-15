using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Queuer.Application.Tickets.Commands.RequestTicket;
using System;
using System.Threading.Tasks;

namespace Queuer.WebUI.Controllers
{
    [Authorize]
    public class TicketsController : ApiController
    {
        [HttpPost]
        public async Task<ActionResult<Guid>> RequestTicket([FromBody] RequestTicketCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}
