/**

F pour Feature
B pour Bug
I POUR In Progress
R pour Refactoring
ParkHelper : Features list

------------------------ Application ------------------------
1 : DONE
- F : NavigationService
- F : Page Home
- F : Page ListLieux
- F : Page LieuDetails
- I : Page Itineraire
- F : Page Map

2 :
- F : Autocompletion et amélioration de la vue ListLieux
- B/R : Suppression du cache des données qui fait buger l'appli
- F : Améloriation de la GUI avec du style

3 :
- F : Création d'un objet présence qui contient les infos de visite de l'utilisateur (datetime picker and so on)
- F : Vue Resa Hotel
- F : Vue Infos Visite

4 :
- F : Service d'écoute pour api
- F : Recevoir des notifications

5 :
- F : Création d'un système de partage -> SQL à modifier

------------------------ Model ------------------------
1 : DONE
- F : Appel WebService pour ListeLieux
- F : Appel WebService pour Parcours

2 : DONE
- B : Améliorer la requete Liste pour ne tenir compte que des attractions avec coord GPS

3 : DONE
- F : Améliorer la requete Liste pour ne tenir compte que des attractions ouvertes -> Voir pour ajout champs BDD AVANT

------------------------ API ODATA ------------------------
1 : DONE
- F : LieuxController
- F : ParcoursController

2 :
- F : Amélioration du ParcoursController

------------------------ SQL / SQL SERVER -----------------
1 : DONE
- Schema basique avec 3 tables :
Lieux
TypeDeLieu
Indications
Liaison(Indications,Lieux)
Liaison(Lieux, TypeDeLieu)

2 : DONE
- F MAMDATORY : Completer les données de la table Lieux

3 : DONE
- I : Remplir les indications
- F : Ajout d'un champs Etat : Ouvert, Fermé => Controller API à UPDATE, ask for help if needed

4 :
- I : Ajout de la gestion des horaires pour les spectacles et toutes les attractions => Controller API & EDMX à UPDATE, ask for help if needed
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
- F MANDATORY : Remplir un planning sur une semaine
- F : Coder la vie d'un parc en modifiant les infos d'attente et d'annulation des spectacles

TO BE CONTINUED....
Copyright Infolution 2015
*/
