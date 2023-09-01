[![License](https://img.shields.io/github/license/BlazorExtensions/Storage.svg?longCache=true&style=flat-square)](LICENSE)
[![Package Version](https://img.shields.io/badge/nuget-v4.0.1-blue.svg?longCache=true&style=flat-square)](https://www.nuget.org/packages/BlazorInput/)

[Read in english](BlazorNInput.en.md)

# BlazorNInput

Champs de saisie pour Blazor.

# Nuget Gallery
La paquet NuGet est disponible sur le site nuget.org à cette adresse https://www.nuget.org/packages/BlazorInput/

# Installation

Ajouter le paquet NuGet à votre solution. 
```
Install-Package BlazorInput -Version 4.0.1
```
Ou avec .Net CLI
```
dotnet add package BlazorInput --version 4.0.1
```

Ensuite il faut ajouter dans le fichier ```_Imports.razor```
```
@using BlazorNInput
```

# Paramètres  
## BlazorInputText
- Le composant ```BlazorInputText``` accepte les paramètres suivant :
    -	**Placeholder** : Le placeholder s'affichant quand aucun texte n'est renseigné.
    - **bind-Value** : La valeur récupéré par la saisie.
    - **ReadOnly** : true ou false. Rend le champ en lecture seule.
    - **ValidationPattern** : Une expression régulière pour appliquer un contrôle sur la cellule.
    - **LabelError** : Le message à afficher en cas d'échec de la validation.




# Exemple d'utilisation

```
<BlazorInputText Placeholder="Placeholder"
                 @bind-value="value"
                 ReadOnly="false"
                 LabelError="Ceci est une erreur"
                 ValidationPattern="^[-]?\d+$"/>
```

# Aperçu
A venir
___
**[Notes de version](BlazorNInput_RELEASE_NOTE.md)** 

