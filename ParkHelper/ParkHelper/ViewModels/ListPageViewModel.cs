using System;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System.Collections.Generic;
using System.Linq;
using ParkHelper.Commands;
using ParkHelper.Common.Models.ListeLieux;
using ParkHelper.Common.Models.RequeteListeLieux;
using System.Threading.Tasks;

namespace ParkHelper.ViewModels
{
    public class ListPageViewModel : ViewModelBase
    {
        #region Fields

        readonly INavigationService _navigationService;
        private bool _isLoading;
        private bool _itineraireCanBeGenerated;

        #endregion

        #region Constuctor

        public ListPageViewModel(INavigationService navigationService)
        {
            if (navigationService == null) throw new ArgumentNullException("navigationService");
            _navigationService = navigationService;

            HomeCommand = new RelayCommand(() => { _navigationService.GoBack(); });

            ItemDetailsCommand =
                new RelayCommand(() =>
                {
                    _navigationService.NavigateTo(Locator.LieuDetailsPage, Parameter);
                });

            ItineraireCommand = new RelayCommand(() =>
            {
                    _navigationService.NavigateTo(Locator.ItinerairePage, Context);
            });

            Listes = new List<Categorie>();
            ListeAppliSelectionnees = new List<int>();
            IsLoading = true;

            CreateItineraire = new CreateItineraireCommand(ItineraireCommand);
            CreateItineraire.SetSourceLieux(Listes);
            CreateItineraire.CanExecute(null);
        }

        #endregion

        #region Properties

        public bool IsLoading
        {
            get
            {
                return _isLoading;
            }
            set
            {
                _isLoading = value;
                RaisePropertyChanged(() => IsLoading);
                RaisePropertyChanged(() => IsLoadingComplete);
            }
        }

        public bool IsLoadingComplete
        {
            get
            {
                return !_isLoading;
            }
        }



        public ParkHelper Context { get; set; }
        public object Parameter { get; set; }

        #region Liste
        public List<Categorie> Listes { get; set; }
        public int ListesCount { get; set; }
        public List<int> ListeAppliSelectionnees { get; set; }
        #endregion

        #region Home
        public ICommand HomeCommand { get; set; }
        #endregion

        #region ItemDetails
        public ICommand ItemDetailsCommand { get; set; }
        #endregion

        #region Itineraire
        public ICommand ItineraireCommand { get; set; }
        public CreateItineraireCommand CreateItineraire { get; set; }

        public bool ItineraireCanBeGenerated
        {
            get
            {
                return _itineraireCanBeGenerated;
            }
            set
            {
                _itineraireCanBeGenerated = value;
                RaisePropertyChanged(() => ItineraireCanBeGenerated);
            }
        }
        #endregion

        #endregion

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
            var attraction = (Lieu)sender;
            if (attraction.EstDejaDansLeParcours)
            {
                ListeAppliSelectionnees.Add(attraction.Id);
            }
            else
            {
                ListeAppliSelectionnees.Remove(attraction.Id);
            }
            
            ItineraireCanBeGenerated = CreateItineraire.CanExecute(ListeAppliSelectionnees);
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
        #endregion
    }
}
