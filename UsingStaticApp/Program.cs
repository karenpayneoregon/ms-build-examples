using UsingLibrary;


namespace UsingStaticApp;

internal class Program
{
    private static void Main()
    {
        Console.MarkupLine($"[green]{Now:hh:mm:ss}[/]");
        Console.MarkupLine($"[cyan]New value[/]{Helpers.NextValue("ASD1")}");
        Console.MarkupLine("Press a key to exits");
        ReadLine();
    }
}
