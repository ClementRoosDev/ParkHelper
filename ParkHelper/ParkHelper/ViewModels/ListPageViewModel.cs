﻿using System;
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
                    this.navigationService.NavigateTo(Locator.AttractionDetailsPage, Parameter);
                });

            ItineraireCommand = new RelayCommand(() =>
            {
                this.navigationService.NavigateTo(Locator.ItinerairePage, Parameter);
            });

            Attractions = new List<Attraction>();
            Listes = new List<Categorie>();
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

        void AddingEventToList()
        {
            foreach (var itemLieu in Listes.SelectMany(subList => subList))
            {
                itemLieu.OnToggled += ToggleSelection;
            }
        }

        static void ToggleSelection(object sender, EventArgs e)
        {
            var attraction = sender as Attraction;
            //TODO : Verifier possibilité d'ajout à l'itinéraire
            //System.Console.WriteLine("{0} has been toggled to {1}", attraction.Libelle, attraction.EstDejaDansLeParcours);
        }

        internal void ConvertFrom(List<Attraction> attractions)
        {
            //TODO : Fix a bug here, between these comments and the list with dummy datas
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

        #endregion
    }
}
