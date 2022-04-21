using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Promeetec.EDMS.Domain.Models.Admin.DownloadActivity;

namespace Promeetec.EDMS.Data.Configurations;

public class DownloadActivityMap : IEntityTypeConfiguration<DownloadActivity>
{
    public void Configure(EntityTypeBuilder<DownloadActivity> builder)
    {
        builder.ToTable("DownloadActivity");

        builder.HasKey(x => x.Id);
        builder.Property(e => e.Id).HasDefaultValueSql("newid()");

        builder.HasOne(e => e.Medewerker)
            .WithMany()
            .HasForeignKey(e => e.MedewerkerId)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired();

        builder.HasOne(e => e.Bestand)
            .WithMany()
            .HasForeignKey(e => e.BestandId)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired();
    }
}