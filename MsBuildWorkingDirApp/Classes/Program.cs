using System.Runtime.CompilerServices;
using Spectre.Console;
using SqlLiteLibrary.Data;
using SqlLiteLibrary.Models;
using W = ConsoleHelperLibrary.Classes.WindowUtility;

// ReSharper disable once CheckNamespace
namespace MsBuildWorkingDirApp;

partial class Program
{
        
    [ModuleInitializer]
    public static void Init()
    {
        Console.Title = "Code sample";

        W.SetConsoleWindowPosition(W.AnchorWindow.Center);

        AnsiConsole.Write(
            new Panel(new Text("MS-Build working folder example").Centered())
                .Expand()
                .SquareBorder()
                .BorderStyle(new Style(Color.DarkViolet))
                .Header("[white on DarkViolet]About[/]")
                .HeaderAlignment(Justify.Center));
    }

    /// <summary>
    /// Create a new database, file name is OnConfiguring in the DbContext <see cref="Context"/>
    /// </summary>
    private static void BuildData(Context context)
    {
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();

        context.FileContainers.Add(new FileContainer() { Path1 = "A1", Path2 = "A2", Path3 = "A3" });
        context.FileContainers.Add(new FileContainer() { Path1 = "B1", Path2 = "B2", Path3 = "B3" });
        context.FileContainers.Add(new FileContainer() { Path1 = "C1", Path2 = "C2", Path3 = "C3" });

        context.SaveChanges();
    }

    /// <summary>
    /// Update a record by key
    /// </summary>
    private static void UpdateOneRecord1(Context context)
    {
        var item = context.FileContainers.FirstOrDefault(x => x.Id == 2);
        Console.WriteLine();
        item!.Path1 = "New path";
        context.SaveChanges();
    }

    /// <summary>
    /// Update a record by Path3
    /// </summary>
    private static void UpdateOneRecord2(Context context)
    {
        var item = context.FileContainers.FirstOrDefault(x => x.Path3 == "C3");
        Console.WriteLine();
        item!.Path3 = "New path";
        context.SaveChanges();
    }

    /// <summary>
    /// Display records generated above
    /// </summary>
    /// <param name="context"></param>
    private static void ShowData(Context context)
    {
        Console.WriteLine();
        var items = context.FileContainers.ToList();
        foreach (var container in items)
        {
            Console.WriteLine($"{container.Id,-3}{container.Path1,-20}{container.Path2,-13}{container.Path3,-13}");
        }
    }

}