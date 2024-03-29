﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Promeetec.EDMS.Portaal.Domain.Models.Modules.GLI.Behandelplan;

namespace Promeetec.EDMS.Portaal.Data.Configurations;

public class GliBehandelplanMap : IEntityTypeConfiguration<GliBehandelplan>
{
    public void Configure(EntityTypeBuilder<GliBehandelplan> builder)
    {
        builder.ToTable("GliBehandelplan");

        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).HasDefaultValueSql("newid()");

        builder.HasOne(e => e.Intake)
            .WithMany(e => e.Behandelplannen)
            .HasForeignKey(e => e.IntakeId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();

        builder.HasOne(e => e.RedenEindeZorg)
            .WithMany()
            .HasForeignKey(e => e.RedenEindeZorgId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired(false);
    }
}