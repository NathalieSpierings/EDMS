using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Verzekerde;

namespace Promeetec.EDMS.Portaal.Data.Configurations;

public class VerzekerdeMap : IEntityTypeConfiguration<Verzekerde>
{
    public void Configure(EntityTypeBuilder<Verzekerde> builder)
    {
        builder.ToTable("Verzekerden");

        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).HasDefaultValueSql("newid()");

        builder.HasIndex(e => e.AgbCodeVerwijzer);
        builder.HasIndex(e => e.Bsn);

        builder.HasMany(e => e.Adressen)
            .WithOne(e => e.Verzekerde)
            .HasForeignKey(e => e.VerzekerdeId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();

        builder.HasMany(e => e.WeegMomenten)
            .WithOne(e => e.Verzekerde)
            .HasForeignKey(e => e.VerzekerdeId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired(false);

        builder.HasMany(e => e.Zorgprofielen)
            .WithOne(e => e.Verzekerde)
            .HasForeignKey(e => e.VerzekerdeId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();

        builder.HasMany(e => e.Zorgverzekeringen)
            .WithOne(e => e.Verzekerde)
            .HasForeignKey(e => e.VerzekerdeId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired(false);

        builder.HasMany(e => e.Users)
            .WithOne(e => e.Verzekerde)
            .HasForeignKey(e => e.UserId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();

        builder.HasMany(e => e.VerbruiksmiddelPrestaties)
            .WithOne(e => e.Verzekerde)
            .HasForeignKey(e => e.VerzekerdeId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired(false);
    }
}