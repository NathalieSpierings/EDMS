﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Memo;

namespace Promeetec.EDMS.Portaal.Data.Configurations
{
    public class MemoMap : IEntityTypeConfiguration<Memo>
    {
        public void Configure(EntityTypeBuilder<Memo> builder)
        {
            builder.ToTable("Memo");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasDefaultValueSql("newid()");
        }
    }
}