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
    }
}