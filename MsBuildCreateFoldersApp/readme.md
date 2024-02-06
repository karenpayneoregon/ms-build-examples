# About

In the .csproj file, shows how to create folders with today's date. One has dashes and one a period for date separators.

Think of getting the first to work then thinking what can I do to improve it? That is what the second one does, condenses everything down to using a date format for one variable.


```xml
<Project Sdk="Microsoft.NET.Sdk.Web">

	<PropertyGroup>
		<TargetFramework>net8.0</TargetFramework>
		<Nullable>enable</Nullable>
		<ImplicitUsings>enable</ImplicitUsings>
	</PropertyGroup>


	<PropertyGroup>
		<CurrentYear>$([System.DateTime]::Now.Year)</CurrentYear>
		<CurrentMonth>$([System.DateTime]::Now.Month)</CurrentMonth>
		<CurrentDay>$([System.DateTime]::Now.Day)</CurrentDay>
	</PropertyGroup>
	
	<Target Name="MakeLogDir" AfterTargets="Build">
		<MakeDir Directories="$(OutDir)Files\$(CurrentYear)-$(CurrentMonth)-$(CurrentDay)" />
	</Target>

	<PropertyGroup>
		<CurrentDate>$([System.DateTime]::Now.ToString(yyyy.MM.dd))</CurrentDate>
	</PropertyGroup>
	<Target Name="MakeLogDirChrisCarroll" AfterTargets="Build">
		<MakeDir Directories="$(OutDir)Files1\$(CurrentDate)" />
	</Target>

</Project>



```