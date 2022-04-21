using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Promeetec.EDMS.Domain.Models.Betrokkene.Land;

namespace Promeetec.EDMS.Data.Configurations
{
    public class LandMap : IEntityTypeConfiguration<Land>
    {
        public void Configure(EntityTypeBuilder<Land> builder)
        {
            builder.ToTable("Land");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasDefaultValueSql("newid()");

            builder.HasIndex(e => e.NativeName).IsUnique();
        }
    }
}