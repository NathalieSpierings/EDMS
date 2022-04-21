using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Promeetec.EDMS.Domain.Models.Document.Rapportage;

namespace Promeetec.EDMS.Data.Configurations;

public class RapportageMap : IEntityTypeConfiguration<Rapportage>
{
    public void Configure(EntityTypeBuilder<Rapportage> builder)
    {
        builder.ToTable("Rapportages");

        builder.HasOne(e => e.Organisatie)
            .WithMany(e => e.Rapportages)
            .HasForeignKey(e => e.OrganisatieId)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired();
    }
}