﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Promeetec.EDMS.Domain.Models.Betrokkene.Organisatie;

namespace Promeetec.EDMS.Data.Configurations;

public class OrganisatieMap : IEntityTypeConfiguration<Organisatie>
{
    public void Configure(EntityTypeBuilder<Organisatie> builder)
    {
        builder.ToTable("Organisaties");

        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).HasDefaultValueSql("newid()");

        builder.Ignore(e => e.DisplayName);
        builder.Ignore(e => e.IsPromeetec);

        builder.HasIndex(e => e.Nummer).IsUnique();
        builder.HasIndex(e => e.Naam);

        builder.OwnsOne(e => e.Settings);

        builder.OwnsOne(e => e.Settings,
            sa =>
            {
                sa.Property(p => p.AanleverStatusNaSchrijvenAanleverbestanden).HasColumnName("AanleverStatusNaSchrijvenAanleverbestanden");
                sa.Property(p => p.AanleverbestandLocatie).HasColumnName("AanleverbestandLocatie");
                sa.Property(p => p.VerwijzerInAdresboek).HasColumnName("VerwijzerInAdresboek");
            });

        builder.HasOne(x => x.ZorggroepRelatie)
            .WithMany()
            .HasForeignKey(x => x.ZorggroepRelatieId)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired(false);


        builder.HasOne(e => e.Contactpersoon)
            .WithMany()
            .HasForeignKey(x => x.ContactpersoonId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired(false);


        builder.HasOne(e => e.Adres)
            .WithMany()
            .HasForeignKey(e => e.AdresId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired(false);

        builder.HasMany(e => e.Medewerkers)
            .WithOne(e => e.Organisatie)
            .HasForeignKey(e => e.OrganisatieId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();

        builder.HasMany(e => e.Aanleveringen)
            .WithOne(e => e.Organisatie)
            .HasForeignKey(e => e.OrganisatieId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();

        builder.HasMany(c => c.HaarwerkPrestaties)
            .WithOne(e => e.Organisatie)
            .HasForeignKey(e => e.OrganisatieId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();

        builder.HasMany(c => c.Rapportages)
            .WithOne(e => e.Organisatie)
            .HasForeignKey(e => e.OrganisatieId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();

        builder.HasMany(e => e.GliIntakes)
            .WithOne(e => e.Organisatie)
            .HasForeignKey(e => e.OrganisatieId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();

        builder.HasMany(c => c.VerbruiksmiddelPrestaties)
            .WithOne(e => e.Organisatie)
            .HasForeignKey(e => e.OrganisatieId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();


    }
}