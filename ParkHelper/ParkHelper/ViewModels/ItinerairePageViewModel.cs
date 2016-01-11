using GalaSoft.MvvmLight;
using System;
using GalaSoft.MvvmLight.Views;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using ParkHelper.Common.Objets;
using ParkHelper.Model;

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
                    Locator.HomePage, Context);
            });
            ListPageCommand = new RelayCommand(() =>
            {
                _navigationService.NavigateTo(
                    Locator.ListPage, Context);
            });
            Listes = new List<ListeParcour>();
            ListesBis = new List<ListeParcour>();
            IsBusy = true;

            ListeIdAttractions = new List<int>();
            ParcoursFinal = new List<Parcours>();
        }


        #endregion

        #region Properties
        
        #region General

        public ICommand HomeCommand { get; set; }

        public ICommand ListPageCommand { get; set; }

        public ParkHelper Context { get; set; }
        #endregion

        #region Local
        public List<ListeParcour> Listes { get; set; }
        public List<ListeParcour> ListesBis { get; set; }
        public bool IsBusy { get; set; }
        public List<int> ListeIdAttractions { get; set; }
        public List<Parcours> ParcoursFinal { get; set; }

        #endregion
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
                    if(((i + 1) != (Listes.Count - 1)) && ((Listes.ElementAt(i + 1).Ordre == (Listes.ElementAt(i).Ordre + 1))))
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
            var extractSubList = Listes.GroupBy(i => i.Ordre);
            foreach (var subList in extractSubList)
            {
                var etapeParcours = Listes.Where(i => i.Ordre == subList.Key).ToList().First();
                var parcours = new Parcours(subList.Key.ToString(),
                    new EtapeParcours(etapeParcours));
                for(var j = 1;j <subList.Count();j++)
                {
                    parcours.Add(subList.ElementAt(j));
                }
                ParcoursFinal.Add(parcours);
            }
        }

        public void ConvertFrom(List<ListeParcour> listeParcours)
        {
            if (listeParcours == null) return;
            ListesBis = listeParcours.OrderBy(i => i.Ordre).ToList();
            Listes = ListesBis;
            OrderListeParcours();
            CreateParcours();
        }

        #endregion

        public void SetContext(ParkHelper context)
        {
            Context = context;
            ListeIdAttractions = Context.ListeAppliSelectionnees;
        }
    }
}
