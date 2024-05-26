using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SonmezERP.Data;
using SonmezERP.Extensions;
using SonmezERP.Models;
var builder = WebApplication.CreateBuilder(args);

//EntityFrameWorkCore Configuration Settings(for database )
builder.Services.ConfigureDbContext(builder.Configuration);

//Identity configuration
builder.Services.ConfigureIdentity();
//builder.Services.ConfigureApplicationCookie(config =>
//{
//    config.LoginPath = "/Account";
//});

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddAutoMapper(typeof(Program));
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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();
app.ConfigureDefaultAdminUser();
app.Run();
