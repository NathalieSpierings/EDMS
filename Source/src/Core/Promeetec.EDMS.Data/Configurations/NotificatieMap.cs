using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Promeetec.EDMS.Domain.Models.Betrokkene.Notification;

namespace Promeetec.EDMS.Data.Configurations;

public class NotificatieMap : IEntityTypeConfiguration<Notificatie>
{
    public void Configure(EntityTypeBuilder<Notificatie> builder)
    {
        builder.ToTable("Notificatie");

        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).HasDefaultValueSql("newid()");
    }
}