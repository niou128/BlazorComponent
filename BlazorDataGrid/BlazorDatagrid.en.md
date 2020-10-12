[![License](https://img.shields.io/github/license/BlazorExtensions/Storage.svg?longCache=true&style=flat-square)](LICENSE)
[![Package Version](https://img.shields.io/badge/nuget-v2.0.2-blue.svg?longCache=true&style=flat-square)](https://www.nuget.org/packages/BlazorDataGrid/)

[Lire en français](BlazorDatagrid.md)

# BlazorDatagrid

It's a Blazor component. A filtered, paged and sorted datagrid.

# Nuget Gallery
The Nuget package page can be found at https://www.nuget.org/packages/BlazorDataGrid/

# Installation

To install BlazorDataGrid using Package Manager run the following command
```
Install-Package BlazorDataGrid -Version 2.0.2
```
To install BlazorDataGrid using .NET CLI run the following command
```
dotnet add package BlazorDataGrid --version 2.0.2
```

After you have installed the package add the following line in the ```_Imports.razor``` file
```
@using BlazorDataGrid
```

And in the ```Startup.cs``` file in the method ```public void ConfigureServices(IServiceCollection services)```
```
services.AddScoped<AppState>();
```

# Parameters

The  ```<BlazorDataGrid>``` component accepts following parameters:
-	**Items**: The list with the results to show in the datagrid
-	**PageSize**: The initial number of results per page. If it is not present, the initial number is the first value of the selector.
-   **ShowTotalResult**: A boolean to show or not the total number of results.
-	**BlazorDataGridColumn**: A component to display the header
-	**GridRow**: Datagrid's row
- **Translation**: (optional) A dictionnary with the datagrid's translation. the [A dictionnary with the datagrid's translation](#Translation) detail the content of the dictionnary.
- **ShowPageSelector**: true or false, show or not the item per page selector
- **PageSelector** : A dictionnary (string int). Allows to customize the selector (display / value). The value 0 means all the elements. By default the display is the following:
    - "5", 5
    - "10", 10
    - "25", 25
    - "50", 50
    - "100", 100
    - "*", 0
- **Editable**: true or false, allows the datagrid to be editable. If the parameter is not present, the datagrid is not editable.

The ```<BlazorDataGridColumn>``` component accepts following parameters:
-	**DataGridColumn**: The header component.

The ```<DataGridColumn>``` component accepts following parameters:
-	**Items**: You need to pass the same component as ```<BlazorDataGrid>```
-	**ColumnName**: The actual name of the column on which the filter and the sorted are based
-	**DisplayColumnName**: (non mandatory) The name that will be displayed in the header. *
It is possible to pass the contents of the header between the tags instead*
-	**Filter**: true or false to show or not the input filter on the column
- **DropdownFilter**: true or false. Replacing the filter input text by a list witch contains all different values of the column.
- **Format**: Specifies the date format to display
- **ReadOnly**: Set a column ReadOnly when the datagrid is editable.


# Example of use:

```
<BlazorDataGrid Items="@forecasts" PageSize="5" ShowTotalResult="true" TheadClass="thead-dark" Translation="@translate" ShowPageSelector="true" PageSelector="@PageSelector" Editable="true">
    <BlazorDataGridColumn>
        <DataGridColumn Items="@forecasts" ColumnName="Date" Filter="true" Format="dd/MM/yyyy"><strong>Date</strong></DataGridColumn>
        <DataGridColumn Items="@forecasts" ColumnName="TemperatureC" DisplayColumnName="TemperatureC" DropdownFilter="true" ReadOnly="true"></DataGridColumn>
        <DataGridColumn Items="@forecasts" ColumnName="TemperatureF" DisplayColumnName="TemperatureF"></DataGridColumn>
        <DataGridColumn Items="@forecasts" ColumnName="Summary" DisplayColumnName="Summary"></DataGridColumn>
    </BlazorDataGridColumn>
    <GridRow>
        <td>@context.Date.ToShortDateString()</td>
        <td>@context.TemperatureC</td>
        <td>@context.TemperatureF</td>
        <td>@context.Summary</td>
    </GridRow>
</BlazorDataGrid>

private Dictionary<string, string> translate = new Dictionary<string, string>
    {
        {"next", "next" },
        {"previous", "Previous" },
        {"pages", "Page __curpage__ of __totalpages__" },
        {"totalresult", "__totalcount__ item" },
        {"totalresultplural", "__totalcount__ items"},
        {"filteredresults", "__filteredcount__ result of __totalcount__ items" },
        {"filteredresultsplural", "__filteredcount__ results of __totalcount__ items"  },
        {"selector", "Items per page:"}
    };

private Dictionary<string, int> PageSelector = new Dictionary<string, int>
    {
        {"5", 5 },
        {"10", 10 },
        {"20", 20 },
        {"30", 30 },
        {"All", 0 }
    };    
```

# Translation
The translation is done through a dictionary string string.
The different key values ​​are as follows: 
> - **next**: button next in pagination
> - **previous**: button previous in pagination
> - **pages**: The display area of ​​the current page and the total number of pages. 
In the value part, it is possible to enter the following variables:
>   - **```__curpage__```**: the current page
>   - **```__totalpages__```**: the total number of pages
> - **totalresult**: The sentence displays the total number of results in the singular (0 or 1 result). In the value part, it is possible to enter the following variables: 
>   - **```__totalcount__```**: the total number of results
> - **totalresultplural**: The sentence displays the total number of results in the plural (2 résults or more)
>   - **```__totalcount__```**: the total number of results
> - **filteredresults** : allows the display of filtered results in the singular (0 or 1 result).
>   - **```__filteredcount__```**: the number of filtered results.
>   - **```__totalcount__```**: the total number of results
> - **filteredresultsplural**: allows the display of filtered results in the plural (2 résults or more).
>   - **```__filteredcount__```**: the number of filtered results.
>   - **```__totalcount__```**: the total number of results
> - **selector**: Text for the items per page selector
> - **loading**: The loading message.
> - **labelError**: Error message when you enter an invalid format in the datagrid.

# preview
![sortie 1](BlazorDataGrid/content/output1.png)

![sortie 2](BlazorDataGrid/content/output2.png)

**[Release Notes](BlazorDatagrid_RELEASE_NOTE.en.md)** 
