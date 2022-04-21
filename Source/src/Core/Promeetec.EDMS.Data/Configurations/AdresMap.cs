using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Promeetec.EDMS.Domain.Models.Betrokkene.Adres;

namespace Promeetec.EDMS.Data.Configurations;

public class AdresMap : IEntityTypeConfiguration<Adres>
{
    public void Configure(EntityTypeBuilder<Adres> builder)
    {
        builder.ToTable("Adres");

        builder.HasKey(x => x.Id);
        builder.Property(e => e.Id).HasDefaultValueSql("newid()");

        builder.HasOne(e => e.Land)
            .WithMany()
            .HasForeignKey(e => e.LandId)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired(false);
    }
}