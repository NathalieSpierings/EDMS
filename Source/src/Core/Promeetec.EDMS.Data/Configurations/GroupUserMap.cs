using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Promeetec.EDMS.Domain.Models.Identity.Group;

namespace Promeetec.EDMS.Data.Configurations;

public class GroupUserMap : IEntityTypeConfiguration<GroupUser>
{
    public void Configure(EntityTypeBuilder<GroupUser> builder)
    {
        builder.ToTable("GroupUser");

        builder.HasKey(e => new { e.GroupId, e.UserId });
    }
}