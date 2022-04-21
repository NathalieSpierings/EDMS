using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Promeetec.EDMS.Domain.Models.Document.Aanleverbestand.Samenvatting;

namespace Promeetec.EDMS.Data.Configurations;

public class AanleverbestandSamenvattingMap : IEntityTypeConfiguration<AanleverbestandSamenvatting>
{
    public void Configure(EntityTypeBuilder<AanleverbestandSamenvatting> builder)
    {
        builder.ToTable("AanleverbestandSamenvatting");
    }
}