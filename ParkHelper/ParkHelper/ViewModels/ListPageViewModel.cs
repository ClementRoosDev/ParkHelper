using System;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System.Collections.Generic;
using System.Linq;
using ParkHelper.Common.Objets;
using Type = ParkHelper.Common.Objets.Type;
using ParkHelper.Model;
using ParkHelper.Commands;

namespace ParkHelper.ViewModels
{
    public class ListPageViewModel : ViewModelBase
    {
        #region Fields

        readonly INavigationService _navigationService;
        string texteATrouver;

        #endregion

        #region Constuctor
        public ListPageViewModel(INavigationService navigationService)
        {
            if (navigationService == null) throw new ArgumentNullException("navigationService");
            _navigationService = navigationService;

            HomeCommand = new RelayCommand(() => { _navigationService.GoBack(); });

            Parameter = new Attraction()
            {
                Attente = 20,
                CapaciteWagon = 4,
                Description = "Attraction super cool",
                Duree = 10,
                EstDejaDansLeParcours = false,
                Id = 1,
                IdType = new Type() { Id = 1, Libelle = "Type 1" },
                Latittude = 38.99,
                Longitude = 37.87,
                Libelle = "Grand splash !",
                LienGif = "http://aaa.com/a.gif",
                Ordre = 0
            };

            ItemDetailsCommand =
                new RelayCommand(() =>
                {
                    _navigationService.NavigateTo(Locator.AttractionDetailsPage, Parameter);
                });

            ItineraireCommand = new RelayCommand(() =>
            {
                _navigationService.NavigateTo(Locator.AttractionDetailsPage, Parameter);
            });

            Attractions = new List<Attraction>();
            Listes = new List<Categorie>();
            Listes = ConvertFrom(Attractions);
            IsBusy = true;

            CreateItineraire = new CreateItineraireCommand(ItineraireCommand);

            TexteATrouver = "Rechercher";
        }
        #endregion
    
        #region Properties
        public List<Attraction> Attractions { get; set; }
        public bool IsBusy { get; set; }

        #region Liste
        public List<Categorie> Listes { get; set; }
        public ICommand ItemDetailsCommand { get; set; }
        public Attraction Parameter { get; set; }
        #endregion

        #region Home
        public ICommand HomeCommand { get; set; }
        #endregion

        #region Itineraire
        public ICommand ItineraireCommand { get; set; }
        public CreateItineraireCommand CreateItineraire { get; set; }
        #endregion

        #region SearchBar

        public string TexteATrouver
        {
            get { return texteATrouver; }
            set
            {
                texteATrouver = value;
                FilterListes();
            }
        }
        #endregion

        #endregion

        #region Methods

        public void InitListAttractions()
        {
            InitAttractions();
            AddingEventToList();
        }

        void AddingEventToList()
        {
            foreach (var itemLieu in Listes.SelectMany(subList => subList))
            {
                itemLieu.OnToggled += ToggleSelection;
            }
        }

        void ToggleSelection(object sender, EventArgs e)
        {
            var attraction = sender as Attraction;
            //System.Console.WriteLine("{0} has been toggled to {1}", attraction.Libelle, attraction.EstDejaDansLeParcours);
        }

