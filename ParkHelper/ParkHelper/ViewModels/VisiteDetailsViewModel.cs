using System;
using System.Collections.Generic;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;

// ReSharper disable SwitchStatementMissingSomeCases

namespace ParkHelper.ViewModels
{
    public class VisiteDetailsViewModel : ViewModelBase
    {
        #region Fields
        readonly INavigationService _navigationService;
        private int _choixPauseDej;
        private bool _hotel;

        #endregion

        #region Constructors

        public VisiteDetailsViewModel(INavigationService navigationService)
        {
            if (navigationService == null) throw new ArgumentNullException("navigationService");
            _navigationService = navigationService;

            HomeCommand = new RelayCommand(() => {
                _navigationService.GoBack();
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

            TempsEstime = new List<string>
            {
                "0","5","10","15","20","25","30","35","40","45","50","55","1h","1h15","1h30","1h45","2h"
            };
        }
        #endregion

        #region Properties
        #region Visite
        
        #endregion

        #region Commands
        public ICommand HomeCommand { get; set; }
        public ICommand ListPageCommand { get; set; }
        public ICommand EditHotelCommand { get; set; }
        #endregion

        #region Hotel

        public bool Hotel
        {
            get
            {
                return _hotel;
            }
            set
            {
                _hotel = value;
                RaisePropertyChanged(() => Hotel);
            }
        }
        #endregion
        public ParkHelper Context { get; set; }
        public List<string> TempsEstime { get; set; } 
        public int ChoixPauseDej
        {
            get
            {
                return _choixPauseDej;
            }
            set
            {
                _choixPauseDej = value;
                Context.VisitePark.DureePauseDej = ConvertToValue(_choixPauseDej);
            }
        }
        #endregion

        #region Methods
        private static int ConvertToValue(int s)
        {
            switch (s)
            {
                case 16:
                    return 120;
                case 15:
                    return 105;
                case 14:
                    return 90;
                case 13:
                    return 75;
                case 12:
                    return 60;
            }
            return s;
        }
        #endregion
    }
}
