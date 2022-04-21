using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Promeetec.EDMS.Domain.Models.Identity.Role;

namespace Promeetec.EDMS.Data.Configurations;

public class RoleMap : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable("Roles");

        builder.HasKey(x => x.Id);
        builder.Property(e => e.Id).HasDefaultValueSql("newid()");


        // Each Role can have many entries in the UserRole join table
        builder.HasMany(e => e.UserRoles)
            .WithOne(e => e.Role)
            .HasForeignKey(ur => ur.RoleId)
            .IsRequired();


        // Each Role can have many associated RoleClaims
        builder.HasMany(e => e.RoleClaims)
            .WithOne(e => e.Role)
            .HasForeignKey(rc => rc.RoleId)
            .IsRequired();
    }
}