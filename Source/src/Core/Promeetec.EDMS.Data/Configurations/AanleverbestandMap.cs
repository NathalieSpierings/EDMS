using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Promeetec.EDMS.Domain.Models.Document.Aanleverbestand.Aanleverberstand;

namespace Promeetec.EDMS.Data.Configurations;

public class AanleverbestandMap : IEntityTypeConfiguration<Aanleverbestand>
{
    public void Configure(EntityTypeBuilder<Aanleverbestand> builder)
    {
        builder.ToTable("Aanleverbestand");

        builder.HasOne(e => e.Zorgstraat)
            .WithMany()
            .HasForeignKey(e => e.ZorgstraatId)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired(false);

        builder.HasOne(e => e.EiStandaard)
            .WithMany()
            .HasForeignKey(e => e.EiStandaardId)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired(false);
    }
}