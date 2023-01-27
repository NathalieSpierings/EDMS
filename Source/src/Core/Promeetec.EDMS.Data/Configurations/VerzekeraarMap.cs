using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Verzekeraar;

namespace Promeetec.EDMS.Portaal.Data.Configurations;

public class VerzekeraarMap : IEntityTypeConfiguration<Verzekeraar>
{
    public void Configure(EntityTypeBuilder<Verzekeraar> builder)
    {
        builder.ToTable("Verzekeraar");

        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).HasDefaultValueSql("newid()");

        builder.HasIndex(e => e.Uzovi);
        builder.HasIndex(e => e.Naam);
    }
}