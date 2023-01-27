using Microsoft.EntityFrameworkCore;
using Promeetec.EDMS.Portaal.Data.Context;

namespace Promeetec.EDMS.Tests.Helpers;

public static class Shared
{
    public static string ConnectionString = "Server=.;Database=Promeetec.EDMS.DOTCore;Trusted_Connection=True; Encrypt=False;MultipleActiveResultSets=true";
    public static DbContextOptions<EDMSDbContext> CreateContextOptions()
    {
        var builder = new DbContextOptionsBuilder<EDMSDbContext>();
        builder.UseInMemoryDatabase("EDMS");
        return builder.Options;
    }

    public static DbContextOptions<EDMSDbContext> CreateRealDbContextOptions()
    {

        //return new DbContextOptionsBuilder<EDMSDbContext>().UseSqlServer(ConnectionString).Options;

        var builder = new DbContextOptionsBuilder<EDMSDbContext>().UseSqlServer(ConnectionString);
        return builder.Options;
    }
}