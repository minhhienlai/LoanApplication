using Microsoft.EntityFrameworkCore;
using SharedClassLibrary.Data;
using SharedClassLibrary.Models;
using SharedClassLibrary.Repositories;
using SharedClassLibrary.Repositories.Interface;

var builder = WebApplication.CreateBuilder(args);
string connectionString = builder.Configuration.GetConnectionString("LoanAppMVCContext");

// Add services to the container.
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("LoanAppMVCContext"), b => b.MigrationsAssembly("LoanAppMVC")));

builder.Services.AddControllers();
builder.Services.AddScoped<IUnitOfWork,UnitOfWork>();
builder.Services.AddScoped<IGenericRepository<BusinessModel>,GenericRepository<BusinessModel>>();
builder.Services.AddScoped<IGenericRepository<DemographicModel>,GenericRepository<DemographicModel>>();
builder.Services.AddScoped<IGenericRepository<LoanAppModel>,GenericRepository<LoanAppModel>>();
builder.Services.AddScoped<IListRepository, ListRepository>();
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

Task.Run(() =>
{
    DbContextOptionsBuilder builder1 = new DbContextOptionsBuilder();
    builder1.UseSqlServer(connectionString);
    var unitOfWork = new UnitOfWork(new DataContext(builder1.Options));
    unitOfWork.SeedData();
});

app.Run();