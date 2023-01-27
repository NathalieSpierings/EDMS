using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Promeetec.EDMS.Portaal.Domain.Models.Document.Aanleverbestand.Samenvatting;

namespace Promeetec.EDMS.Portaal.Data.Configurations;

public class AanleverbestandSamenvattingMap : IEntityTypeConfiguration<AanleverbestandSamenvatting>
{
    public void Configure(EntityTypeBuilder<AanleverbestandSamenvatting> builder)
    {
        builder.ToTable("AanleverbestandSamenvatting");
    }
}