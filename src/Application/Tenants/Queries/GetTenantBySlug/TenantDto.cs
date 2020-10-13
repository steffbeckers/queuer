using Queuer.Application.Common.Mappings;
using Queuer.Domain.Entities;
using System;

namespace Queuer.Application.Tenants.Queries.GetTenantBySlug
{
    public class TenantDto : IMapFrom<Tenant>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public string LogoURL { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
