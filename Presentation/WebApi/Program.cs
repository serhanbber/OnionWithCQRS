using Application.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Persistence.Helper;
using Persistence.Repositories;
using Persistence;
using Application;
using Mapper;
using Application.Exceptions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddDbContext<ApllicationDbContext>(o => o.UseSqlServer(ConnectionString.GetConnectionString("localhost", "OnionCQRS", "sero", "Sero1529")));
//builder.Services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
//builder.Services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddApplication();
builder.Services.AddCustomMapper();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.ConfigureExceptionHandlingMiddlaware();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
