[![License](https://img.shields.io/github/license/BlazorExtensions/Storage.svg?longCache=true&style=flat-square)](LICENSE)
[![Package Version](https://img.shields.io/badge/nuget-v1.0.0-blue.svg?longCache=true&style=flat-square)](https://www.nuget.org/packages/BlazorNTooltip/)

[Read in english](BlazorNTooltip.en.md)

# BlazorNTooltip

Un composant tooltip pour Blazor

# Nuget Gallery
La paquet NuGet est disponible sur le site nuget.org à cette adresse https://www.nuget.org/packages/BlazorNTooltip/

# Installation

Ajouter le paquet NuGet à votre solution. 
```
Install-Package BlazorNTooltip -Version 1.0.0
```
Ou avec .Net CLI
```
dotnet add package BlazorNTooltip --version 1.0.0
```

Ensuite il faut ajouter dans le fichier ```_Imports.razor```
```
@using BlazorNTooltip
```

# Paramètres

Le composant ```<Tooltip>``` accepte les paramètres suivant :
-	**Text** : Le texte du tooltip
-	**Position** : La position du tooltip. A choisir parmis un des 4 suivant (La position par défaut est top) :
    - top
    - bottom
    - right
    - left


# Exemple d'utilisation

```
Welcome to your new <Tooltip Text="Wonderful tooltip!" Position="right">app</Tooltip>.
```

# Aperçu
A venir.

___
**[Notes de version](BlazorNTooltip_RELEASE_NOTE.md)** 

