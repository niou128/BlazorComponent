[![License](https://img.shields.io/github/license/BlazorExtensions/Storage.svg?longCache=true&style=flat-square)](https://github.com/niou128/BlazorComponent/blob/master/LICENSE)
[![Package Version](https://img.shields.io/badge/nuget-v1.3.0-blue.svg?longCache=true&style=flat-square)](https://www.nuget.org/packages/BlazorDataGrid/)
# BlazorDatagrid

Il s'agit d'un composant pour Blazor. Une datagrid avec pagination, filtre et la possiblité de trier la colonnes par ordre croissant ou décroissant.

# Nuget Gallery
La paquet NuGet est disponible sur le site nuget.org à cette adresse https://www.nuget.org/packages/BlazorDataGrid/

# Installation

Ajouter le pacquet NuGet à votre solution. 
```
Install-Package BlazorDataGrid -Version 1.3.0
```
Ou avec .Net CLI
```
dotnet add package BlazorDataGrid --version 1.3.0
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
-	**PageSize** : Le nombre de résultat par page. Le paramètre est obligatoire (0 signifie tout sur une seule page)
-   **ShowTotalResult** : Un booléen pour afficher ou non le nombre de résultats
-	**BlazorDataGridColumn** : Un composant permettant d'afficher les header
-	**GridRow** : Les lignes de la datagrid
-   **TableClass** : ajoute les classes spécifiées à la balise ```<table>```
-   **TheadClass** : ajoute les classes spécifiées à la balise ```<thead>```
-   **TbodyClass** : ajoute les classes spécifiées à la balise ```<tbody>```
- **TableStyle** : ajoute les styles spécifiés à la balise ```<table>```
- **TheadStyle** : ajoute les styles spécifiés à la balise ```<thead>```
- **TbodyStyle** : ajoute les styles spécifiés à la balise ```<tbody>```

Le composant ```<BlazorDataGridColumn>``` accepte les paramètres suivant :
-	**DataGridColumn** : Le composant détaillant chaque header

Le composant ```<DataGridColumn>``` accepte les paramètres suivant :
-	**Items** : Il faut passer le même paramètre que pour le composant ```<BlazorDataGrid>```
-	**ColumnName** : Le nom réel de la colonne sur laquelle se base le filtre et le tri
-	**DisplayColumnName** : (non obligatoire) Le nom qui sera affiché dans le header. *Il est possible de passer le contenu du header entre les balises à la place*
-	**Filter** : true ou false pour afficher ou non le champ filtre sur la colonne

Exemple de code :

```
<BlazorDataGrid Items="@forecasts" PageSize="5" ShowTotalResult="true" TheadClass="thead-dark">
    <BlazorDataGridColumn>
        <DataGridColumn Items="@forecasts" ColumnName="Date" Filter="true"><strong>Date</strong></DataGridColumn>
        <DataGridColumn Items="@forecasts" ColumnName="TemperatureC" DisplayColumnName="TemperatureC" Filter="true"></DataGridColumn>
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
```

# Aperçu
![sortie 1](https://github.com/niou128/BlazorComponent/blob/master/BlazorDataGrid/content/output1.png)

![sortie 2](https://github.com/niou128/BlazorComponent/blob/master/BlazorDataGrid/content/output2.png)

# Release notes
**1.3.0**
> - Ajout des paramètres suivant pour BlazorDatagrid :
>   - TableClass : ajoute les classes spécifiées à la balise ```<table>```
>   - TheadClass : ajoute les classes spécifiées à la balise ```<thead>```
>   - TbodyClass : ajoute les classes spécifiées à la balise ```<tbody>```
>   - TableStyle : ajoute les styles spécifiés à la balise ```<table>```
>   - TheadStyle : ajoute les styles spécifiés à la balise ```<thead>```
>   - TbodyStyle : ajoute les styles spécifiés à la balise ```<tbody>```

**1.2.0**
> - Compatibilité avec la preview 8 de Blazor

**1.1.1**
> - Le nombre de résultat est maintenant le nombre total filtré au lieu du nombre de résultat sur la page

**1.1.0**
> - Ajout de la possiblité d'afficher le nombre total d'élément en haut de la datagrid
> - Le nombre de pages affichées est mis à jour lors de l'application d'un filtre
> - Au lieu d'utiliser DisplayColumnName, il est possible de passer le texte du header entre les balises de la colonne :  ```<DataGridColumn>Texte du header</DataGridColumn>```

**1.0.0**
> - Initial release