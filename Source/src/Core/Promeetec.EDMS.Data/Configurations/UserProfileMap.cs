using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Promeetec.EDMS.Domain.Models.Betrokkene.UserProfile;

namespace Promeetec.EDMS.Data.Configurations;

public class UserProfileMap : IEntityTypeConfiguration<UserProfile>
{
    public void Configure(EntityTypeBuilder<UserProfile> builder)
    {
        builder.ToTable("UserProfile");

        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).HasDefaultValueSql("newid()");
    }
}