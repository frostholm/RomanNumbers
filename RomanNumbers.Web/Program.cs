using FluentValidation;
using RomanNumbers.Application.Behaviors.ValidationBehavior;
using RomanNumbers.Application.Infrastructure;
using RomanNumbers.Application.Services;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddSingleton<IRomanNumeralConverterService, RomanNumeralConverterService>();
builder.Services.AddValidatorsFromAssembly(typeof(DoNotDelete).Assembly);


builder.Services.AddMediatR(cfg => {
    cfg.RegisterServicesFromAssembly(typeof(DoNotDelete).Assembly);
    cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));
});

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

app.Run();
