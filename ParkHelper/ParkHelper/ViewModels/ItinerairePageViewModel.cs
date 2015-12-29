using GalaSoft.MvvmLight;
using System;
using GalaSoft.MvvmLight.Views;

namespace ParkHelper.ViewModels
{
    using System.Windows.Input;
    using GalaSoft.MvvmLight.Command;

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
        }
        #endregion

        #region Properties
        public ICommand HomeCommand { get; set; }
        #endregion

        #region Methods
        #endregion
    }
}
