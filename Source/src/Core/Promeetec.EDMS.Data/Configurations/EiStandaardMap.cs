using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Promeetec.EDMS.Portaal.Domain.Models.Admin.EiStandaard;

namespace Promeetec.EDMS.Portaal.Data.Configurations;

public class EiStandaardMap : IEntityTypeConfiguration<EiStandaard>
{
    public void Configure(EntityTypeBuilder<EiStandaard> builder)
    {
        builder.ToTable("EiStandaard");

        builder.HasKey(x => x.Id);
        builder.Property(e => e.Id).HasDefaultValueSql("newid()");
    }
}