using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Promeetec.EDMS.Portaal.Data.Configurations;

public class SettingsMap : IEntityTypeConfiguration<Domain.Models.Admin.Settings.Settings>
{
    public void Configure(EntityTypeBuilder<Domain.Models.Admin.Settings.Settings> builder)
    {
        builder.ToTable("Settings");

        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).HasDefaultValueSql("newid()");
    }
}