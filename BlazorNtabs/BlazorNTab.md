[![License](https://img.shields.io/github/license/BlazorExtensions/Storage.svg?longCache=true&style=flat-square)](LICENSE)
[![Package Version](https://img.shields.io/badge/nuget-v1.5.0-blue.svg?longCache=true&style=flat-square)](https://www.nuget.org/packages/BlazorTabs/)

[Read in english](BlazorNTab.en.md)

# BlazorNTab

Un composant blazor permettant l'ajout d'onglets.

# Nuget Gallery
La paquet NuGet est disponible sur le site nuget.org à cette adresse https://www.nuget.org/packages/BlazorTabs/

# Installation

Ajouter le paquet NuGet à votre solution. 
```
Install-Package BlazorTabs -Version 1.5.0
```
Ou avec .Net CLI
```
dotnet add package BlazorTabs --version 1.5.0
```

Ensuite il faut ajouter dans le fichier ```_Imports.razor```
```
@using BlazorNtabs
```

# Paramètres  

Le composant ```<Tab>``` accepte les paramètres suivant :
-	**Title** : Le titre de l'onglet

Il est possible de définir un titre plus complexe avec des styles en le plaçant dans la balise ```<TabHeader>``` puis en plaçant le contenu dans la balise ```<ChildContent>```


# Exemple d'utilisation

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

# Aperçu
A venir
___
**[Notes de version](BlazorDatagrid_RELEASE_NOTE.md)** 

