using Microsoft.AspNetCore.Hosting;
using ScanResultAPI.Controllers;
using ScanResultAPI.DTO;
using ScanResultAPI.Services;
using ScanResultAPI.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IScanInfoService, ScanInfoService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();