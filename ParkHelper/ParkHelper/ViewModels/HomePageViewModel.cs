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
            if (navigationService == null) throw new ArgumentNullException(nameof(navigationService));
            _navigationService = navigationService;

            MapCommand = new RelayCommand(() =>
            {
                _navigationService.NavigateTo(
                    Locator.MapPage);
            });
            VisiteCommand = new RelayCommand(() =>
            {
                _navigationService.NavigateTo(
                    Locator.ListPage, Context);
            });
        }
        #endregion
        
        #region Properties

        public string TextTest { get; set; }
        public ICommand VisiteCommand { get; set; }
        public ICommand MapCommand { get; set; }
        public ParkHelper Context { get; set; }
        public bool IsListFilled { get; set; }

        #endregion
    }
}
