## Working with the using directive in C#


## Microsoft documentation

The [using directive](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/using-directive) allows you to use types defined in a namespace without specifying the fully qualified namespace of that type. In its basic form, the using directive imports all the types from a single namespace, as shown in the following example:

```csharp
using System.Text;
```

You can apply two modifiers to a using directive:

- The `global` modifier has the same effect as adding the same using directive to every source file in your project. This modifier was introduced in C# 10.
- The `static` modifier imports the static members and nested types from a single type rather than importing all the types in a namespace.

You can combine both modifiers to import the static members from a type in all source files in your project.

You can also create an alias for a namespace or a type with a *using alias* directive.

```csharp
using Project = PC.MyCompany.Project;
```

## MSBuild project file (Using)

Another way to use the using directive is in a project file as shown below, taken from this project.

```xml
<ItemGroup>
    <ProjectReference Include="..\SqlServerLibrary\SqlServerLibrary.csproj" />
</ItemGroup>
```

You can also use the `Using` item to define `global using <alias>` and `using static <type>` directives.

Now knowing this, we can use this with an `alias`, in this case because there is a class named `DataTable` and we also want to use `System.Data.Common.DataTable` throughout several classes in the current project. We could use an Using directive in each class but using the following to use DataTable class from the `SqlServerLibrary` project simply prefix with `SLD`.

```xml
<ItemGroup>
    <Using Include="SqlServerLibrary.DataHelpers" Alias="SLD" />
</ItemGroup>
```

Usage

```csharp
SLM.DataTable dataTable1 = new SLM.DataTable
```

Then to use a System.Data, DataTable add a Using directive.

```csharp
using System.Data;
```

Sample code

```csharp
SLM.DataTable dataTable1 = new SLM.DataTable
{
    CaseSensitive = true,
    Stash = "secret stuff"
};

Console.WriteLine($"{dataTable1.Stash, -16}{dataTable1.CaseSensitive}");

/*
* System.Data.DataTable
*/
DataTable dataTable2 = new DataTable();
dataTable2.CaseSensitive = true;
Console.WriteLine(dataTable2.CaseSensitive);
```

Suppose a developer encounters issues like above with DataTable in more than one project.

Create a new text file in the project named `Directory.Build.props`. Then setup up as follows which works the same as having the `Using Include` in the project file.

```xml
<Project>
    <ItemGroup>
        <Using Include="SqlServerLibrary.DataHelpers" Alias="SLD" />
    </ItemGroup>
</Project>
```

Copy the above file to other projects which can now use the alias `SLD`.

If the above technique is not for you than add a conventional Using directive with an alias to the top of a class.

```csharp
using SLD = SqlServerLibrary.DataHelpers;
```

## static modifier

From Microsoft [docs](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/using-directive#static-modifier)

The using static directive names a type whose static members and nested types you can access without specifying a type name. Its syntax is:

```csharp
using static <fully-qualified-type-name>;
```

The `<fully-qualified-type-name>` is the name of the type whose static members and nested types can be referenced without specifying a type name. If you don't provide a fully qualified type name (the full namespace name along with the type name), C# generates compiler error CS0246: "The type or namespace name 'type/namespace' couldn't be found (are you missing a using directive or an assembly reference?)".

The using static directive applies to any type that has static members (or nested types), even if it also has instance members. However, instance members can only be invoked through the type instance.

---

There are two obvious uses

- The Console class: `using static System.Console;` which means instead of typing `Console.ReadLine` simply type `ReadLine`
- `System.DateTime`, rather than typing DateTime.Now with `using static System.DateTime;` type Now.

Another example which keeps code clean and easy to understand.

```csharp
using static System.Globalization.DateTimeFormatInfo;

namespace MSBuildUsingExampleApp.Classes;
internal class DateTimeHelpers
{
    public static List<string> MonthNames()
        => CurrentInfo!.MonthNames[..^1].ToList();
}
```

The downsides to `using static` is when code becomes difficult to read/understand were methods comes from and if that becomes the case revert back to a standard using directive or with an [alias](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/using-directive#using-alias) e.g.

```csharp
using C = System.Console;
...
C.WriteLine(...
```

Or we can use the following in a project file to eliminate the using directive for `System.Console`.


```csharp
<ItemGroup>
    <Using Include="System.Console" Static="True" />
</ItemGroup>
```

## Project code

- There are plenty of comments
- `SqlServerLibrary` checks the existence of a SQL-Server database for SQLEXPRESS which is not installed will raise an exception.


# Source code

Clone the following GitHub [repository](https://github.com/karenpayneoregon/ms-build-examples) and work with the project [MSBuildUsingExampleApp](https://github.com/karenpayneoregon/ms-build-examples/tree/master/MSBuildUsingExampleApp).

Coded with Microsoft Visual Studio 2022, .NET Core 7.



## See also

- [global modifier](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/using-directive#global-modifier)
- [extern alias](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/extern-alias)






