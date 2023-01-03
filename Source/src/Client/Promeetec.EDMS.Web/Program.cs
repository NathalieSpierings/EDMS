using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Promeetec.EDMS.Data.Context;
using Promeetec.EDMS.Domain.Models.Betrokkene.Medewerker;
using Promeetec.EDMS.Domain.Models.Betrokkene.Organisatie;
using Promeetec.EDMS.Domain.Models.Identity.Role;
using Promeetec.EDMS.Domain.Models.Identity.Users;
using Promeetec.EDMS.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();


// Add Datacontext
builder.Services.AddDbContext<EDMSDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

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

builder.Services.AddAutoMapper(new List<Type> { typeof(Promeetec.EDMS.Mapping.ObjectFactory) });

//builder.Services.AddAutoMapper(typeof(Promeetec.EDMS.Mapping.ObjectFactory));
builder.Services.Scan(s => s
    .FromAssembliesOf(typeof(Promeetec.EDMS.Mapping.ObjectFactory), typeof(Program), typeof(EDMSDbContext), typeof(Organisatie))
    .AddClasses()
    .AsImplementedInterfaces()
);

var app = builder.Build();

app.MapRazorPages();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "areas",
        pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
