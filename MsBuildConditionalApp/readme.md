# About

To ensure that each developer in a team working on a project creates log files for instance in the same folder without needing to create the folder we use MSBuild to create the folder. Besides this we only want to create the folder when building to debug, not release. The following checks if the project is set for debug and if so creates the folder, otherwise no action is taken.

```xml
<Target Name="MakeLogDir" AfterTargets="Build">
   <MakeDir Directories="$(OutDir)LogFiles\$([System.DateTime]::Now.ToString(yyyy-MM-dd))"
		    Condition="'$(Configuration)' == 'Debug'" />
</Target>
```