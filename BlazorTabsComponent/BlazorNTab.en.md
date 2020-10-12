[![License](https://img.shields.io/github/license/BlazorExtensions/Storage.svg?longCache=true&style=flat-square)](LICENSE)
[![Package Version](https://img.shields.io/badge/nuget-v1.4.0-blue.svg?longCache=true&style=flat-square)](https://www.nuget.org/packages/BlazorTabs/)

[Lire en français](BlazorNTab.md)

# BlazorNTab

Tab component for Blazor

# Nuget Gallery
The Nuget package page can be found at https://www.nuget.org/packages/BlazorTabs/

# Installation

To install BlazorDataGrid using Package Manager run the following command 
```
Install-Package BlazorTabs -Version 1.4.0
```
To install BlazorDataGrid using .NET CLI run the following command
```
dotnet add package BlazorTabs --version 1.4.0
```

After you have installed the package add the following line in the ```_Imports.razor``` file
```
@using BlazorTabsComponent
```

# Paramètres  

The ```<Tab>``` component accepts following parameters:
-	**Title** : tab title

It is possible to define a more complex title with styles by placing it in the tag ```<TabHeader>``` then place the content in the tag ```<ChildContent>```


# Example of use:

```
<BlazorTabs>
    <Tab Title="Onglet 1">
    Contenu 1
    </Tab>
    <Tab>
        <TabHeader>
            <strong>onglet 2</strong>
        </TabHeader>
        <ChildContent>
            Contenu 2
        </ChildContent>
    </Tab>
</BlazorTabs>
```

# preview
Soon
___
**[Release Notes](BlazorDatagrid_RELEASE_NOTE.md)** 

