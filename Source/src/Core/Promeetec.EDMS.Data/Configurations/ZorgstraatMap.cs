using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Promeetec.EDMS.Portaal.Domain.Models.Admin.Zorgstraat;

namespace Promeetec.EDMS.Portaal.Data.Configurations;

public class ZorgstraatMap : IEntityTypeConfiguration<Zorgstraat>
{
    public void Configure(EntityTypeBuilder<Zorgstraat> builder)
    {
        builder.ToTable("Zorgstraat");

        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).HasDefaultValueSql("newid()");

        builder.HasIndex(e => e.Naam);
    }
}