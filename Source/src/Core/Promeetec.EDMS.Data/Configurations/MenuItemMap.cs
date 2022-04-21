using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Promeetec.EDMS.Domain.Models.Menu;

namespace Promeetec.EDMS.Data.Configurations;

public class MenuItemMap : IEntityTypeConfiguration<MenuItem>
{
    public void Configure(EntityTypeBuilder<MenuItem> builder)
    {
        builder.ToTable("MenuItem");

        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).HasDefaultValueSql("newid()");

        builder.HasOne(x => x.Menu)
            .WithMany(x => x.MenuItems)
            .HasForeignKey(x => x.MenuId)
            .IsRequired();


        builder.HasOne(x => x.Parent)
            .WithMany()
            .HasForeignKey(x => x.ParentId)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired(false);

        builder.HasMany(x => x.Roles);
    }
}