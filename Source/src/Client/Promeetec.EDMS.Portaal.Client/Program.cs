using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Promeetec.EDMS.Portaal.Core.Extensions;
using Promeetec.EDMS.Portaal.Data.Context;
using Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Medewerker;
using Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Organisatie;
using Promeetec.EDMS.Portaal.Domain.Models.Identity.Role;
using Promeetec.EDMS.Portaal.Domain.Models.Identity.Users;
using ObjectFactory = Promeetec.EDMS.Portaal.Core.Mapping.ObjectFactory;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") 
                       ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

// Add Datacontext
builder.Services.AddDbContext<EDMSDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// Add Identity
builder.Services.AddIdentity<Medewerker, Role>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<EDMSDbContext>()
    .AddDefaultUI()
    .AddDefaultTokenProviders();

// Add custom claims to user
builder.Services.AddScoped<IClaimsTransformation, UserClaimsTransformation>();



builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Admin", policy => policy.RequireRole("Admin"));
});

builder.Services.Configure<FormOptions>(x =>
{
    x.ValueLengthLimit = int.MaxValue;
    x.MultipartBodyLengthLimit = int.MaxValue;
});

builder.Services.AddAutoMapper(new List<Type> { typeof(ObjectFactory) });

//builder.Services.AddAutoMapper(typeof(Promeetec.EDMS.Mapping.ObjectFactory));
builder.Services.Scan(s => s
    .FromAssembliesOf(typeof(ObjectFactory), typeof(Program), typeof(EDMSDbContext), typeof(Organisatie))
    .AddClasses()
    .AsImplementedInterfaces()
);





//builder.Services.AddIdentityServer().AddApiAuthorization<Medewerker, EDMSDbContext>();
//builder.Services.AddAuthentication().AddIdentityServerJwt();

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseIdentityServer();
app.UseAuthorization();

app.UseEndpoints(endpoints => { endpoints.MapControllerRoute(name: "areas", pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"); });

app.MapControllerRoute(name: "default", pattern: "{controller}/{action=Index}/{id?}");

app.MapRazorPages();

app.MapFallbackToFile("index.html");

app.Run();
