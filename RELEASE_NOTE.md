[Read in english](https://github.com/niou128/BlazorComponent/blob/master/RELEASE_NOTE.en.md)

# Release notes
**1.4.0**
> - Ajout de la traduction de la Datagrid via le passage en paramètre d'un dictionnaire de traduction. 
>   - Nouveau paramètre : Translation

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