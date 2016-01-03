using System;
using Xamarin.Forms;
using ParkHelper.Common.Objets;
using ParkHelper.ViewModels;

namespace ParkHelper.Views
{
    public partial class ItinerairePage : NavigationPage
    {
        ItinerairePageViewModel viewModel;

        public ItinerairePage(Attraction attraction)
        {
            InitializeComponent();
            viewModel = App.Locator.ItineraireView;
            viewModel.Parameter = attraction;
            viewModel.IsBusy = true;
            /**if (viewModel.Listes.Count == 0)
            {
                viewModel.InitListAttractions();
            }*/
            BindingContext = viewModel;
            viewModel.IsBusy = false;
        }

        private void ItinerairePage_OnDisappearing(object sender, EventArgs e)
        {
            //viewModel.HomeCommand.Execute(null);
        }
    }
}
