using System;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using Xamarin.Forms;

namespace ParkHelper.ViewModels
{
    public class HomePageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        #region Fields

        #endregion

        #region Constuctor
        public HomePageViewModel(INavigationService navigationService)
        {
            if (navigationService == null) throw new ArgumentNullException("navigationService");
            _navigationService = navigationService;

            ItineraireCommand = new RelayCommand(() =>
            {
                _navigationService.NavigateTo(
                    Locator.ListPage);
            });

            MapCommand = new RelayCommand(() =>
            {
                _navigationService.NavigateTo(
                    Locator.MapPage);
            });
        }
        #endregion

        #region Properties
        public string TextTest { get; set; } = "THIS IS A TEST ! Je suis un fraisier";
        public ICommand ItineraireCommand { get; set; }
        public ICommand MapCommand { get; set; }
        #endregion

        #region Methods
        #endregion
    }
}
