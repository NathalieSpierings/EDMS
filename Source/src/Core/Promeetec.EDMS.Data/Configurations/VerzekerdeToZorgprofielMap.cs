using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Promeetec.EDMS.Domain.Models.Betrokkene.Verzekerde;

namespace Promeetec.EDMS.Data.Configurations;

public class VerzekerdeToZorgprofielMap : IEntityTypeConfiguration<VerzekerdeToZorgprofiel>
{
    public void Configure(EntityTypeBuilder<VerzekerdeToZorgprofiel> builder)
    {
        builder.ToTable("VerzekerdeToZorgprofiel");

        builder.HasKey(e => new { e.VerzekerdeId, e.ZorgprofielId });

        builder.HasOne(e => e.Zorgprofiel)
            .WithMany(e => e.Verzekerden)
            .HasForeignKey(e => e.ZorgprofielId)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired();

        builder.HasOne(e => e.Verzekerde)
            .WithMany(e => e.Zorgprofielen)
            .HasForeignKey(e => e.VerzekerdeId)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired();
    }
}