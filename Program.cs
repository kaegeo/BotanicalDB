using BotanicalDB.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddMemoryCache();
builder.Services.AddSession();

builder.Services.AddDbContext<FowlerPlantContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("PlantContext")
    ));

// Add Identity services with password requirement options
builder.Services.AddIdentity<IdentityUser, IdentityRole>(
    options =>
    {
        options.Password.RequiredLength = 6;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireDigit = false;
        options.Password.RequireLowercase = false;
        options.Password.RequireUppercase = false;
    }
    )
    .AddEntityFrameworkStores<FowlerPlantContext>()
    .AddDefaultTokenProviders();

builder.Services.AddRouting(options =>
{
    options.LowercaseUrls = true;
    options.AppendTrailingSlash = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession();

app.UseAuthentication();

app.UseAuthorization();

// Mapping for routing setup
app.MapControllers();

// Mapping for Admin area routing
app.MapAreaControllerRoute(
    name: "admin",
    areaName: "Admin",
    pattern: "{area}/{controller=Home}/{action=Index}/{id?}");

// Unused four_segment mapping
app.MapControllerRoute(
    name: "four_segment",
    pattern: "{controller}/asdf/morerandom/{action}");

// Mapping for default area routing
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

var scopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();

using (var scope = scopeFactory.CreateScope())
{
    await SetupAdmin.CreateAdminAsync(scope.ServiceProvider);
}

app.Run();
