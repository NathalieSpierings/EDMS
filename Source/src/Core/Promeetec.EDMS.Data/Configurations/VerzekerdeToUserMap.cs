using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Promeetec.EDMS.Domain.Models.Betrokkene.Verzekerde;

namespace Promeetec.EDMS.Data.Configurations;

public class VerzekerdeToUserMap : IEntityTypeConfiguration<VerzekerdeToUser>
{
    public void Configure(EntityTypeBuilder<VerzekerdeToUser> builder)
    {
        builder.ToTable("VerzekerdeToUser");

        builder.HasKey(e => new { e.VerzekerdeId, e.UserId });
    }
}