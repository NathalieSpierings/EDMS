using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Promeetec.EDMS.Domain.Models.Modules.Haarwerk;

namespace Promeetec.EDMS.Data.Configurations;

public class HaarwerkMap : IEntityTypeConfiguration<Haarwerk>
{
    public void Configure(EntityTypeBuilder<Haarwerk> builder)
    {
        builder.ToTable("Haarwerk");

        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).HasDefaultValueSql("newid()");
    }
}