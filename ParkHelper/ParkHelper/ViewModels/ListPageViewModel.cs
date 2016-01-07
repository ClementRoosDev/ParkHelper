using System;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System.Collections.Generic;
using System.Linq;
using Attraction = ParkHelper.Common.Objets.Attraction;
using ParkHelper.Model;
using ParkHelper.Commands;

namespace ParkHelper.ViewModels
{
    public class ListPageViewModel : ViewModelBase
    {
        #region Fields

        readonly INavigationService _navigationService;
        string _texteATrouver;

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
                    _navigationService.NavigateTo(Locator.AttractionDetailsPage, Parameter);
                });

            ItineraireCommand = new RelayCommand(() =>
            {
                    _navigationService.NavigateTo(Locator.ItinerairePage, ListeAppliSelectionnees);
            });

            Listes = new List<Categorie>();
            ListesBackup = new List<Categorie>();
            ListeAppliSelectionnees = new List<int>();
            IsBusy = true;

            CreateItineraire = new CreateItineraireCommand(ItineraireCommand);
            CreateItineraire.SetSourceLieux(Listes);
            CreateItineraire.CanExecute(null);
            TexteATrouver = "Rechercher";
        }

        #endregion

        #region Properties

        public bool IsBusy { get; set; }

        private bool _itineraireCanBeGenerated;

        public bool ItineraireCanBeGenerated
        {
            get {
                return _itineraireCanBeGenerated;
            }
            set
            {
                _itineraireCanBeGenerated = value;
                RaisePropertyChanged(() => ItineraireCanBeGenerated);
            }    
        }
        public object Parameter { get; set; }

        #region Liste
        public List<Categorie> Listes { get; set; }
        public List<Categorie> ListesBackup { get; set; }
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
        #endregion

        #region SearchBar

        public string TexteATrouver
        {
            get { return _texteATrouver; }
            set
            {
                _texteATrouver = value;
                if (!_texteATrouver.Equals("Rechercher"))
                {
                    FilterListes();
                }
            }
        }
        #endregion

        #endregion

        #region Methods

        private void AddingEventToList()
        {
            foreach (var itemLieu in Listes.SelectMany(subList => subList))
            {
                itemLieu.OnToggled += ToggleSelection;
            }
        }

        private void ToggleSelection(object sender, EventArgs e)
        {
            var attraction = (Attraction)sender;
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
            //System.Console.WriteLine("{0} has been toggled to {1}", attraction.Libelle, attraction.EstDejaDansLeParcours);
        }

        internal void ConvertFrom(List<Attraction> attractions)
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

        void FilterListes()
        {
            ListesCount = Listes.Count;
            if (TexteATrouver.Length <= 3) return;
            if (Listes != null && !TexteATrouver.Equals("") && !TexteATrouver.Equals("Rechercher"))
            {
                ListesBackup = Listes;
                Listes = Listes.Where(x => x.Any(a => a.Libelle.Contains(_texteATrouver))).ToList();
                ListesCount = Listes.Count;
            }
            else
            {
                Listes = ListesBackup;
                ListesCount = Listes.Count;
            }
            CreateItineraire.SetSourceLieux(Listes);
        }
        #endregion
    }
}
