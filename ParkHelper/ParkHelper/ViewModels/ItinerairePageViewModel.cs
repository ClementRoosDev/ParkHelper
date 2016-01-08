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
                    Locator.HomePage);
            });
            Listes = new List<ListeParcour>();
            IsBusy = true;

            ListeIdAttractions = new List<int>();
        }


        #endregion

        #region Properties
        
        #region General

        public ICommand HomeCommand { get; set; }

        #endregion
        
        #region Local
        public List<ListeParcour> Listes { get; set; }
        public bool IsBusy { get; set; }
        public List<int> ListeIdAttractions { get; set; }

        #endregion
        #endregion

        #region Methods

        public void ConvertFrom(List<ListeParcour> ListeParcours)
        {
            Listes = ListeParcours.OrderBy(i => i.Ordre).ToList();
        }
        #endregion
    }
}
