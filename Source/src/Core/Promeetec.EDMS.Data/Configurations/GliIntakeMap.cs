using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Promeetec.EDMS.Portaal.Domain.Models.Modules.GLI.Intake;

namespace Promeetec.EDMS.Portaal.Data.Configurations;

public class GliIntakeMap : IEntityTypeConfiguration<GliIntake>
{
    public void Configure(EntityTypeBuilder<GliIntake> builder)
    {
        builder.ToTable("GliIntake");

        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).HasDefaultValueSql("newid()");

        builder.HasIndex(e => e.IntakeDatum);
        builder.HasIndex(e => e.Verwerkt);

        builder.HasOne(e => e.Verzekerde)
            .WithMany(e => e.GliIntakes)
            .HasForeignKey(e => e.VerzekerdeId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();

        builder.HasOne(e => e.Behandelaar)
            .WithMany()
            .HasForeignKey(e => e.BehandelaarId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();


        builder.HasMany(e => e.Behandelplannen)
            .WithOne(e => e.Intake)
            .HasForeignKey(e => e.IntakeId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();
    }
}