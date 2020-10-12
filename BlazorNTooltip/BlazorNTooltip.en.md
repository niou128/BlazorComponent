[![License](https://img.shields.io/github/license/BlazorExtensions/Storage.svg?longCache=true&style=flat-square)](LICENSE)
[![Package Version](https://img.shields.io/badge/nuget-v1.0.0-blue.svg?longCache=true&style=flat-square)](https://www.nuget.org/packages/BlazorNTooltip/)

[Lire en français](BlazorNTooltip.md)

# BlazorDatagrid

A tooltip component for Blazor

# Nuget Gallery
The Nuget package page can be found at https://www.nuget.org/packages/BlazorNTooltip/

# Installation

To install BlazorNTooltip using Package Manager run the following command
```
Install-Package BlazorNTooltip -Version 1.0.0
```
To install BlazorNTooltip using .NET CLI run the following command
```
dotnet add package BlazorNTooltip --version 1.0.0
```

After you have installed the package add the following line in the ```_Imports.razor``` file
```
@using BlazorNTooltip
```

# Parameters

The ```<Tooltip>``` component accepts following parameters:
-	**Text** : Tooltip content
-	**Position** : Tooltip position. To be chosen from one of the following 4 (top is default position) :
    - top
    - bottom
    - right
    - left


# Example of use:

```
Welcome to your new <Tooltip Text="Wonderful tooltip!" Position="right">app</Tooltip>.
```

# Aperçu
Soon.

___
**[Release Notes](BlazorNTooltip_RELEASE_NOTE.en.md)** 
