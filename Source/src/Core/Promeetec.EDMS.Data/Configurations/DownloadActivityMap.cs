using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Promeetec.EDMS.Portaal.Domain.Models.Admin.DownloadActivity;

namespace Promeetec.EDMS.Portaal.Data.Configurations;

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
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();

        builder.HasOne(e => e.Bestand)
            .WithMany()
            .HasForeignKey(e => e.BestandId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();
    }
}