using GalaSoft.MvvmLight;
using System;
using GalaSoft.MvvmLight.Views;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using ParkHelper.Common.Models;
using ParkHelper.Common.Models.Parcours;
using ParkHelper.Common.Models.Visite;

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

            ListeIdAttractions = new List<Location>();
        }


        #endregion

        #region Properties

        public ICommand HomeCommand { get; set; }

        public ICommand ListPageCommand { get; set; }

        public ParkHelper Context { get; set; }
        

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

        public List<Location> ListeIdAttractions { get; set; }

        public List<ListeParcour> listeParcours { get; set; }

        #endregion

        #region Methods


        public List<ListeParcour> ListesToDisplay { get; set; }

        public void ConvertFrom(List<ListeParcour> listeParcours)
        {
            listeParcours = listeParcours.OrderBy(c => c.Ordre).ToList();
            this.listeParcours = listeParcours;
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
