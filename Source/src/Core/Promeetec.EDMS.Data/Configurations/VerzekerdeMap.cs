using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Promeetec.EDMS.Domain.Models.Betrokkene.Verzekerde;

namespace Promeetec.EDMS.Data.Configurations;

public class VerzekerdeMap : IEntityTypeConfiguration<Verzekerde>
{
    public void Configure(EntityTypeBuilder<Verzekerde> builder)
    {
        builder.ToTable("Verzekerden");

        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).HasDefaultValueSql("newid()");

        builder.HasIndex(e => e.AgbCodeVerwijzer);
        builder.HasIndex(e => e.Bsn);


        builder.HasOne(e => e.Adres)
            .WithMany()
            .HasForeignKey(e => e.AdresId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired(false);

        builder.HasMany(e => e.WeegMomenten)
            .WithOne(e => e.Verzekerde)
            .HasForeignKey(e => e.VerzekerdeId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired(false);

        builder.HasOne(e => e.Zorgverzekering)
            .WithMany()
            .HasForeignKey(e => e.ZorgverzekeringId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired(false);

        builder.HasOne(e => e.Zorgprofiel)
            .WithMany()
            .HasForeignKey(e => e.ZorgprofielId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired(false);


        builder.HasMany(e => e.GliBehandelplannen)
            .WithOne(e => e.Verzekerde)
            .HasForeignKey(e => e.VerzekerdeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}