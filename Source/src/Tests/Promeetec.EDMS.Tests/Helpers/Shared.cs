﻿using Microsoft.EntityFrameworkCore;
using Promeetec.EDMS.Data.Context;

namespace Promeetec.EDMS.Tests.Helpers;

public static class Shared
{
    public static DbContextOptions<EDMSDbContext> CreateContextOptions()
    {
        var builder = new DbContextOptionsBuilder<EDMSDbContext>();
        builder.UseInMemoryDatabase("EDMS");
        return builder.Options;
    }
}