using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Promeetec.EDMS.Domain.Models.Betrokkene.Verzekerde;

namespace Promeetec.EDMS.Data.Configurations;

public class VerzekerdeToZorgverzekeringMap : IEntityTypeConfiguration<VerzekerdeToZorgverzekering>
{
    public void Configure(EntityTypeBuilder<VerzekerdeToZorgverzekering> builder)
    {
        builder.ToTable("VerzekerdeToZorgverzekering");

        builder.HasKey(e => new { e.VerzekerdeId, e.ZorgverzekeringId });

        builder.HasOne(e => e.Verzekerde)
            .WithMany(e => e.Zorgverzekeringen)
            .HasForeignKey(e => e.VerzekerdeId)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired();

        builder.HasOne(e => e.Zorgverzekering)
            .WithMany(e => e.Verzekerden)
            .HasForeignKey(e => e.ZorgverzekeringId)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired();
    }
}