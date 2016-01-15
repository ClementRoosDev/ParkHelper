using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ParkHelper.ViewModels
{
    public class SplashScreenViewModel : ViewModelBase
    {
        #region Fields

        readonly INavigationService _navigationService;
        private ParkHelper _applicationContext;

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

        public async Task DelayExecution()
        {
            await Task.Delay(3000);
            _applicationContext = new ParkHelper();
            _applicationContext.ListeAppliSelectionnees = new List<int>();
            HomeCommand.Execute(_applicationContext);
        }
    }
}
