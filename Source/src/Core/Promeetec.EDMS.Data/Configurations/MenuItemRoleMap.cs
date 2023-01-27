using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Promeetec.EDMS.Portaal.Domain.Models.Menu.MenuItem;

namespace Promeetec.EDMS.Portaal.Data.Configurations;

public class MenuItemRoleMap : IEntityTypeConfiguration<MenuItemRole>
{
    public void Configure(EntityTypeBuilder<MenuItemRole> builder)
    {
        builder.ToTable("MenuItemRole");

        builder.HasKey(e => new { e.MenuItemId, e.RoleId });
    }
}