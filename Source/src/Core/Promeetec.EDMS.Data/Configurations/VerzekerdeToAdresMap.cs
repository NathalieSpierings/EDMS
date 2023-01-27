using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Verzekerde;

namespace Promeetec.EDMS.Portaal.Data.Configurations;

public class VerzekerdeToAdresMap : IEntityTypeConfiguration<VerzekerdeToAdres>
{
    public void Configure(EntityTypeBuilder<VerzekerdeToAdres> builder)
    {
        builder.ToTable("VerzekerdeToAdres");

        builder.HasKey(e => new { e.VerzekerdeId, e.AdresId });
    }
}