[![License](https://img.shields.io/github/license/BlazorExtensions/Storage.svg?longCache=true&style=flat-square)](https://github.com/niou128/BlazorComponent/blob/master/LICENSE)
[![Package Version](https://img.shields.io/badge/nuget-v1.0.0-blue.svg?longCache=true&style=flat-square)](https://www.nuget.org/packages/BlazorDataGrid/)
# BlazorDatagrid

Il s'agit d'un composant pour Blazor. Une datagrid avec pagination, filtre et la possiblité de trier la colonnes par ordre croissant ou décroissant.

# Nuget Gallery
La paquet NuGet est disponible sur le site nuget.org à cette adresse https://www.nuget.org/packages/BlazorDataGrid/

# Installation

Ajouter le pacquet NuGet à votre solution. 
```
Install-Package BlazorDataGrid -Version 1.0.0
```
Ou avec .Net CLI
```
dotnet add package BlazorDataGrid --version 1.0.0
```

Ensuite il faut ajouter dans le fichier ```_Imports.razor```
```
@using BlazorDataGrid
```

Et dans le fichier ```Startup.cs``` dans la méthode ```public void ConfigureServices(IServiceCollection services)```
```
services.AddScoped<AppState, AppState>();
```

# Exemple d'utilisation

Le composant ```<BlazorDataGrid>``` accepte les paramètres suivant :
-	**Items** : La liste qui remplie la datagrid
-	**PageSize** : Le nombre de résultat par page. Le paramètre est obligatoire
-	**BlazorDataGridColumn** : Un composant permettant d'afficher les header
-	**GridRow** : Les lignes de la datagrid

Le composant ```<BlazorDataGridColumn>``` accepte les paramètres suivant :
-	**DataGridColumn** : Le composant détaillant chaque header

Le composant ```<DataGridColumn>``` accepte les paramètres suivant :
-	**Items** : Il faut passer le même paramètre que pour le composant ```<BlazorDataGrid>```
-	**ColumnName** : Le nom réel de la colonne sur laquelle se base le filtre et le tri
-	**DisplayColumnName** : Le nom qui sera affiché dans le header
-	**Filter** : true ou false pour afficher ou non le champ filtre sur la colonne

Exemple de code :

```
BlazorDataGrid Items="@forecasts" PageSize="4">
    <BlazorDataGridColumn>
        <DataGridColumn Items="@forecasts" ColumnName="Date" DisplayColumnName="Date" Filter="true"></DataGridColumn>
        <DataGridColumn Items="@forecasts" ColumnName="TemperatureC" DisplayColumnName="Temperature C" Filter="true"></DataGridColumn>
        <DataGridColumn Items="@forecasts" ColumnName="TemperatureF" DisplayColumnName="Temperature F"></DataGridColumn>
        <DataGridColumn Items="@forecasts" ColumnName="Summary" DisplayColumnName="Summary"></DataGridColumn>
    </BlazorDataGridColumn>
    <GridRow>
        <td>@context.Date.ToShortDateString()</td>
        <td>@context.TemperatureC</td>
        <td>@context.TemperatureF</td>
        <td>@context.Summary</td>
    </GridRow>
</BlazorDataGrid>
```

# Aperçu
![Alt Text](https://github.com/niou128/BlazorComponent/blob/master/BlazorDataGrid/content/apercu.png)