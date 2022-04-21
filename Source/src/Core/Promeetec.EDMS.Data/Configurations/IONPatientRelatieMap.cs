using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Promeetec.EDMS.Domain.Models.Modules.ION;

namespace Promeetec.EDMS.Data.Configurations;

public class IONPatientRelatieMap : IEntityTypeConfiguration<IONPatientRelatie>
{
    public void Configure(EntityTypeBuilder<IONPatientRelatie> builder)
    {
        builder.ToTable("IONPatientRelatie");

        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).HasDefaultValueSql("newid()");

        builder.HasIndex(e => e.AgbCodeZorgverlener);
        builder.HasIndex(e => e.AgbCodeOnderneming);
        builder.HasIndex(e => e.Achternaam);
        builder.HasIndex(e => e.Bsn);

        builder.HasOne(t => t.Organisatie)
            .WithMany(t => t.IONPatientRelaties)
            .HasForeignKey(d => d.OrganisatieId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();

        builder.HasOne(e => e.Medewerker)
            .WithMany()
            .HasForeignKey(e => e.MedewerkerId)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired();


        builder.HasOne(x => x.ZorggroepRelatie)
            .WithMany()
            .HasForeignKey(x => x.ZorggroepRelatieId)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired(false);
    }
}