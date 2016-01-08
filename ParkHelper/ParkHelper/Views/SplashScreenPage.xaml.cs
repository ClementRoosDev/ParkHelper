using GalaSoft.MvvmLight.Views;
using ParkHelper.Helper;
using ParkHelper.ViewModels;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ParkHelper.Views
{
    public partial class SplashScreenPage
    {
        SplashScreenViewModel viewModel;
        public SplashScreenPage()
        {
            InitializeComponent();           

            viewModel = App.Locator.SplashScreenView;
            BindingContext = viewModel;
        }

        async void SplashScreen_OnAppearing(object sender, EventArgs e)
        {
            OnAppearing();

            await viewModel.DelayExecution();
        }
    }
}
