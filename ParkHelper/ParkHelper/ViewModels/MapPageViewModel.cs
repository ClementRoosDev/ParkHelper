using System;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;

namespace ParkHelper.ViewModels
{
    public class MapPageViewModel : ViewModelBase
    {
        //TODO : Finir la vue
        #region Fields

        INavigationService _navigationService;
        #endregion

        #region Constuctor
        public MapPageViewModel(INavigationService navigationService)
        {
            if (navigationService == null) throw new ArgumentNullException("navigationService");
            _navigationService = navigationService;

            HomeCommand = new RelayCommand(() => { _navigationService.GoBack(); });
        }

        #endregion

        #region Properties
        public ICommand HomeCommand { get; set; }
        #endregion

        #region Methods
        #endregion
    }
}
