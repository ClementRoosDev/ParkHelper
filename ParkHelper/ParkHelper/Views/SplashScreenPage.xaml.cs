using GalaSoft.MvvmLight.Views;
using ParkHelper.Helper;
using ParkHelper.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ParkHelper.Common.Models.Visite;
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
            try
            {
                await viewModel.GetAttractionList();
            }
            catch (Exception)
            {
                await DisplayAlert("Error", "Connection Error", "OK");
                viewModel._applicationContext.HasApplicationList = false;
                viewModel._applicationContext.ListeAppliSelectionnees = new List<Location>();
                viewModel.HomeCommand.Execute(viewModel._applicationContext);
            }
            

            
        }
    }
}
