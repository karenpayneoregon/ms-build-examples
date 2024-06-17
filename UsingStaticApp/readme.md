# About

Shows how to setup global usings in the project file.

```xml
<ItemGroup>
   <!-- global usings -->
   <Using Include="System.Console" Static="True" />
   <Using Include="Spectre.Console.AnsiConsole" Alias="Console" />
   <Using Include="UsingLibrary.Helpers" Static="True" />
	<Using Include="System.DateTime" Static="True" />
</ItemGroup>
```
---

```csharp
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
```
