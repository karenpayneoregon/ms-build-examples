# Various examples for MS-Build Task for Visual Studio

Provides examples for MS-Build task that are not what most developers are aware of and can assist in daily coding task. What is presented is just the tip of possiblities which can be accomplished with MS-Build.

| Project        |   Description    | 
|:------------- |:-------------|
| MsBuildWorkingDirApp | Shows how to set a project working folder |  
| SqlLiteLibrary | Companion project for MsBuildWorkingDirApp |  
| MSBuildUsingExampleApp | Shows how to use using `directive` aliases |  
| SqlServerLibrary | Companion project for MSBuildUsingExampleApp |  
| MSBuildCopyFiles | Example for copying folders and files to a working folder |  
| MsBuildVersioningApp | Versioning .NET Core project using `Directory.Build.props` |  

# References

Microsoft docs 

- [MSBuild reference for .NET SDK projects](https://learn.microsoft.com/en-us/dotnet/core/project-sdk/msbuild-props#using)
- [MSBuild task reference](https://learn.microsoft.com/en-us/visualstudio/msbuild/msbuild-task-reference?view=vs-2022)
- [MSBuild concepts](https://learn.microsoft.com/en-us/visualstudio/msbuild/msbuild-concepts?view=vs-2022)
- [using directive](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/using-directive)
- [Customize your build](https://learn.microsoft.com/en-us/visualstudio/msbuild/customize-your-build?view=vs-2022) MSBuild projects that use the standard build process (importing Microsoft.Common.props and Microsoft.Common.targets) have several extensibility hooks that you can use to customize your build process.

# Requires

- Microsoft Visual Studio 2022 or higher