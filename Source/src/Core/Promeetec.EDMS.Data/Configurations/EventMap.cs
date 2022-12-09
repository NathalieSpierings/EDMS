using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Promeetec.EDMS.Domain.Models.Event;

namespace Promeetec.EDMS.Data.Configurations;

public class EventMap : IEntityTypeConfiguration<Event>
{
    public void Configure(EntityTypeBuilder<Event> builder)
    {
        builder.ToTable("Events");

        builder.HasOne(x => x.User)
            .WithMany(x => x.Events)
            .OnDelete(DeleteBehavior.Restrict);
    }
}