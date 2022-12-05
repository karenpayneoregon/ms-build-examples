using System.Runtime.CompilerServices;
using W = ConsoleHelperLibrary.Classes.WindowUtility;

// ReSharper disable once CheckNamespace
namespace MSBuildUsingExampleApp;

internal partial class Program
{
    [ModuleInitializer]
    public static void Init()
    {

        Console.Title = "Code sample";
        W.SetConsoleWindowPosition(W.AnchorWindow.Center);

        AnsiConsole.Write(
            new Panel(new Text("MS-Build using directives").Centered())
                .Expand()
                .SquareBorder()
                .BorderStyle(new Style(Color.DarkViolet))
                .Header("[white on DarkViolet]About[/]")
                .HeaderAlignment(Justify.Center));
    }
}