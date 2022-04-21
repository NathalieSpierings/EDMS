using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Promeetec.EDMS.Domain.Models.Betrokkene.Zorgverzekering;

namespace Promeetec.EDMS.Data.Configurations;

public class ZorgverzekeringMap : IEntityTypeConfiguration<Zorgverzekering>
{
    public void Configure(EntityTypeBuilder<Zorgverzekering> builder)
    {
        builder.ToTable("Zorgverzekering");

        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).HasDefaultValueSql("newid()");

        builder.HasIndex(e => e.VerzekerdeNummer);
        builder.HasIndex(e => e.PatientNummer);

        builder.HasOne(e => e.Verzekeraar)
            .WithMany()
            .HasForeignKey(e => e.VerzekeraarId)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired();
    }
}