using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Promeetec.EDMS.Domain.Models.Betrokkene.Medewerker;

namespace Promeetec.EDMS.Data.Configurations;

public class MedewerkerMap : IEntityTypeConfiguration<Medewerker>
{
    public void Configure(EntityTypeBuilder<Medewerker> builder)
    {
        builder.ToTable("Medewerkers");

        builder.HasKey(x => x.Id);
        builder.Property(e => e.Id).HasDefaultValueSql("newid()");

        builder.HasIndex(e => e.AgbCodeZorgverlener);
        builder.HasIndex(e => e.AgbCodeOnderneming);
        builder.HasIndex(e => e.UserName).IsUnique();


        builder.Property(e => e.UserName).HasMaxLength(128);
        builder.Property(e => e.NormalizedUserName).HasMaxLength(128);
        builder.Property(e => e.Email).HasMaxLength(256);
        builder.Property(e => e.NormalizedEmail).HasMaxLength(256);

        builder.OwnsOne(e => e.Persoon);

        builder.OwnsOne(e => e.Persoon,
            sa =>
            {
                sa.Property(p => p.Geslacht).HasColumnName("Geslacht");
                sa.Property(p => p.Geboortedatum).HasColumnName("Geboortedatum");
                sa.Property(p => p.Voorletters).HasColumnName("Voorletters");
                sa.Property(p => p.Voornaam).HasColumnName("Voornaam");
                sa.Property(p => p.Tussenvoegsel).HasColumnName("Tussenvoegsel");
                sa.Property(p => p.Achternaam).HasColumnName("Achternaam");
                sa.Property(p => p.VolledigeNaam).HasColumnName("VolledigeNaam");
                sa.Property(p => p.FormeleNaam).HasColumnName("FormeleNaam");
                sa.Property(p => p.Email).HasColumnName("Email");
                sa.Property(p => p.TelefoonZakelijk).HasColumnName("TelefoonZakelijk");
                sa.Property(p => p.TelefoonPrive).HasColumnName("TelefoonPrive");
                sa.Property(p => p.Doorkiesnummer).HasColumnName("Doorkiesnummer");
            });

        builder.HasOne(e => e.ActivationMailSendBy)
            .WithMany()
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired(false);

        builder.HasMany(e => e.Verzekerden)
            .WithOne(e => e.User)
            .HasForeignKey(e => e.UserId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();

        builder.HasOne(e => e.Adres)
            .WithMany()
            .HasForeignKey(e => e.AdresId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired(false);

        builder.HasMany(e => e.Memos)
            .WithOne(e => e.Medewerker)
            .HasForeignKey(e => e.MedewerkerId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();

        builder.HasMany(e => e.Claims)
            .WithOne(e => e.User)
            .HasForeignKey(e => e.UserId)
            .IsRequired();

        builder.HasMany(e => e.Logins)
            .WithOne(e => e.User)
            .HasForeignKey(e => e.UserId)
            .IsRequired();

        builder.HasMany(e => e.Tokens)
            .WithOne(e => e.User)
            .HasForeignKey(e => e.UserId)
            .IsRequired();

        builder.HasMany(e => e.UserRoles)
            .WithOne(e => e.User)
            .HasForeignKey(e => e.UserId)
            .IsRequired();

        builder.HasMany(e => e.Groups)
            .WithOne(e => e.User)
            .HasForeignKey(e => e.UserId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();

        builder.HasMany(e => e.Notificaties)
            .WithOne(e => e.Medewerker)
            .HasForeignKey(e => e.MedewerkerId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();
    }
}