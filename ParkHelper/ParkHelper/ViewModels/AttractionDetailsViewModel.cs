using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using ParkHelper.Common.Objets;

namespace ParkHelper.ViewModels
{
    public class AttractionDetailsViewModel : ViewModelBase
    {
        #region Fields
        private readonly INavigationService _navigationService;
        #endregion
        #region Constructor
        public AttractionDetailsViewModel(INavigationService navigationService)
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
        public string Attraction { get; set; }
        #endregion
        #region Methods
        #endregion
    }
}
