using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SonmezERP.Data;
using SonmezERP.Extensions;
using SonmezERP.Models;
var builder = WebApplication.CreateBuilder(args);
builder.Services.ConfigureDbContext(builder.Configuration);
builder.Services.ConfigureIdentity();
//builder.Services.ConfigureApplicationCookie(config =>
//{
//    config.LoginPath = "/Account";
//});

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

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

app.UseAuthorization();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();
app.ConfigureDefaultAdminUser();
app.Run();
