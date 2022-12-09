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
    }
}