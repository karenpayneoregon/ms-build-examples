using System.Runtime.CompilerServices;

namespace HelperLibrary;

public class Helpers
{
    public static void PrintSampleName([CallerMemberName] string? methodName = null)
    {
        AnsiConsole.MarkupLine($"[cyan]Sample:[/] [white]{methodName}[/]");
        Console.WriteLine();
    }
}