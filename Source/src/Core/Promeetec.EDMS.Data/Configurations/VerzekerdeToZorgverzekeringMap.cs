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
    }
}