        List<Categorie> ConvertFrom(List<Attraction> attractions)
        {
            //TODO : Call the API and extract the full list
            //var extractSubList = Attractions.GroupBy(i => i.Type.Id);

            return new List<Categorie>() {
            new Categorie("Attractions")
            {
                new Attraction()
                {
                    Attente = 20,
                    CapaciteWagon = 4,
                    Description = "Attraction super cool",
                    Duree = 10,
                    EstDejaDansLeParcours = false,
                    Id = 1,
                    IdType = new Type(){Id = 1, Libelle = "Type 1"},
                    Latittude = 38.99,
                    Longitude = 37.87,
                    Libelle = "Grand splash !",
                    LienGif = "http://aaa.com/a.gif",
                    Ordre = 0
                },
                new Attraction()
                {
                    Attente = 20,
                    CapaciteWagon = 4,
                    Description = "Attraction super cool",
                    Duree = 10,
                    EstDejaDansLeParcours = false,
                    Id = 1,
                    IdType = new Type(){Id = 1, Libelle = "Type 1"},
                    Latittude = 38.99,
                    Longitude = 37.87,
                    Libelle = "Bateau pirate",
                    LienGif = "http://aaa.com/a.gif",
                    Ordre = 0
                },
            },
            new Categorie("Shopping")
            {
                new Attraction()
                {
                    Attente = 30,
                    CapaciteWagon = 8,
                    Description = "Attraction pas tres cool",
                    Duree = 160,
                    EstDejaDansLeParcours = false,
                    Id = 2,
                    IdType = new Type(){Id = 2, Libelle = "Type 2"},
                    Latittude = 35.20,
                    Longitude = 40.60,
                    Libelle = "Les galeries de césar",
                    LienGif = "http://aaa.com/b.gif",
                    Ordre = 0
                },
                new Attraction()
                {
                    Attente = 30,
                    CapaciteWagon = 8,
                    Description = "Attraction pas tres cool",
                    Duree = 160,
                    EstDejaDansLeParcours = false,
                    Id = 2,
                    IdType = new Type(){Id = 2, Libelle = "Type 2"},
                    Latittude = 35.20,
                    Longitude = 40.60,
                    Libelle = "Au poisson frais",
                    LienGif = "http://aaa.com/b.gif",
                    Ordre = 0
                },
            },
            new Categorie("Restaurants")
            {
                new Attraction()
                {
                    Attente = 0,
                    CapaciteWagon = 1,
                    Description = "Attraction hyper cool",
                    Duree = 20,
                    EstDejaDansLeParcours = false,
                    Id = 3,
                    IdType = new Type(){Id = 3, Libelle = "Type 3"},
                    Latittude = 37.20,
                    Longitude = 10.60,
                    Libelle = "Abribus",
                    LienGif = "http://aaa.com/c.gif",
                    Ordre = 0
                },
                new Attraction()
                {
                    Attente = 0,
                    CapaciteWagon = 1,
                    Description = "Attraction hyper cool",
                    Duree = 20,
                    EstDejaDansLeParcours = false,
                    Id = 3,
                    IdType = new Type(){Id = 3, Libelle = "Type 3"},
                    Latittude = 37.20,
                    Longitude = 10.60,
                    Libelle = "Boulangerie",
                    LienGif = "http://aaa.com/c.gif",
                    Ordre = 0
                }
            },
            new Categorie("Services")
            {
                new Attraction()
                {
                    Attente = 0,
                    CapaciteWagon = 1,
                    Description = "Attraction hyper cool",
                    Duree = 20,
                    EstDejaDansLeParcours = false,
                    Id = 3,
                    IdType = new Type(){Id = 3, Libelle = "Type 3"},
                    Latittude = 37.20,
                    Longitude = 10.60,
                    Libelle = "Infirmerie",
                    LienGif = "http://aaa.com/c.gif",
                    Ordre = 0
                },
                new Attraction()
                {
                    Attente = 0,
                    CapaciteWagon = 1,
                    Description = "Attraction hyper cool",
                    Duree = 20,
                    EstDejaDansLeParcours = false,
                    Id = 3,
                    IdType = new Type(){Id = 3, Libelle = "Type 3"},
                    Latittude = 37.20,
                    Longitude = 10.60,
                    Libelle = "Reception",
                    LienGif = "http://aaa.com/c.gif",
                    Ordre = 0
                }
            },
            new Categorie("Hotels")
            {
                new Attraction()
                {
                    Attente = 0,
                    CapaciteWagon = 1,
                    Description = "Attraction hyper cool",
                    Duree = 20,
                    EstDejaDansLeParcours = false,
                    Id = 3,
                    IdType = new Type(){Id = 3, Libelle = "Type 3"},
                    Latittude = 37.20,
                    Longitude = 10.60,
                    Libelle = "Le village",
                    LienGif = "http://aaa.com/c.gif",
                    Ordre = 0
                },
                new Attraction()
                {
                    Attente = 0,
                    CapaciteWagon = 1,
                    Description = "Attraction hyper cool",
                    Duree = 20,
                    EstDejaDansLeParcours = false,
                    Id = 3,
                    IdType = new Type(){Id = 3, Libelle = "Type 3"},
                    Latittude = 37.20,
                    Longitude = 10.60,
                    Libelle = "Le camp",
                    LienGif = "http://aaa.com/c.gif",
                    Ordre = 0
                }
            }
        };
        }

        void InitAttractions()
        {
            Attractions = new List<Attraction>()
            {
                new Attraction()
                {
                    Attente = 20,
                    CapaciteWagon = 4,
                    Description = "Attraction super cool",
                    Duree = 10,
                    EstDejaDansLeParcours = false,
                    Id = 1,
                    IdType = new Type(){Id = 1, Libelle = "Type 1"},
                    Latittude = 38.99,
                    Longitude = 37.87,
                    Libelle = "Attraction 1",
                    LienGif = "http://aaa.com/a.gif",
                    Ordre = 0
                },
                new Attraction()
                {
                    Attente = 30,
                    CapaciteWagon = 8,
                    Description = "Attraction pas tres cool",
                    Duree = 160,
                    EstDejaDansLeParcours = false,
                    Id = 2,
                    IdType = new Type(){Id = 2, Libelle = "Type 2"},
                    Latittude = 35.20,
                    Longitude = 40.60,
                    Libelle = "Attraction 2",
                    LienGif = "http://aaa.com/b.gif",
                    Ordre = 0
                },
                new Attraction()
                {
                    Attente = 0,
                    CapaciteWagon = 1,
                    Description = "Attraction hyper cool",
                    Duree = 20,
                    EstDejaDansLeParcours = false,
                    Id = 3,
                    IdType = new Type(){Id = 3, Libelle = "Type 3"},
                    Latittude = 37.20,
                    Longitude = 10.60,
                    Libelle = "Attraction 3",
                    LienGif = "http://aaa.com/c.gif",
                    Ordre = 0
                }
            };
        }
        #endregion

        void FilterListes()
        {
            if (Listes != null && !TexteATrouver.Equals("Rechercher"))
            {
                if (string.IsNullOrEmpty(TexteATrouver))
                {
                    Listes = Listes;
                }
                else {
                    /**Listes = Listes.Where(x => x.Name.ToLower().Contains(TexteATrouver.ToLower())
                       || x.Libelle.ToLower().Contains(TexteATrouver.ToLower())).ToList();*/
                }
            }
        }
    }
}
