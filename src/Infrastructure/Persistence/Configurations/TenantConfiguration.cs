
using Queuer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Queuer.Infrastructure.Persistence.Configurations
{
    public class TenantConfiguration : IEntityTypeConfiguration<Tenant>
    {
        public void Configure(EntityTypeBuilder<Tenant> builder)
        {
            builder.Property(t => t.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(t => t.Slug)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(t => t.Email)
                .HasMaxLength(100);

            builder.Property(t => t.PhoneNumber)
                .HasMaxLength(50);

            builder.Property(t => t.CurrentTicketNumber)
                .HasDefaultValue(1);

            builder.Property(t => t.MaxTicketNumber)
                .HasDefaultValue(99);
        }
    }
}
