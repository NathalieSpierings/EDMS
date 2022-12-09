using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Promeetec.EDMS.Domain.Models.Modules.Declaratie.Aanleverbericht;

namespace Promeetec.EDMS.Data.Configurations;

public class AanleverberichtMap : IEntityTypeConfiguration<Aanleverbericht>
{
    public void Configure(EntityTypeBuilder<Aanleverbericht> builder)
    {
        builder.ToTable("Aanleverbericht");

        builder.HasKey(x => x.Id);
        builder.Property(e => e.Id).HasDefaultValueSql("newid()");

        builder.HasIndex(e => e.Onderwerp);

        builder.HasOne(e => e.Afzender)
            .WithMany()
            .HasForeignKey(e => e.AfzenderId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();

        builder.HasOne(e => e.Ontvanger)
            .WithMany()
            .HasForeignKey(e => e.OntvangerId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();
    }
}