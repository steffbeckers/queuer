using Queuer.Domain.Common;
using System;

namespace Queuer.Domain.Entities
{
    public class Ticket : AuditableEntity
    {
        public Guid Id { get; set; }
        public int Number { get; set; }
        public bool Done { get; set; }

        public Guid TenantId { get; set; }
        public Tenant Tenant { get; set; }
    }
}
