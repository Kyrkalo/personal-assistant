using PersonalAssistant.Core.Abstractions;

namespace PersonalAssistant.Cli;

public class CommandLoop
{
    private readonly IAssistantService _assistant;

    public CommandLoop(IAssistantService assistant)
    {
        _assistant = assistant;
    }

    public async Task RunAsync(CancellationToken cancellationToken = default)
    {
        Console.WriteLine("Personal Assistant ready. Type 'help' for commands, 'exit' to quit.");
        Console.WriteLine();

        while (!cancellationToken.IsCancellationRequested)
        {
            Console.Write("> ");
            var input = Console.ReadLine();

            if (input is null || input.Equals("exit", StringComparison.OrdinalIgnoreCase))
                break;

            var response = await _assistant.HandleAsync(input, cancellationToken);
            Console.WriteLine(response);
            Console.WriteLine();
        }
    }
}
