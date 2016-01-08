/**

F pour Feature
B pour Bug
R pour Refactoring
ParkHelper : Features list

------------------------ Application ------------------------
1 :
- F : NavigationService
- F : Page Home
- F : Page ListLieux
- F : Page LieuDetails
- F : Page Itineraire
- F : Page Map

2 :
- B/R : Suppression du cache des données qui fait buger l'appli
- F : Améloriation de la GUI avec du style

------------------------ API ODATA ------------------------
1:
- F : LieuxController
- F : ParcoursController

2:
- F : Amélioration du ParcoursController

------------------------ SQL / SQL SERVER -----------------
1:
- Schema basique avec 3 tables :
Lieux
TypeDeLieu
Indications
Liaison(Indications,Lieux)
Liaison(Lieux, TypeDeLieu)

2:
- F MAMDATORY : Completer les données de la table Lieux

- F : Ajout d'un champs Etat : Ouvert, Fermé => Controller API à UPDATE, ask for help if needed
- F : Ajout de la gestion des horaires pour les spectacles et toutes les attractions => Controller API & EDMX à UPDATE, ask for help if needed
Pour la table horaire, les champs sont :
IdHoraire
Ouverture
Fermeture
En complément une table jour :
IdJour
NomJour
La ternaire avec IdJour, IdHoraire, IdLieu
Horaire ouverture et fermeture pour 8h-17 ou 15h-15h30 pour les spectacles

TO BE CONTINUED....
Copyright Infolution 2015
*/