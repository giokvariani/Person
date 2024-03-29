using BasePerson.API.Middlewares;
using BasePerson.Application.DTOs.City;
using BasePerson.Application.Interfaces;
using BasePerson.Application.Services;
using BasePerson.Persistence.DataLayer;
using BasePerson.Persistence.Repositories;
using BasePerson.Persistence.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


var services = builder.Services;
services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

services.AddMediatR(typeof(CityDto).Assembly);


var configuration = builder.Configuration;

var connectionString = configuration.GetConnectionString("ConnectionString");
services.AddDbContext<DataContext>(options => options.UseSqlServer(connectionString, b => b.MigrationsAssembly("BasePerson.API")));

services.AddScoped<ICityRepository, CityRepository>();
services.AddScoped<IPersonRepository, PersonRepository>();
services.AddScoped<IPhoneRepository, PhoneRepository>();
services.AddScoped<IConnectedPeopleRepository, ConnectedPeopleRepository>();
services.AddScoped<IPhone2PersonRepository, Phone2PersonRepository>();
services.AddScoped<IImageService, ImageService>();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandler>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
