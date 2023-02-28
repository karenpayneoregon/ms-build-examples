# Hiding path for runtime exceptions

![Title](assets/title.png)

When an unhandled or handled (using try-catch) exception is thrown in an application usually the exception is sent to a log file and may display the exception during development in Visual Studio output window or if working with a console application display in the console window.

When inspecting an exception in a log file for the stack trace we see not only the location of the exception but the full path too, as shown in figure 1. If seeing the full path is annoying than there is a solution that when implemented will appear as in figure 2.


From Solution Explorer, double click on your project, add the following and save

```csharp
<PropertyGroup>
   <PathMap>$([System.IO.Path]::GetFullPath('$(MSBuildThisFileDirectory)'))=./</PathMap>
</PropertyGroup>
```

Run, inspect and note no path. Rather than write code I've supplied one project `ShowPathInException` which shows full paths while `HidePathInExceptions` does not show the full path.

Note that both use [Serilog](https://serilog.net/) to log exceptions to each project's Debug folder.



## Figure 1

![a](assets/WithPath.png)

</br>

## Figure 2

![b](assets/WithoutPath.png)

# Running the code

Run NorthScript.sql to create and populate a database used in both projects.

# Working from a solution 

If there are many projects consider the following.

Create a file named [Directory.Build.props](https://docs.microsoft.com/en-us/visualstudio/msbuild/customize-your-build?view=vs-2019#directorybuildprops-example) in the root path of a Visual Studio solution with the following will remove paths from eror messages in all projects.

```xml
<Project>
   <PropertyGroup>
      <PathMap>$(MSBuildProjectDirectory)=$(MSBuildProjectName)</PathMap>
   </PropertyGroup>
</Project>
```

# Code samples

~~Written with .NET Core 6~~

Writtem with EF Core 7


# Runtime exception used

Using NuGet package `Microsoft.Data.SqlClient` 5 and above assumes encryption.

Using a standard connection string shown below will fail as in code.

```
Data Source=.\\SQLEXPRESS;Initial Catalog=NorthWind2022;integrated security=True;
```

A quick fix is to use the following.

```
Data Source=.\\SQLEXPRESS;Initial Catalog=NorthWind2022;integrated security=True;Encrypt=False
```

**From Microsoft docs on** `Encrypt`

When `true`, SQL Server uses SSL encryption for all data sent between the client and server if the server has a certificate installed. Recognized values are `true`, `false`, `yes`, and `no`. For more information, see [Connection String Syntax](https://docs.microsoft.com/en-us/dotnet/framework/data/adonet/connection-string-syntax).

Beginning in .NET Framework 4.5, when `TrustServerCertificate` is false and `Encrypt` is true, the server name (or IP address) in a SQL Server SSL certificate must exactly match the server name (or IP address) specified in the connection string. Otherwise, the connection attempt will fail.



