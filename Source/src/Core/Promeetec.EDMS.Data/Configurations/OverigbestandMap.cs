using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Promeetec.EDMS.Domain.Models.Document.Overigbestand;

namespace Promeetec.EDMS.Data.Configurations;

public class OverigbestandMap : IEntityTypeConfiguration<Overigbestand>
{
    public void Configure(EntityTypeBuilder<Overigbestand> builder)
    {
        builder.ToTable("Overigbestand");
    }
}