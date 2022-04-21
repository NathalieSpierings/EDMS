using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Promeetec.EDMS.Data.Context;
using Promeetec.EDMS.Domain.Models.Betrokkene.Medewerker;
using Promeetec.EDMS.Domain.Models.Identity.Role;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");


// Add Datacontext
builder.Services.AddDbContext<EDMSDbContext>(options => options.UseSqlServer(connectionString));


// Add Identity
builder.Services.AddIdentity<Medewerker, Role>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<EDMSDbContext>()
    .AddDefaultUI()
    .AddDefaultTokenProviders();


builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Admin", policy => policy.RequireRole("Admin"));
});

builder.Services.Configure<FormOptions>(x =>
{
    x.ValueLengthLimit = int.MaxValue;
    x.MultipartBodyLengthLimit = int.MaxValue;
});


var app = builder.Build();


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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
