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

        builder.HasOne(e => e.User)
            .WithMany(e => e.Groups)
            .HasForeignKey(e => e.UserId)
            .IsRequired();

        builder.HasOne(e => e.Group)
            .WithMany(e => e.Users)
            .HasForeignKey(e => e.GroupId)
            .IsRequired();
    }
}