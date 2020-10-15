using MediatR;
using Microsoft.EntityFrameworkCore;
using Queuer.Application.Common.Exceptions;
using Queuer.Application.Common.Interfaces;
using Queuer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Queuer.Application.Tickets.Commands.RequestTicket
{
    public class RequestTicketCommand : IRequest<Guid>
    {
        public Guid TenantId { get; set; }
    }

    public class RequestTicketCommandHandler : IRequestHandler<RequestTicketCommand, Guid>
    {
        private readonly IApplicationDbContext _context;

        public RequestTicketCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(RequestTicketCommand request, CancellationToken cancellationToken)
        {
            // Retrieve tenant by tenant ID
            Tenant tenant = await _context.Tenants.Include(x => x.Tickets.Where(x => !x.Done)).FirstOrDefaultAsync(x => x.Id == request.TenantId);
            if (tenant == null)
            {
                throw new NotFoundException($"Tenant with ID: {tenant.Id.ToString().ToUpper()} not found.");
            }

            // Create a new ticket with the next number
            Ticket ticket = new Ticket();

            int nextTicketNumber = 1;
            if (tenant.Tickets.Any())
            {
                nextTicketNumber = tenant.Tickets.Max(x => x.Number) + 1;
            }

            ticket.Number = nextTicketNumber;

            // Save ticket to database
            tenant.Tickets.Add(ticket);

            await _context.SaveChangesAsync(cancellationToken);

            return ticket.Id;
        }
    }
}
