using Microsoft.EntityFrameworkCore;
using ProductManagement.Core.Models;
using ProductManagement.Core.Persistences;
using ProductManagement.Core.Services;
using ProductManagement.Core.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

Bold.Licensing.BoldLicenseProvider.RegisterLicense("KJNcD0HjKwHPEkh7KUezvalDYNZvlcQ2dO1QgXJCpIA=");

builder.Services.AddDbContext<PMDbContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("DbContextConnection"), migration => migration.MigrationsAssembly("ProductManagement.Core"));
});

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddTransient<IGeneridCrudService<Customer>, CustomerService>();
builder.Services.AddTransient<IGeneridCrudExtService<Item>, ItemService>();
builder.Services.AddTransient<IGeneridCrudExtService<CustomerItem>, CustomerItemService>();
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

app.MapControllers();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
app.UseAuthentication();;

app.Run();
