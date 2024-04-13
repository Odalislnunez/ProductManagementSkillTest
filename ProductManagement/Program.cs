using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProductManagement.Areas.Identity;
using ProductManagement.Core.Models;
using ProductManagement.Core.Persistences;
using ProductManagement.Core.Services;
using ProductManagement.Core.Services.Interfaces;
using System;

var builder = WebApplication.CreateBuilder(args);

Bold.Licensing.BoldLicenseProvider.RegisterLicense("KJNcD0HjKwHPEkh7KUezvalDYNZvlcQ2dO1QgXJCpIA=");

builder.Services.AddDbContext<PMDbContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("DbContextConnection"), migration => migration.MigrationsAssembly("ProductManagement.Core"));
});

// Add services to the container.
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<PMDbContext>();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();
builder.Services.AddTransient<IGeneridCrudService<Customer>, CustomerService>();
builder.Services.AddTransient<IGeneridCrudExtService<Item>, ItemService>();
builder.Services.AddTransient<IGeneridCrudExt2Service<CustomerItem>, CustomerItemService>();
builder.Services.AddBlazorBootstrap();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

using (var scope = app.Services.CreateScope())
{
    var _Db = scope.ServiceProvider.GetRequiredService<PMDbContext>();
    if (_Db != null)
    {
        if (_Db.Database.GetPendingMigrations().Any())
        {
            _Db.Database.Migrate();
        }
    }
}

app.Run();
