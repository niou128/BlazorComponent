[![License](https://img.shields.io/github/license/BlazorExtensions/Storage.svg?longCache=true&style=flat-square)](https://github.com/niou128/BlazorComponent/blob/master/LICENSE)
[![Package Version](https://img.shields.io/badge/nuget-v1.4.0-blue.svg?longCache=true&style=flat-square)](https://www.nuget.org/packages/BlazorDataGrid/)

[Read in english](https://github.com/niou128/BlazorComponent/blob/master/README.en.md)

# BlazorDatagrid

Il s'agit d'un composant pour Blazor. Une datagrid avec pagination, filtre et la possiblité de trier la colonnes par ordre croissant ou décroissant.

# Nuget Gallery
La paquet NuGet est disponible sur le site nuget.org à cette adresse https://www.nuget.org/packages/BlazorDataGrid/

# Installation

Ajouter le paquet NuGet à votre solution. 
```
Install-Package BlazorDataGrid -Version 1.4.0
```
Ou avec .Net CLI
```
dotnet add package BlazorDataGrid --version 1.4.0
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
- **Translation** : (optionnel) Un dictionnaire contenant la traduction de la datagrid. La [partie traduction](#Traduction) détail le contenu du dictionnaire.

Le composant ```<BlazorDataGridColumn>``` accepte les paramètres suivant :
-	**DataGridColumn** : Le composant détaillant chaque header

Le composant ```<DataGridColumn>``` accepte les paramètres suivant :
-	**Items** : Il faut passer le même paramètre que pour le composant ```<BlazorDataGrid>```
-	**ColumnName** : Le nom réel de la colonne sur laquelle se base le filtre et le tri
-	**DisplayColumnName** : (non obligatoire) Le nom qui sera affiché dans le header. *Il est possible de passer le contenu du header entre les balises à la place*
-	**Filter** : true ou false pour afficher ou non le champ filtre sur la colonne

Exemple de code :

```
<BlazorDataGrid Items="@forecasts" PageSize="5" ShowTotalResult="true" TheadClass="thead-dark" Translation="@translate">
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

private Dictionary<string, string> translate = new Dictionary<string, string>
    {
        {"next", "next" },
        {"previous", "Previous" },
        {"pages", "Page __curpage__ of __totalpages__" },
        {"totalresult", "__totalcount__ item" },
        {"totalresultplural", "__totalcount__ items"},
        {"filteredresults", "__filteredcount__ result of __totalcount__ items" },
        {"filteredresultsplural", "__filteredcount__ results of __totalcount__ items"  }
    };
```

# Traduction
La traduction s'éffectue par l"intermédiaire d'un dictionnaire string string.
La différentes valeur de clé sont les suivantes : 
> - **next** : le bouton page suivante de la pagination
> - **previous** : le bouton page précédente de la pagination
> - **pages** : La zone d'affichage de la page courrante et du nombre total de pages. Dans la partie valeur, il est possible de renseigner les variables suivante
>   - **```__curpage__```** : la page actuelle
>   - **```__totalpages__```** : le nombre totale de pages
> - **totalresult** : La phrase affiche le nombre total de résultats au singulier (0 ou 1 résultat). La partie valeur accepte la variable suivante : 
>   - **```__totalcount__```** : Le nombre total de résultats
> - **totalresultplural**: idem que le précédent mais au pluriel (2 résultats ou plus)
>   - **```__totalcount__```** : Le nombre total de résultats
> - **filteredresults** : permet l'affichage des résultats filtrés au singulier (0 ou 1 résultat).
>   - **```__filteredcount__```** : le nombre de résultats filtrés.
>   - **```__totalcount__```** : Le nombre total de résultats
> - **filteredresultsplural** : permet l'affichage des résultats filtrés au pluriel (2 résultats ou plus).
>   - **```__filteredcount__```** : le nombre de résultats filtrés.
>   - **```__totalcount__```** : Le nombre total de résultats

# Aperçu
![sortie 1](https://github.com/niou128/BlazorComponent/blob/master/BlazorDataGrid/content/output1.png)

![sortie 2](https://github.com/niou128/BlazorComponent/blob/master/BlazorDataGrid/content/output2.png)

**[Release notes](https://github.com/niou128/BlazorComponent/blob/master/RELEASE_NOTE.md)** 

