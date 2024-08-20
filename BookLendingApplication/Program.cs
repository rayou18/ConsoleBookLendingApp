using AlbumsIntegration.Clients;
using AlbumsIntegration.Service;
using BookLendingApplication.Dtos;
using BookLendingApplication.Mappers;
using BookLendingApplication.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

builder.Services.AddScoped<IAlbumsService, AlbumsService>();
builder.Services.AddScoped<IAlbumsClient, AlbumsClient>();
builder.Services.AddScoped<IBookLendingService, BookLendingService>();
builder.Services.AddScoped<IConsoleService, ConsoleService>();
builder.Services.AddSingleton<IMapper<AlbumsIntegration.Dtos.Book, Book>, BookMapper>();


using IHost host = builder.Build();

var console = host.Services.GetRequiredService<IConsoleService>();

await console.RunAsync();

await host.RunAsync();
