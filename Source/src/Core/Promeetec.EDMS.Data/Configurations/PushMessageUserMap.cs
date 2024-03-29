﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Promeetec.EDMS.Portaal.Domain.Models.Admin.PushMessage;

namespace Promeetec.EDMS.Portaal.Data.Configurations;

public class PushMessageUserMap : IEntityTypeConfiguration<PushMessageToUser>
{
    public void Configure(EntityTypeBuilder<PushMessageToUser> builder)
    {
        builder.ToTable("PushMessageToUser");

        builder.HasKey(e => new { e.MessageId, e.UserId });
    }
}