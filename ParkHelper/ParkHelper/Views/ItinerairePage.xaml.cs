using System;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Threading.Tasks;
using ParkHelper.Common.WebService;
using ParkHelper.ViewModels;

namespace ParkHelper.Views
{
    public partial class ItinerairePage
    {
        private ItinerairePageViewModel _viewModel;

        public ItinerairePage(List<int> listeIdAttractions)
        {
            InitializeComponent();
            setUIElements(false);
            _viewModel = App.Locator.ItineraireView;
            _viewModel.ListeIdAttractions = listeIdAttractions;
            _viewModel.IsBusy = true;
            BindingContext = _viewModel;
            _viewModel.IsBusy = false;
        }

        private void ItinerairePage_OnDisappearing(object sender, EventArgs e)
        {
            //viewModel.HomeCommand.Execute(null);
        }

        async void ItinerairePage_OnAppearing(object sender, EventArgs e)
        {
            OnAppearing();
            if (_viewModel.Listes.Count == 0)
            {
                var Ws = new ParkHelperWebservice();
                var objectWithFormat = await Ws.GetParcours(_viewModel.ListeIdAttractions);

                await Task.Run(() =>
                    _viewModel.ConvertFrom(objectWithFormat.ListeParcours)
                );

                if (_viewModel.Listes.Count > 0)
                {
                    ListView.ItemsSource = _viewModel.Listes;
                    setUIElements(true);
                }
                else
                {
                    //ActivityIndicator.IsRunning = false;
                    await DisplayAlert("Error", "Connection Error", "OK", "Cancel");
                    System.Diagnostics.Debug.WriteLine("ERROR!");
                    _viewModel.HomeCommand.Execute(null);
                }
            }
        }

        void setUIElements(bool choixAappliquer)
        {
            ListView.IsVisible = choixAappliquer;
        }
    }
}
