using Queuer.Domain.Common;
using Queuer.Domain.Enums;
using System;

namespace Queuer.Domain.Entities
{
    public class Tenant : AuditableEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public string LogoURL { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
