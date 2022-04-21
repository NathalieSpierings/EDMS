using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Promeetec.EDMS.Domain.Models.Betrokkene.Weegmoment;

namespace Promeetec.EDMS.Data.Configurations;

public class WeegmomentMap : IEntityTypeConfiguration<Weegmoment>
{
    public void Configure(EntityTypeBuilder<Weegmoment> builder)
    {
        builder.ToTable("Weegmoment");

        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).HasDefaultValueSql("newid()");
    }
}