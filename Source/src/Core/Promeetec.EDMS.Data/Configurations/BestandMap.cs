using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Promeetec.EDMS.Domain.Models.Document.Bestand;

namespace Promeetec.EDMS.Data.Configurations
{
    public class BestandMap : IEntityTypeConfiguration<Bestand>
    {
        public void Configure(EntityTypeBuilder<Bestand> builder)
        {
            builder.ToTable("Bestand");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasDefaultValueSql("newid()");

            builder.HasOne(e => e.Eigenaar)
                .WithMany()
                .HasForeignKey(e => e.EigenaarId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Samenvatting)
                .WithOne(e => e.Bestand)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(false);
        }
    }
}