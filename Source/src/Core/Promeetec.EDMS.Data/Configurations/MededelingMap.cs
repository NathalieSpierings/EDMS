﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Promeetec.EDMS.Domain.Models.Admin.Mededeling;

namespace Promeetec.EDMS.Data.Configurations;

public class MededelingMap : IEntityTypeConfiguration<Mededeling>
{
    public void Configure(EntityTypeBuilder<Mededeling> builder)
    {
        builder.ToTable("Mededeling");

        builder.HasKey(x => x.Id);
        builder.Property(e => e.Id).HasDefaultValueSql("newid()");
    }
}