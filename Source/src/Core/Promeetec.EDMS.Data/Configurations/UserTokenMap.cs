using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Promeetec.EDMS.Domain.Models.Identity;

namespace Promeetec.EDMS.Data.Configurations;

public class UserTokenMap : IEntityTypeConfiguration<UserToken>
{
    public void Configure(EntityTypeBuilder<UserToken> builder)
    {
        builder.ToTable("UserTokens");
    }
}