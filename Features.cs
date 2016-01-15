/**
F pour Feature
B pour Bug
I POUR In Progress
R pour Refactoring
ParkHelper : Features list

------------------------ Application ------------------------
1 :
DONE - F : NavigationService
DONE - F : Page Home
DONE - F : Page ListLieux
DONE - F : Page LieuDetails
DONE - F : Page Itineraire
DONE - F : Page Map

2 :
DONE - F : Autocompletion et amélioration de la vue ListLieux
- B/R : Suppression du cache des données qui fait buger l'appli
DONE - F : Améloriation de la GUI avec du style

3 :
DONE - F : Création d'un objet présence qui contient les infos de visite de l'utilisateur (datetime picker and so on)
- I : Vue Resa Hotel
DONE - F : Vue Infos Visite
- B : ActivityIndicator pas centré
- I : Acceleration appel API

4 :
- F : Service d'écoute pour api
- F : Recevoir des notifications

5 :
- F : Création d'un système de partage -> SQL à modifier

------------------------ Model ------------------------
1 :
DONE - F : Appel WebService pour ListeLieux
DONE - F : Appel WebService pour Parcours

2 :
DONE - B : Améliorer la requete Liste pour ne tenir compte que des attractions avec coord GPS

3 :
- F : Améliorer la requete Liste pour ne tenir compte que des attractions ouvertes -> Voir pour ajout champs BDD AVANT

------------------------ API ODATA ------------------------
1 :
DONE - F : LieuxController
DONE - F : ParcoursController

2 :
- F : Amélioration du ParcoursController

------------------------ SQL / SQL SERVER -----------------
1 :
DONE - Schema basique avec 3 tables :
Lieux
TypeDeLieu
Indications
Liaison(Indications,Lieux)
Liaison(Lieux, TypeDeLieu)

2 :
DONE - F MAMDATORY : Completer les données de la table Lieux

3 :
DONE - I : Remplir les indications
DONE - F : Ajout d'un champs Etat : Ouvert, Fermé => Controller API à UPDATE, ask for help if needed

4 :
DONE - I : Ajout de la gestion des horaires pour les spectacles et toutes les attractions => Controller API & EDMX à UPDATE, ask for help if needed
Pour la table horaire, les champs sont :
IdHoraire
Ouverture
Fermeture
En complément une table jour :
IdJour
NomJour
La ternaire avec IdJour, IdHoraire, IdLieu
Horaire ouverture et fermeture pour 8h-17 ou 15h-15h30 pour les spectacles

------------------------ Simulation -----------------

1 :
DONE - F MANDATORY : Remplir un planning sur une semaine
- F : Coder la vie d'un parc en modifiant les infos d'attente et d'annulation des spectacles

TO BE CONTINUED....
Copyright Infolution 2015
*/
