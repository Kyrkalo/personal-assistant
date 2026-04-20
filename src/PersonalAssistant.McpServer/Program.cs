using PersonalAssistant.Application;
using PersonalAssistant.Infrastructure;
using PersonalAssistant.McpServer;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddApplication()
    .AddInfrastructure();

builder.Services
    .AddMcpServer()
    .WithHttpTransport(o => o.Stateless = true)
    .WithTools<CalendarMcpTools>();

var app = builder.Build();

app.MapMcp("/mcp");

await app.RunAsync();
