using System;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;

namespace ParkHelper.ViewModels
{
    public class EditHotelPageViewModel : ViewModelBase
    {
        #region Fields
        readonly INavigationService _navigationService;

        #endregion

        #region Constructors

        public EditHotelPageViewModel(INavigationService navigationService)
        {
            if (navigationService == null) throw new ArgumentNullException("navigationService");
            _navigationService = navigationService;

            VisiteCommand = new RelayCommand(() =>
            {
                _navigationService.NavigateTo(
                    Locator.VisiteDetailsPage, Context);
            });
        }
        #endregion

        #region Properties
        public ParkHelper Context { get; set; }
        public ICommand VisiteCommand { get; set; }
        #endregion

        #region Methods
        #endregion
    }
}
