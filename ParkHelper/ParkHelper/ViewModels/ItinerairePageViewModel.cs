using GalaSoft.MvvmLight;
using System;
using GalaSoft.MvvmLight.Views;
using System.Collections.Generic;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using ParkHelper.Common.Objets;
using ParkHelper.Model;
using ParkHelper.Common.WebService;
using System.Linq;

namespace ParkHelper.ViewModels
{
    public class ItinerairePageViewModel : ViewModelBase
    {
        #region Fields

        readonly INavigationService _navigationService;

        #endregion

        #region Contructor
        public ItinerairePageViewModel(INavigationService navigationService)
        {
            if (navigationService == null) throw new ArgumentNullException("navigationService");
            _navigationService = navigationService;

            HomeCommand = new RelayCommand(() =>
            {
                _navigationService.NavigateTo(
                    Locator.HomePage);
            });
            Listes = new List<Parcours>();
            //Listes = DummyParcours();
            IsBusy = true;

            InitialiseParcours();

        }


        #endregion

        #region Properties
        #region General
        public ICommand HomeCommand { get; set; }
        #endregion
        #region Local
        public List<Parcours> Listes { get; set; }
        public bool IsBusy { get; set; }
        public List<int> ListeIdAttractions { get; set; }

        #endregion
        #endregion

        #region Methods

        private async void InitialiseParcours()
        {
            var value = new ParkHelperWebservice();
            var resultParcours = await value.GetParcours(ListeIdAttractions);
            /*
            foreach (var item in resultParcours.ListeParcours.OrderBy(a => a.Ordre))
            {
                if (item is Deplacement)
                {
                    Console.WriteLine("Deplacement : " + item.Duree);
                }
                if (item is Lieu)
                {
                    Console.WriteLine("Attraction : " + ((Lieu)item).Libelle);
                }
            }*/
        }
        /**List<Parcours> DummyParcours()
        {
            return new List<Parcours>
            {
                new Parcours(
                    new EtapeParcours(
                        "9H",
                        new Attraction
                        {
                            Attente = 0,
                            CapaciteWagon = 1,
                            Description = "Attraction hyper cool",
                            Duree = 20,
                            EstDejaDansLeParcours = false,
                            Id = 3,
                            IdType = new TypeDeLieu() { Id = 3, Libelle = "Type 3" },
                            Latittude = 37.20,
                            Longitude = 10.60,
                            Libelle = "Entrée",
                            LienGif = "http://aaa.com/c.gif",
                            Ordre = 0
                        }))
                {
                    /**new Attraction()
                    {
                        Attente = 0,
                        CapaciteWagon = 1,
                        Description = "Attraction hyper cool",
                        Duree = 20,
                        EstDejaDansLeParcours = false,
                        Id = 3,
                        IdType = new Type() { Id = 3, Libelle = "Type 3" },
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
                        IdType = new Type { Id = 3, Libelle = "Type 3" },
                        Latittude = 37.20,
                        Longitude = 10.60,
                        Libelle = "Le camp",
                        LienGif = "http://aaa.com/c.gif",
                        Ordre = 0
                    }
                },
            };
        }*/

        #endregion
    }
}
