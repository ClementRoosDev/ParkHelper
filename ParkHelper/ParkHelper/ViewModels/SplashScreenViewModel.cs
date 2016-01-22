using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using ParkHelper.Common.WebService;

namespace ParkHelper.ViewModels
{
    public class SplashScreenViewModel : ViewModelBase
    {
        #region Fields

        readonly INavigationService _navigationService;
        public ParkHelper _applicationContext;

        #endregion

        public SplashScreenViewModel(INavigationService navigationService)
        {
            if (navigationService == null)
                throw new ArgumentNullException("navigationService");

            _navigationService = navigationService;

            HomeCommand = new RelayCommand(() =>
            {
                _navigationService.NavigateTo(Locator.HomePage, _applicationContext);
            });
        }

        public ICommand HomeCommand { get; set; }

        public async Task GetAttractionList()
        {
            _applicationContext = new ParkHelper();
            var Ws = new ParkHelperWebservice();
            _applicationContext.requeteLieux = await Ws.GetAttractions();
            _applicationContext.HasApplicationList = true;
            _applicationContext.ListeAppliSelectionnees = new List<int>();
            HomeCommand.Execute(_applicationContext);
        }
    }
}
