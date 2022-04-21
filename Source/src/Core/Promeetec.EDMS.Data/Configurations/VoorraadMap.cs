using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Promeetec.EDMS.Domain.Models.Betrokkene.Organisatie;
using Promeetec.EDMS.Domain.Models.Modules.Declaratie.Voorraad;

namespace Promeetec.EDMS.Data.Configurations;

public class VoorraadMap : IEntityTypeConfiguration<Voorraad>
{
    public void Configure(EntityTypeBuilder<Voorraad> builder)
    {
        builder.ToTable("Voorraad");

        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).HasDefaultValueSql("newid()");

        builder.HasOne(e => e.Organisatie)
            .WithOne(e => e.Voorraad)
            .HasForeignKey<Organisatie>(e => e.VoorraadId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired(false);

        builder.HasMany(e => e.Voorraadbestanden)
            .WithOne(e => e.Voorraad)
            .HasForeignKey(e => e.VoorraadId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired(false);
    }
}