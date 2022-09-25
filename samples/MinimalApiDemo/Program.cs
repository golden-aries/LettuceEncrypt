// Copyright (c) Nate McMaster.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
using LettuceEncrypt;
using LettuceEncrypt.Accounts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MinimalApiDemo;
using static System.Environment;

var builder = WebApplication.CreateBuilder(args);

var options = builder.Configuration
    .GetSection(nameof(FileSystemStoreOptions))
    .Get<FileSystemStoreOptions>((binderOptions) =>
    {
        binderOptions.ErrorOnUnknownConfiguration = true;
    });

options.ValidateAndTransform();

builder.Services
        .AddLettuceEncrypt()
        .PersistDataToDirectory(new DirectoryInfo(options.Path!), options.Password!);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

var opts = app.Services.GetRequiredService<IOptions<LettuceEncryptOptions>>();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateTime.Now.AddDays(index),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");

app.Run();

public record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
