using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using ParkHelper.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ParkHelper.ViewModels
{
    public class SplashScreenViewModel : ViewModelBase
    {
        #region Fields

        readonly INavigationService _navigationService;

        #endregion

        public SplashScreenViewModel(INavigationService navigationService)
        {
            if (navigationService == null)
                throw new ArgumentNullException("navigationService");

            _navigationService = navigationService;
            
            HomeCommand = new RelayCommand(() =>
            {
                _navigationService.NavigateTo(Locator.HomePage);
            });
            
            
        }

        public ICommand HomeCommand { get; set; }

        public async Task DelayExecution()
        {
            await Task.Delay(3000);
            HomeCommand.Execute(null);
        }
    }
}
