using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Promeetec.EDMS.Domain.Models.Identity.Group;

namespace Promeetec.EDMS.Data.Configurations;

public class GroupRoleMap : IEntityTypeConfiguration<GroupRole>
{
    public void Configure(EntityTypeBuilder<GroupRole> builder)
    {
        builder.ToTable("GroupRole");

        builder.HasKey(e => new { e.GroupId, e.RoleId });

        builder.HasOne(e => e.Role)
            .WithMany(e => e.Groups)
            .HasForeignKey(e => e.RoleId)
            .IsRequired();

        builder.HasOne(e => e.Group)
            .WithMany(e => e.Roles)
            .HasForeignKey(e => e.GroupId)
            .IsRequired();
    }
}