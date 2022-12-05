# Using MS-Build to create folders and copy files to a location 

Like in the project `MsBuildWorkingDirApp` there may be a need to have a place to perform work outside of the application executable folder, in this case create folders and copy folders from the project folder to the specified location. The only limitations is, empty folders will not be copied.

## In the project file

These are the folders to copy. Folder1 will not be copied as there are no files in the folder while Folder2 will be created and the file under it will be copied.

```xml
<ItemGroup>
    <Folder Include="Templates\Folder1\" />
    <Folder Include="Templates\Folder2\" />
</ItemGroup>
```

Next, setup instructions to copy the files after a successful build

```xml
<Target Name="CopyFiles" AfterTargets="Build">
    <ItemGroup>
        <!-- Because this ItemGroup is inside the target, this will enumerate
             all files just before calling Copy. If the ItemGroup were outside
             the target , it would enumerate the files during evaluation, before
             the build starts, which may miss files created during the build. -->
        <MySourceFiles Include="$(ProjectDir)\Templates\**\*.*" />
    </ItemGroup>

    <Copy SourceFiles="@(MySourceFiles)" DestinationFolder="c:\Work\MsDemo\%(RecursiveDir)" />
</Target>
```

# References

- Microsoft docs 
- [Copy task](https://learn.microsoft.com/en-us/visualstudio/msbuild/copy-task?view=vs-2022)
- [File globbing in .NET](https://learn.microsoft.com/en-us/dotnet/core/extensions/file-globbing)

