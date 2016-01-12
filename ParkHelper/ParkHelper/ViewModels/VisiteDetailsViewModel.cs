using System;
using System.Collections.Generic;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;

namespace ParkHelper.ViewModels
{
    public class VisiteDetailsViewModel : ViewModelBase
    {
        #region Fields
        readonly INavigationService _navigationService;

        #endregion

        #region Constructors

        public VisiteDetailsViewModel(INavigationService navigationService)
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
            EditHotelCommand = new RelayCommand(() =>
            {
                _navigationService.NavigateTo(
                    Locator.EditHotelDetailsPage, Context);
            });
            Durees = new List<int>
            {
                1,5,10,15,20,25,30,35,40,45,50,55,60
            };
        }
        #endregion

        #region Properties
        public ParkHelper Context { get; set; }
        public ICommand HomeCommand { get; set; }
        public ICommand ListPageCommand { get; set; }
        public ICommand EditHotelCommand { get; set; }
        public bool Nocturne { get; set; }
        public bool Hotel { get; set; }
        public List<int> Durees { get; set; } 
        #endregion

        #region Methods
        #endregion
    }
}
