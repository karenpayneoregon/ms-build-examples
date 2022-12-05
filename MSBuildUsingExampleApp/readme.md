# Define aliases for class references 

This project shows how to create [using directives](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/using-directive) using MS-Build [Item](https://learn.microsoft.com/en-us/dotnet/core/project-sdk/msbuild-props#using).


One reason is to prevent a ambiguous reference, for instance, a developer has a class named DataTable and needs to use the .NET Framework [DataTable](https://learn.microsoft.com/en-us/dotnet/api/system.data.datatable?view=net-7.0) class.

In this case the user defined DataTable class is defined in the project `SqlServerLibrary` under the folder `Models`.

We add a reference to this project for `SqlServerLibrary`

```xml
<ItemGroup>
    <ProjectReference Include="..\SqlServerLibrary\SqlServerLibrary.csproj" />
</ItemGroup>
```

Next add the alias

```xml
<ItemGroup>
    <Using Include="SqlServerLibrary.Models" Alias="SLM" />
</ItemGroup>
```

In code we can point to the DataTable class from SqlServerLibrary.Models.DataTable

```csharp
SLM.DataTable dataTable1 = new SLM.DataTable
{
    CaseSensitive = true,
    Stash = "secret stuff"
};
```

Then for System.Data.DataTable

```csharp
var dataTable2 = new DataTable();
dataTable2.CaseSensitive = true;
```



