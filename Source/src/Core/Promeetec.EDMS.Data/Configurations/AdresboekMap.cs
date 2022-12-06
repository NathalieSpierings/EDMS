using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Promeetec.EDMS.Domain.Models.Betrokkene.Organisatie;
using Promeetec.EDMS.Domain.Models.Modules.Adresboek;

namespace Promeetec.EDMS.Data.Configurations;

public class AdresboekMap : IEntityTypeConfiguration<Adresboek>
{
    public void Configure(EntityTypeBuilder<Adresboek> builder)
    {
        builder.ToTable("Adresboek");

        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).HasDefaultValueSql("newid()");

        builder.HasOne(e => e.Organisatie)
            .WithOne(e => e.Adresboek)
            .HasForeignKey<Organisatie>(e => e.AdresboekId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired(false);

        builder.HasMany(e => e.Verzekerden)
            .WithOne(e => e.Adresboek)
            .HasForeignKey(e => e.AdresboekId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();
    }
}