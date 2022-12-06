using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Promeetec.EDMS.Domain.Models.Changelog;

namespace Promeetec.EDMS.Data.Configurations;

public class ChangelogMap : IEntityTypeConfiguration<Changelog>
{
    public void Configure(EntityTypeBuilder<Changelog> builder)
    {
        builder.ToTable("Changelog");

        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).HasDefaultValueSql("newid()");
    }
}