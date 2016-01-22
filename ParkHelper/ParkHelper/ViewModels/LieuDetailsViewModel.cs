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
        private Lieu lieu;
        private bool isAttraction;

        #endregion

        #region Constructor
        public LieuDetailsViewModel(INavigationService navigationService)
        {
            if (navigationService == null) throw new ArgumentNullException("navigationService");
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
            get { return lieu; }
            set
            {
                lieu = value;
                GetTexts(lieu);
            }
        }

        public bool IsAttraction
        {
            get
            {
                return isAttraction;
            }
            set
            {
                isAttraction = value;
                RaisePropertyChanged(() => IsAttraction);
            }
        }
        #endregion

        #region Methods
        private void GetTexts(Lieu lieuWithDetails)
        {
            isAttraction = lieuWithDetails.IdType == 1;
        }

        #endregion
    }
}
