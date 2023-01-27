using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Adres;

namespace Promeetec.EDMS.Portaal.Data.Configurations;

public class AdresMap : IEntityTypeConfiguration<Adres>
{
    public void Configure(EntityTypeBuilder<Adres> builder)
    {
        builder.ToTable("Adres");

        builder.HasKey(x => x.Id);
        builder.Property(e => e.Id).HasDefaultValueSql("newid()");

        builder.HasOne(e => e.Land)
            .WithMany()
            .HasForeignKey(e => e.LandId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired(false);

        builder.HasMany(e => e.Verzekerden)
            .WithOne(e => e.Adres)
            .HasForeignKey(e => e.AdresId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();
    }
}