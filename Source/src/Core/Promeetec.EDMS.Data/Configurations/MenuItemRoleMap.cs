using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Promeetec.EDMS.Domain.Models.Menu;

namespace Promeetec.EDMS.Data.Configurations;

public class MenuItemRoleMap : IEntityTypeConfiguration<MenuItemRole>
{
    public void Configure(EntityTypeBuilder<MenuItemRole> builder)
    {
        builder.ToTable("MenuItemRole");

        builder.HasKey(e => new { e.MenuItemId, e.RoleId });

        builder.HasOne(e => e.Role)
            .WithMany(e => e.MenuItems)
            .HasForeignKey(e => e.RoleId)
            .IsRequired();

        builder.HasOne(e => e.MenuItem)
            .WithMany(e => e.Roles)
            .HasForeignKey(e => e.MenuItemId)
            .IsRequired();
    }
}