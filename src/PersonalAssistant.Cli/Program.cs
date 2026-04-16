using Microsoft.Extensions.DependencyInjection;
using PersonalAssistant.Application;
using PersonalAssistant.Cli;
using PersonalAssistant.Infrastructure;

var services = new ServiceCollection()
    .AddApplication()
    .AddInfrastructure()
    .AddCli()
    .BuildServiceProvider();

var loop = services.GetRequiredService<CommandLoop>();
await loop.RunAsync();
