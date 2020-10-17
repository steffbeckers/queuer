using Queuer.Application.Common.Mappings;
using Queuer.Domain.Entities;
using System;

namespace Queuer.Application.Tickets.Queries.GetTicketByIdQuery
{
    public class TicketDto : IMapFrom<Ticket>
    {
        public Guid Id { get; set; }
        public int Number { get; set; }
        public bool Done { get; set; }

        public Guid TenantId { get; set; }
        public TenantDto Tenant { get; set; }
    }
}
