using HelperLibrary;
using Spectre.Console;
using SqlLiteLibrary.Data;

namespace MsBuildWorkingDirApp;

internal partial class Program
{
    /// <summary>
    /// Write a file to WorkFolder property in the project file
    /// </summary>
    /// <param name="args"></param>
    static void Main(string[] args)
    {
        FileWriteSample();
        EntityFrameworkCoreSample();
        Console.ReadLine();
    }

    /// <summary>
    /// Write a file to the working folder specified in the project file
    /// </summary>
    private static void FileWriteSample()
    {
        Helpers.PrintSampleName();

        AnsiConsole.MarkupLine($"[white]   Working folder:[/] [cyan]{Environment.CurrentDirectory}[/]");
        AnsiConsole.MarkupLine($"[white]Executable folder:[/] [cyan]{AppDomain.CurrentDomain.BaseDirectory}[/]");

        File.WriteAllText("test.txt", "hello");

        AnsiConsole.MarkupLine($"  [white]test.txt exists?[/] [cyan]{File.Exists(Path.Combine(Environment.CurrentDirectory, "test.txt"))}[/]");

        Console.WriteLine();
    }

    /// <summary>
    /// Create and populate a database specified in the project file
    /// </summary>
    private static void EntityFrameworkCoreSample()
    {

        Helpers.PrintSampleName();

        using var context = new Context();
        BuildData(context);
        ShowData(context);

        UpdateOneRecord1(context);
        UpdateOneRecord2(context);

        ShowData(context);
    }
}