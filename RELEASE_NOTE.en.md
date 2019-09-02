[Lire en français](https://github.com/niou128/BlazorComponent/blob/master/RELEASE_NOTE.md)
# Release notes
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