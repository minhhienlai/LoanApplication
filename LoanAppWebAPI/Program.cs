using LoanAppWebAPI.Data;
using LoanAppWebAPI.Repositories;
using LoanAppWebAPI.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
string connectionString = builder.Configuration.GetConnectionString("LoanAppMVCContext");

// Add services to the container.
builder.Services.AddDbContext<APIDataContext>();

builder.Services.AddControllers();
builder.Services.AddScoped<IUnitOfWork,UnitOfWork>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//Uncomment this to seed data
//Task.Run(() =>
//{
//    var unitOfWork = new UnitOfWork(new APIDataContext());
//    unitOfWork.SeedData();
//});

app.Run();