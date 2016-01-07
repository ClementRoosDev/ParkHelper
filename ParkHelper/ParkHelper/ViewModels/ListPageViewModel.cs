using System;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System.Collections.Generic;
using System.Linq;
using Type = ParkHelper.Common.Objets.Type;
using Attraction = ParkHelper.Common.Objets.Attraction;
using ParkHelper.Model;
using ParkHelper.Commands;

namespace ParkHelper.ViewModels
{
    public class ListPageViewModel : ViewModelBase
    {
        #region Fields

        readonly INavigationService navigationService;
        string texteATrouver;

        #endregion

        #region Constuctor
        public ListPageViewModel(INavigationService navigationService)
        {
            if (navigationService == null) throw new ArgumentNullException("navigationService");
            this.navigationService = navigationService;

            HomeCommand = new RelayCommand(() => { this.navigationService.GoBack(); });
            /*
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
            };*/

            ItemDetailsCommand =
                new RelayCommand(() =>
                {
                    this.navigationService.NavigateTo(Locator.AttractionDetailsPage, Parameter);
                });

            ItineraireCommand = new RelayCommand(() =>
            {
                this.navigationService.NavigateTo(Locator.ItinerairePage, Parameter);
            });

            Listes = new List<Categorie>();
            ListesBackup = new List<Categorie>();
            IsBusy = true;

            CreateItineraire = new CreateItineraireCommand(ItineraireCommand);

            TexteATrouver = "Rechercher";
        }
        #endregion

        #region Properties

        public bool IsBusy { get; set; }
        public object Parameter { get; set; }

        #region Liste
        public List<Categorie> Listes { get; set; }
        public List<Categorie> ListesBackup { get; set; }
        public int ListesCount { get; set; }
        private List<int> listeAppliSelectionnees { get; set; }
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
            get { return texteATrouver; }
            set
            {
                texteATrouver = value;
                if (!texteATrouver.Equals("Rechercher"))
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
            var attraction = sender as Attraction;
            listeAppliSelectionnees.Add(attraction.Id);
            //TODO : Verifier possibilité d'ajout à l'itinéraire
            //System.Console.WriteLine("{0} has been toggled to {1}", attraction.Libelle, attraction.EstDejaDansLeParcours);
        }

        internal void ConvertFrom(List<Attraction> attractions)
        {
            var extractSubList = attractions.GroupBy(i => i.IdType);
            foreach (var subList in extractSubList)
            {
                var categorie = new Categorie(subList.Key.ToString());
                foreach (var item in subList)
                {
                    item.LienGif = "http://aaa.com/a.gif";
                    categorie.Add(item);
                }
                Listes.Add(categorie);
            }
            AddingEventToList();
        }

        void FilterListes()
        {
            ListesCount = Listes.Count;
            if (Listes != null && !TexteATrouver.Equals(""))
            {
                ListesBackup = Listes;
                Listes = Listes.Where(x => x.Any(a => a.Libelle.Contains(texteATrouver))).ToList();
                ListesCount = Listes.Count;
            }
            else
            {
                Listes = ListesBackup;
                ListesCount = Listes.Count;
            }
        }
        #endregion
    }
}
