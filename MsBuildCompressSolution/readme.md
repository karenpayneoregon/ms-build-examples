## ZipDirectory task

Creates a .zip archive from the contents of a directory.

> **Warning**
> In the project file, the following is commented out. To test, uncomment and change DestinationFile path then rebuild. 


```xml
<Target Name="ZipOutputPath" BeforeTargets="Build">
       <Message
           Text="Creating .zip for $(SolutionDir)"
           Importance="High" />

        <ZipDirectory
            SourceDirectory="$(SolutionDir)"
            DestinationFile="C:\OED\Zipped\$(SolutionName).zip"
			Overwrite="true" />
</Target>
```
