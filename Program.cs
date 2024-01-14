using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore.Extensions;
using ococ.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddEntityFrameworkMySQL().AddDbContext<QuanLyChuyenBayContext>(options =>
{
    options.UseMySQL("Server=127.0.0.1;User ID=root;Password=anhyeuem;Port=3306;Database=quanlychuyenbay");
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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
