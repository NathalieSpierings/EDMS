using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Promeetec.EDMS.Domain.Models.Admin.RedenEindeZorg;

namespace Promeetec.EDMS.Data.Configurations;

public class RedenEindeZorgMap : IEntityTypeConfiguration<RedenEindeZorg>
{
    public void Configure(EntityTypeBuilder<RedenEindeZorg> builder)
    {
        builder.ToTable("RedenEindeZorg");

        builder.HasKey(x => x.Id);
        builder.Property(e => e.Id).HasDefaultValueSql("newid()");
    }
}