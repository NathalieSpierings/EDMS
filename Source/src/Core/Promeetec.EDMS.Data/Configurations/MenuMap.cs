using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Promeetec.EDMS.Domain.Models.Menu;

namespace Promeetec.EDMS.Data.Configurations;

public class MenuMap : IEntityTypeConfiguration<Menu>
{
    public void Configure(EntityTypeBuilder<Menu> builder)
    {
        builder.ToTable("Menu");

        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).HasDefaultValueSql("newid()");

        builder.HasMany(e => e.MenuItems)
            .WithOne(e => e.Menu)
            .HasForeignKey(e => e.MenuId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired(false);
    }
}