using System;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System.Collections.Generic;
using System.Linq;
using ParkHelper.Common.Objets;
using Type = ParkHelper.Common.Objets.Type;

namespace ParkHelper.ViewModels
{
    using ParkHelper.Model;

    public class ListPageViewModel : ViewModelBase
    {
        #region Fields

        readonly INavigationService _navigationService;

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

            Attractions = new List<Attraction>();
            Listes = new List<Categorie>();
            InitAttractions();
            Listes = ConvertFrom(Attractions);
        }
        #endregion
    
        #region Properties
        public List<Attraction> Attractions { get; set; }
        public List<Categorie> Listes { get; set; }
        public ICommand HomeCommand { get; set; }
        public ICommand ItemDetailsCommand { get; set; }
        public Attraction Parameter { get; set; }
        #endregion

        #region Methods
        List<Categorie> ConvertFrom(List<Attraction> attractions)
        {
            var extractSubList = Attractions.GroupBy(i => i.Type.Id);

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
            new Categorie("Restaurant")
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

        private void InitAttractions()
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
    }
}
