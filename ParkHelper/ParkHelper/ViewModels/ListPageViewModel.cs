using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using ParkHelper.Commands;
using ParkHelper.Common.Models.ListeLieux;
using ParkHelper.Common.Models.RequeteListeLieux;

namespace ParkHelper.ViewModels
{
    public class ListPageViewModel : ViewModelBase
    {
        private int _choixPauseDej;
        private ParkHelper _context;
        private bool _hotel;
        private bool _isLoading;
        private bool _itineraireCanBeGenerated;


        public INavigationService _navigationService;

        private bool _nocturne;

        #region Constuctor

        public ListPageViewModel(INavigationService navigationService)
        {
            if (navigationService == null) throw new ArgumentNullException("navigationService");
            _navigationService = navigationService;

            HomeCommand = new RelayCommand(() => { _navigationService.NavigateTo(Locator.HomePage, Context); });

            ItemDetailsCommand =
                new RelayCommand(() => { _navigationService.NavigateTo(Locator.LieuDetailsPage, Parameter); });

            ItineraireCommand =
                new RelayCommand(() => { _navigationService.NavigateTo(Locator.ItinerairePage, Context); });

            VisiteDetailsCommand =
                new RelayCommand(() => { _navigationService.NavigateTo(Locator.VisiteDetailsPage, Context); });


            EditHotelCommand = new RelayCommand(() =>
            {
                _navigationService.NavigateTo(
                    Locator.EditHotelDetailsPage, Context);
            });

            TempsEstime = new List<string>
            {
                "0",
                "5",
                "10",
                "15",
                "20",
                "25",
                "30",
                "35",
                "40",
                "45",
                "50",
                "55",
                "1h",
                "1h15",
                "1h30",
                "1h45",
                "2h"
            };


            Listes = new List<Categorie>();
            ListeAppliSelectionnees = new List<int>();
            IsLoading = true;

            CreateItineraire = new CreateItineraireCommand(ItineraireCommand);
            CreateItineraire.SetSourceLieux(Listes);
            CreateItineraire.CanExecute(null);
        }

        #endregion

        public ICommand HomeCommand { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand EditHotelCommand { get; set; }

        public bool Hotel
        {
            get { return _hotel; }
            set
            {
                _hotel = value;
                RaisePropertyChanged(() => Hotel);
            }
        }

        public bool Nocturne
        {
            get { return _nocturne; }
            set
            {
                _nocturne = value;
                Context.VisitePark.Nocturne = _nocturne;
                RaisePropertyChanged(() => Nocturne);
            }
        }

        public List<string> TempsEstime { get; set; }

        public int ChoixPauseDej
        {
            get { return _choixPauseDej; }
            set
            {
                _choixPauseDej = value;
                Context.VisitePark.DureePauseDej = ConvertToValue(_choixPauseDej);
                RaisePropertyChanged(() => ChoixPauseDej);
            }
        }


        public bool IsLoading
        {
            get { return _isLoading; }
            set
            {
                _isLoading = value;
                RaisePropertyChanged(() => IsLoading);
                RaisePropertyChanged(() => IsLoadingComplete);
            }
        }

        public bool IsLoadingComplete
        {
            get { return !_isLoading; }
        }

        public ParkHelper Context
        {
            get { return _context; }
            set
            {
                _context = value;
                RaisePropertyChanged(() => Context);
            }
        }

        public object Parameter { get; set; }


        public List<Categorie> Listes { get; set; }
        public int ListesCount { get; set; }
        public List<int> ListeAppliSelectionnees { get; set; }


        public ICommand ItemDetailsCommand { get; set; }


        public ICommand VisiteDetailsCommand { get; set; }


        public ICommand ItineraireCommand { get; set; }
        public CreateItineraireCommand CreateItineraire { get; set; }

        public bool ItineraireCanBeGenerated
        {
            get { return _itineraireCanBeGenerated; }
            set
            {
                _itineraireCanBeGenerated = value;
                RaisePropertyChanged(() => ItineraireCanBeGenerated);
            }
        }

        #region Methods

        public void TryToRestore()
        {
            if (Context.ListeAppliSelectionnees != null && Context.ListeAppliSelectionnees.Count > 0)
            {
            }
        }

        private void AddingEventToList()
        {
            foreach (var itemLieu in Listes.SelectMany(subList => subList))
            {
                itemLieu.OnToggled += ToggleSelection;
            }
        }

        private void ToggleSelection(object sender, EventArgs e)
        {
            var attraction = (Lieu) sender;
            if (attraction.EstDejaDansLeParcours)
            {
                ListeAppliSelectionnees.Add(attraction.Id);
            }
            else
            {
                ListeAppliSelectionnees.Remove(attraction.Id);
            }

            ItineraireCanBeGenerated = CreateItineraire.CanExecute(ListeAppliSelectionnees);
            Context.ListeAppliSelectionnees = ListeAppliSelectionnees;
            //TODO : Verifier possibilité d'ajout à l'itinéraire
            //System.Console.WriteLine("{0} has been toggled to {1}", Lieu.Libelle, Lieu.EstDejaDansLeParcours);
        }

        internal void ConvertFrom(List<Lieu> attractions)
        {
            var extractSubList = attractions.GroupBy(i => i.TypeDeLieu.Libelle);
            foreach (var subList in extractSubList)
            {
                var categorie = new Categorie(subList.Key);
                foreach (var item in subList)
                {
                    item.LienGif = "http://aaa.com/a.gif";
                    categorie.Add(item);
                }
                Listes.Add(categorie);
            }
            AddingEventToList();
            CreateItineraire.SetSourceLieux(Listes);
        }

        private static int ConvertToValue(int s)
        {
            switch (s)
            {
                case 16:
                    return 120;
                case 15:
                    return 105;
                case 14:
                    return 90;
                case 13:
                    return 75;
                case 12:
                    return 60;
            }
            return s;
        }

        #endregion
    }
}