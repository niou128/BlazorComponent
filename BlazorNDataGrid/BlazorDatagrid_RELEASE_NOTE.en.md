[Lire en français](BlazorDatagrid_RELEASE_NOTE.md)
# Release notes
**5.0.1**
update dependency to BlazorNInput

**5.0.0**

_New_
- Update to .Net6
- You don't have to specified the colection used in each column and cells anymore

```razor
<DataGridColumn ColumnName="TemperatureC" DisplayColumnName="TemperatureC" Filter="true"></DataGridColumn>

<Cell Context="cellcontext">
    @cellcontext.Summary
</Cell>
```

instead of

```razor
<DataGridColumn Items="@forecasts" ColumnName="TemperatureC" DisplayColumnName="TemperatureC" Filter="true"></DataGridColumn>

<Cell Items="@forecasts" Context="cellcontext">
    @cellcontext.Summary
</Cell>
```

**4.1.1**

_Fixes_
- Fixed a problem with a dependancy
- Fixed a problem with rendering cell content
- Using the double curly brace between `<Cell></Cell>` tags prevents C # methods from working. This feature is therefore withdrawn. You have to go through the context instead. The use of braces in the Content parameter is not impacted.
- 

```razor
<Cell Items="@forecasts" Context="cellcontext">
    @cellcontext.Summary
</Cell>
```
instead of
```razor
<Cell Items="@forecasts" Context="cellcontext">
    {{Summary}}
</Cell>
```

**4.1.0**

_New_
- When the datagrid is not editable, it is possible to go through the context to retrieve the data when the content is placed between the tags `<Cell></Cell>`
```razor
<Cell Items="@forecasts" Context="cellcontext">
    @cellcontext.Summary
</Cell>
```
**4.0.0**

_New_
- Update to .Net5
- Variables in double braces are now interpreted when content is passed between tags `<Cell></Cell>`

_Fix_
- Fixed crash when the Parameter Content of the Cell component is null.

**3.0.0**
- Structural change requiring to review the implementation of the datagrid in the code.
- Adding a Cell component to the datagrid to manage cells. This component is placed in the GridRow part and becomes mandatory.

* Added new parameters for the Cell component
    * Items which is the same parameter as for the datagrid
    * Content which contains cell content
    * ValidationPattern which allows you to add a validation pattern
    * LabelError which contains the error message in case of validation failure

**2.0.2**
> - If the input list is null, the result is a table with 0 element.

**2.0.1**
> - fix a bug on the display of number of result when an item is add in the start list.

**2.0.0**
> - Add parameter format to display date to a specfific format.
> - Add parameter Editable allow the datagrid to be editable.
> - Add parameter ReadOnly who set a column ReadOnly when the datagrid is editable 
> - Add an error label when you enter an invalide format in the editable datagrid.
> - Add a keyword labelError in the translation dictionnary

**1.11.0**
> - Update to .Net Core 3.1
> - Updating pagination calculation

**1.10.2**
> - Add loading message in the dictionnary

**1.10.1**
> - Update column sorting

**1.10.0**
> - Improved column filtering.
> - Adding a load message during a long filter

**1.9.0**
> - The PageSize parameter now allows you to set the initial number of items displayed. If it is not present, the initial number is the first value of the selector.

**1.8.0**
> - Compatibility with .NET Core 3.0 Release Candidate 1

**1.7.0**
> - Compatibility with Blazor preview 9

**1.6.0**
> - updating filter style
> - Adding the parameter **DropdownFilter** to replace the filter input text by a list witch contains all different values of the column
> - adding a delay before filtering

**1.5.0**
> - Adding a selector for the number of display per page
> - Adding the parameter **ShowPageSelector** to display or not the selector
> - New look for the pagination
> - Clicking the next or previous pagination segment button places the current page on the first or last page of the new segment, respectively
> - Update the translation to incorporate the selector
> - Adding the parameter **PageSelector** to personalise the selector

**1.4.0**
> - Added the translation of the Datagrid by passing a translation dictionnary in parameter. 
>   - New parameter : Translation

**1.3.0**
> - Add the following parameters:
>   - TableClass: add the specified classes to the tag ```<table>```
>   - TheadClass: add the specified classes to the tag ```<thead>```
>   - TbodyClass: add the specified classes to the tag ```<tbody>```
>   - TableStyle: add the specified styles to the tag ```<table>```
>   - TheadStyle: add the specified styles to the tag ```<thead>```
>   - TbodyStyle: add the specified styles to the tag ```<tbody>```

**1.2.0**
> - Add compatibility with Blazor preview 8

**1.1.1**
> - The result number is now the total number filtered instead of the number of result in the current page.

**1.1.0**
> - Add the possibility to show the total number of items on top of the datagrid.
> - The number of displayed page is update when a filter is applied.
> - Instead of using DisplayColumnName, it's possible to pass the header's text between the column tag:  ```<DataGridColumn>header text</DataGridColumn>```

**1.0.0**
> - Initial release