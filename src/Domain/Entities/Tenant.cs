using Queuer.Domain.Common;
using Queuer.Domain.Enums;
using System;
using System.Collections.Generic;

namespace Queuer.Domain.Entities
{
    public class Tenant : AuditableEntity
    {
        public Tenant()
        {
            Tickets = new List<Ticket>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public string LogoURL { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public ICollection<Ticket> Tickets { get; set; }
    }
}
