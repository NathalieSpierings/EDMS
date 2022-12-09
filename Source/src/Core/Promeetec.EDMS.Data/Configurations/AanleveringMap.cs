using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Promeetec.EDMS.Domain.Models.Modules.Declaratie.Aanlevering;

namespace Promeetec.EDMS.Data.Configurations;

public class AanleveringMap : IEntityTypeConfiguration<Aanlevering>
{
    public void Configure(EntityTypeBuilder<Aanlevering> builder)
    {
        builder.ToTable("Aanlevering");

        builder.HasKey(x => x.Id);
        builder.Property(e => e.Id).HasDefaultValueSql("newid()");

        builder.HasIndex(e => e.Referentie);
        builder.HasIndex(e => e.ReferentiePromeetec);

        builder.HasOne(e => e.Eigenaar)
            .WithMany()
            .HasForeignKey(e => e.EigenaarId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();

        builder.HasOne(e => e.Behandelaar)
            .WithMany()
            .HasForeignKey(x => x.BehandelaarId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired(false);

        builder.HasMany(e => e.Aanleverberichten)
            .WithOne(e => e.Aanlevering)
            .HasForeignKey(e => e.AanleveringId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(e => e.Aanleverbestanden)
            .WithOne(e => e.Aanlevering)
            .HasForeignKey(e => e.AanleveringId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(e => e.Overigebestanden)
            .WithOne(e => e.Aanlevering)
            .HasForeignKey(e => e.AanleveringId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}