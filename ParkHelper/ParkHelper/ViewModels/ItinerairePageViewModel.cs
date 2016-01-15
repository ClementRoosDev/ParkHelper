﻿using GalaSoft.MvvmLight;
using System;
using GalaSoft.MvvmLight.Views;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using ParkHelper.Common.Models;
using ParkHelper.Common.Models.Parcours;

namespace ParkHelper.ViewModels
{
    public class ItinerairePageViewModel : ViewModelBase
    {
        #region Fields

        readonly INavigationService _navigationService;

        private bool _isLoading;

        #endregion

        #region Contructor
        public ItinerairePageViewModel(INavigationService navigationService)
        {
            if (navigationService == null) throw new ArgumentNullException("navigationService");
            _navigationService = navigationService;

            HomeCommand = new RelayCommand(() =>
            {
                _navigationService.NavigateTo(
                    Locator.HomePage, Context);
            });
            ListPageCommand = new RelayCommand(() =>
            {
                _navigationService.NavigateTo(
                    Locator.ListPage, Context);
            });
            Listes = new List<ListeParcour>();
            ListesBis = new List<ListeParcour>();

            ListeIdAttractions = new List<int>();
            ParcoursFinal = new List<Parcours>();
        }


        #endregion

        #region Properties

        public ICommand HomeCommand { get; set; }

        public ICommand ListPageCommand { get; set; }

        public ParkHelper Context { get; set; }

        public List<ListeParcour> Listes { get; set; }
        public List<ListeParcour> ListesBis { get; set; }

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
                RaisePropertyChanged(() => IsLoadingCompleted);
            }
        }

        public bool IsLoadingCompleted
        {
            get
            {
                return !_isLoading;
            }
        }

        public List<int> ListeIdAttractions { get; set; }
        public List<Parcours> ParcoursFinal { get; set; }

        #endregion

        #region Methods

        public void OrderListeParcours()
        {
            int j = 1;
            for (int i = 0; i < Listes.Count; i++)
            {
                //if (Listes.ElementAt(i + 1).Ordre == (Listes.ElementAt(i).Ordre + 1) && (i+1) < (Listes.Count-1)) continue;
                if (Listes.ElementAt(i).Description == null)
                {
                    if (((i + 1) != (Listes.Count - 1)) && ((Listes.ElementAt(i + 1).Ordre == (Listes.ElementAt(i).Ordre + 1))))
                    {
                        Listes.ElementAt(i).Ordre = Listes.ElementAt(i - 1).Ordre;
                    }

                }
                else
                {
                    Listes.ElementAt(i).Ordre = j;
                    j++;
                }
            }
        }
        public void CreateParcours()
        {
            //var extractSubList = Listes.GroupBy(i => i.Ordre);
            /**foreach (var subList in extractSubList)
            {
                var etapeParcours = Listes.Where(i => i.Ordre == subList.Key).ToList().First();
                var parcours = new Parcours(subList.Key.ToString(),
                    new EtapeParcours(etapeParcours));
                for (var j = 1; j < */
                //subList.Count(); j++)
                /*{
                    parcours.Add(subList.ElementAt(j));
                }
                ParcoursFinal.Add(parcours);
            }*/
            foreach (var newParcours in Context.ListeAppliSelectionnees.Select(itemLieu => ListesBis.Where(i => i.Id == itemLieu).ToList().Single()).Select(itemInListe => new Parcours("1", new EtapeParcours(itemInListe))))
            {
                ParcoursFinal.Add(newParcours);
            }
            
        }

        public List<ListeParcour> ListesToDisplay { get; set; }

        public void ConvertFrom(List<ListeParcour> listeParcours)
        {
            //Listes from API,ListesBis from API with order, ListesToInsert = list with only ids to insert
            if (listeParcours == null) return;
            Listes = listeParcours;
            ListesBis = listeParcours.OrderBy(i => i.Id).ToList();
            ListesToInsert = listeParcours.OrderBy(i => i.Ordre).ToList();
            ListesToInsert = ListesToInsert.Where(f => f.Ordre > 0).ToList();

            //OrderListeParcours();
            CreateParcours();
        }

        public List<ListeParcour> ListesToInsert { get; set; }

        #endregion

        public void SetContext(ParkHelper context)
        {
            Context = context;
            ListeIdAttractions = Context.ListeAppliSelectionnees;
        }
    }
}
