using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Promeetec.EDMS.Portaal.Domain.Models.Admin.PushMessage;

namespace Promeetec.EDMS.Portaal.Data.Configurations;

public class PushMessageMap : IEntityTypeConfiguration<PushMessage>
{
    public void Configure(EntityTypeBuilder<PushMessage> builder)
    {
        builder.ToTable("PushMessage");

        builder.HasMany(c => c.Users)
            .WithOne(e => e.Message)
            .HasForeignKey(e => e.MessageId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();
    }
}