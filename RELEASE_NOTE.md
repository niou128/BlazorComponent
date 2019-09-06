[Read in english](https://github.com/niou128/BlazorComponent/blob/master/RELEASE_NOTE.en.md)

# Release notes
**1.7.0**
> - compatibilité avec blazor preview 9

**1.6.0**
> - Mise à jour du style des filtres
> - Ajout d'un paramètre **DropdownFilter** pour remplacer la zone de texte du filtre par une liste contenant toutes les valeurs différentes de la colonnes
> - Ajout d'un délai avant la prise en compte du filtre

**1.5.0**
> - Ajout d'un sélecteur du nombre de résultat par page
> - Ajout d'un paramètre **ShowPageSelector** permettant d'afficher ou non le selecteur du nombre de résultat par page
> - Nouveau look pour la pagination
> - Le clic sur le bouton du segment pagination suivant ou précédent met la page courante sur respectivement la première ou la dernière page du nouveau segment.
> - Mise à jour de la traduction pour incorporer le selecteur.
> - Ajout du paramètre **PageSelector** pour personaliser le contenue du sélecteur. 

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