using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Promeetec.EDMS.Portaal.Domain.Models.Menu.MenuItem;

namespace Promeetec.EDMS.Portaal.Data.Configurations;

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
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();

        builder.HasOne(x => x.Parent)
            .WithMany()
            .HasForeignKey(x => x.ParentId)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired(false);

        builder.HasMany(e => e.Roles)
            .WithOne(e => e.MenuItem)
            .HasForeignKey(e => e.MenuItemId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();
    }
}