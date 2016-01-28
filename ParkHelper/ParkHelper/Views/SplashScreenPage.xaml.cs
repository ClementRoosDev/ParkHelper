using ParkHelper.ViewModels;
using System;
using System.Collections.Generic;

namespace ParkHelper.Views
{
    public partial class SplashScreenPage
    {
        readonly SplashScreenViewModel _viewModel;
        public SplashScreenPage()
        {
            InitializeComponent();
            _viewModel = App.Locator.SplashScreenView;
            BindingContext = _viewModel;
        }

        async void SplashScreen_OnAppearing(object sender, EventArgs e)
        {
            OnAppearing();
            try
            {
                await _viewModel.GetAttractionList();
            }
            catch (Exception)
            {
                await DisplayAlert("Error", "Connection Error", "OK");
                _viewModel.ApplicationContext.HasApplicationList = false;
                _viewModel.ApplicationContext.ListeAppliSelectionnees = new List<int>();
                _viewModel.HomeCommand.Execute(_viewModel.ApplicationContext);
            }   
        }
    }
}
