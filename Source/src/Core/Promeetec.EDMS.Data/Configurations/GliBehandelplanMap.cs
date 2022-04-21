using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Promeetec.EDMS.Domain.Models.Modules.GLI.Behandelplan;

namespace Promeetec.EDMS.Data.Configurations;

public class GliBehandelplanMap : IEntityTypeConfiguration<GliBehandelplan>
{
    public void Configure(EntityTypeBuilder<GliBehandelplan> builder)
    {
        builder.ToTable("GliBehandelplan");

        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).HasDefaultValueSql("newid()");

        builder.HasOne(e => e.Intake)
            .WithMany(e => e.Behandelplannen)
            .HasForeignKey(e => e.IntakeId)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired();

        builder.HasOne(e => e.Behandelaar)
            .WithMany()
            .HasForeignKey(e => e.BehandelaarId)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired();


        builder.HasOne(e => e.RedenEindeZorg)
            .WithMany()
            .HasForeignKey(e => e.RedenEindeZorgId)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired(false);


        builder.HasOne(e => e.Intake)
            .WithMany(e => e.Behandelplannen)
            .HasForeignKey(e => e.IntakeId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();
    }
}