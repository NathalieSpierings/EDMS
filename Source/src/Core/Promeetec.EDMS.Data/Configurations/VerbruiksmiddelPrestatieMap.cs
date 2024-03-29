﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Promeetec.EDMS.Portaal.Domain.Models.Modules.Verbruiksmiddelen.Verbruiksmiddel;

namespace Promeetec.EDMS.Portaal.Data.Configurations;

public class VerbruiksmiddelPrestatieMap : IEntityTypeConfiguration<VerbruiksmiddelPrestatie>
{
    public void Configure(EntityTypeBuilder<VerbruiksmiddelPrestatie> builder)
    {
        builder.ToTable("VerbruiksmiddelPrestaties");

        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).HasDefaultValueSql("newid()");

        builder.HasIndex(e => e.OrganisatieId);
        builder.HasIndex(e => e.VerzekerdeId);

        builder.HasOne(e => e.Verzekerde)
            .WithMany(e => e.VerbruiksmiddelPrestaties)
            .HasForeignKey(e => e.VerzekerdeId)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired();

    }
}