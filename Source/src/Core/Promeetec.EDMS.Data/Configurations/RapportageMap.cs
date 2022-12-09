using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Promeetec.EDMS.Domain.Models.Document.Rapportage;

namespace Promeetec.EDMS.Data.Configurations;

public class RapportageMap : IEntityTypeConfiguration<Rapportage>
{
    public void Configure(EntityTypeBuilder<Rapportage> builder)
    {
        builder.ToTable("Rapportages");
    }
}