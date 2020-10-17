using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Queuer.Application.Tickets.Commands.RequestTicket;
using Queuer.Application.Tickets.Queries.GetTicketByIdQuery;
using System;
using System.Threading.Tasks;

namespace Queuer.WebUI.Controllers
{
    public class TicketsController : ApiController
    {
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<TicketDto>> GetById([FromRoute] Guid id)
        {
            return await Mediator.Send(new GetTicketByIdQuery() { Id = id });
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> RequestTicket([FromBody] RequestTicketCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}
