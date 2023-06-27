using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using PRJ.API.Installers;
using PRJ.DataAccess.Context;
using PRJ.Repository.Repositories;
using PRJ.Repository.UnitOfWorks;
using PRJ.Service.AutoMapper;
using PRJ.Service.Services.UserServices;
using PRJ.Utility;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.InstallServiceAssembly(builder.Configuration);

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthorization();



app.MapControllerRoute(
	name: "default",
	pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
