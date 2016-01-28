using System;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using ParkHelper.Common.Models.RequeteListeLieux;

namespace ParkHelper.ViewModels
{
    public class LieuDetailsViewModel : ViewModelBase
    {
        #region Fields
        readonly INavigationService _navigationService;
        private Lieu _lieu;
        private bool _isAttraction;

        #endregion

        #region Constructor
        public LieuDetailsViewModel(INavigationService navigationService)
        {
            if (navigationService == null) throw new ArgumentNullException(nameof(navigationService));
            _navigationService = navigationService;

            ItineraireCommand = new RelayCommand(() =>
            {
                _navigationService.NavigateTo(
                    Locator.ListPage);
            });
        }
        #endregion

        #region Properties
        public ICommand ItineraireCommand { get; set; }

        public Lieu Lieu
        {
            get { return _lieu; }
            set
            {
                _lieu = value;
                GetTexts(_lieu);
            }
        }

        public bool IsAttraction
        {
            get
            {
                return _isAttraction;
            }
            set
            {
                _isAttraction = value;
                RaisePropertyChanged(() => IsAttraction);
            }
        }
        #endregion

        #region Methods
        private void GetTexts(Lieu lieuWithDetails)
        {
            _isAttraction = lieuWithDetails.IdType == 1;
        }

        #endregion
    }
}
