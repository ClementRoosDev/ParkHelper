using System;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;

namespace ParkHelper.ViewModels
{
    public class HomePageViewModel : ViewModelBase
    {
        #region Fields

        readonly INavigationService _navigationService;

        #endregion

        #region Constuctor
        public HomePageViewModel(INavigationService navigationService)
        {
            if (navigationService == null) throw new ArgumentNullException("navigationService");
            _navigationService = navigationService;

            MapCommand = new RelayCommand(() =>
            {
                _navigationService.NavigateTo(
                    Locator.MapPage);
            });
            TextTest = "THIS IS A TEST ! Je suis un fraisier";
            TryToOpenItineraire();
        }
        #endregion
        
        #region Properties

        public string TextTest { get; set; }
        public ICommand ItineraireCommand { get; set; }
        public ICommand MapCommand { get; set; }

        #endregion

        #region Methods

        void TryToOpenItineraire()
        {
            //fileName = "";
            //if()
            ItineraireCommand = new RelayCommand(() =>
            {
                _navigationService.NavigateTo(
                    Locator.ListPage);
            });
            /**}else{
            ItineraireCommand = new RelayCommand(() =>
            {
                _navigationService.NavigateTo(
                    Locator.ItinerairePage, fileName);
            });
            }*/
        }
        #endregion
    }
}
