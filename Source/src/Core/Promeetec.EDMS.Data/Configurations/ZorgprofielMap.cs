using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Promeetec.EDMS.Domain.Models.Modules.Verbruiksmiddelen.Zorgprofiel;

namespace Promeetec.EDMS.Data.Configurations;

public class ZorgprofielMap : IEntityTypeConfiguration<Zorgprofiel>
{
    public void Configure(EntityTypeBuilder<Zorgprofiel> builder)
    {
        builder.ToTable("Zorgprofiel");

        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).HasDefaultValueSql("newid()");

        builder.HasIndex(e => e.ProfielCode);

        builder.HasMany(e => e.Verzekerden)
            .WithOne(e => e.Zorgprofiel)
            .HasForeignKey(e => e.ZorgprofielId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();
    }
}