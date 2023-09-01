[![License](https://img.shields.io/github/license/BlazorExtensions/Storage.svg?longCache=true&style=flat-square)](LICENSE)
[![Package Version](https://img.shields.io/badge/nuget-v4.0.0-blue.svg?longCache=true&style=flat-square)](https://www.nuget.org/packages/BlazorInput/)

[Lire en français](BlazorInput.md)

# BlazorNInput

Tab component for Blazor

# Nuget Gallery
The Nuget package page can be found at https://www.nuget.org/packages/BlazorInput/

# Installation

To install BlazorNInput using Package Manager run the following command 
```
Install-Package BlazorInput -Version 4.0.0
```
To install BlazorNInput using .NET CLI run the following command
```
dotnet add package BlazorInput --version 4.0.0
```

After you have installed the package add the following line in the ```_Imports.razor``` file
```
@using BlazorNInput
```

# Paramètres  
## BlazorInputText

- The ```BlazorInputText``` component accepts following parameters:
    -	**Placeholder** : The placeholder displayed when no text is entered.
    - **bind-Value** : The value retrieved by input.
    - **ReadOnly** : true ou false. Make the field read-only.
    - **ValidationPattern** : A regular expression to apply a control on the cell.
    - **LabelError** : The message to display in case of validation failure.


# Example of use:

```
<BlazorInputText Placeholder="Placeholder"
                 @bind-value="value"
                 ReadOnly="false"
                 LabelError="Ceci est une erreur"
                 ValidationPattern="^[-]?\d+$"/>
```

# preview
Soon
___
**[Release Notes](BlazorNInput_RELEASE_NOTE.md)** 

