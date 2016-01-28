using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using ParkHelper.Common.Models.Visite;
using ParkHelper.Common.WebService;

namespace ParkHelper.ViewModels
{
    public class SplashScreenViewModel : ViewModelBase
    {
        #region Fields

        readonly INavigationService _navigationService;
        public ParkHelper ApplicationContext;

        #endregion

        public SplashScreenViewModel(INavigationService navigationService)
        {
            if (navigationService == null)
                throw new ArgumentNullException(nameof(navigationService));

            _navigationService = navigationService;

            HomeCommand = new RelayCommand(() =>
            {
                _navigationService.NavigateTo(Locator.HomePage, ApplicationContext);
            });
        }

        public ICommand HomeCommand { get; set; }

        public async Task GetAttractionList()
        {
            ApplicationContext = new ParkHelper();
            var ws = new ParkHelperWebservice();
            ApplicationContext.requeteLieux = await ws.GetAttractions();
            ApplicationContext.HasApplicationList = true;
            ApplicationContext.ListeAppliSelectionnees = new List<int>();
            HomeCommand.Execute(ApplicationContext);
        }
    }
}
