﻿using LoanAppMVC.Models;
using LoanAppMVC.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SharedClassLibrary.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

string connectionString = builder.Configuration.GetConnectionString("LoanAppMVCContext");

//builder.Services.AddDbContext<DataContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("LoanAppMVCContext"),b => b.MigrationsAssembly("LoanAppMVC")));
//DomainRegister.Instance
//    .Register<Demographic>("Demographics")
//    .Register<BusinessModel>("Businesses")
//    .Register<LoanAppModel>("LoanApps")
//    .Build();

//builder.Services.AddDbContext<DataContext>(options =>
//    options.UseSqlServer(connectionString));//, b => b.MigrationsAssembly("LoanAppMVC")));

builder.Services.AddHttpClient<IHttpClientService, LoanAppWebApiService>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration.GetValue<string>("baseApiUri"));
});
// Add services to the container.
builder.Services.AddControllersWithViews();

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
    pattern: "{controller=Demographic}/{action=Index}/{id?}");

app.Run();
