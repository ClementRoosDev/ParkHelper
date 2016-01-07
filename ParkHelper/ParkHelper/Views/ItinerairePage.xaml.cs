using System;
using Xamarin.Forms;
using ParkHelper.Common.Objets;
using ParkHelper.ViewModels;
using System.Collections.Generic;

namespace ParkHelper.Views
{
    public partial class ItinerairePage : NavigationPage
    {
        ItinerairePageViewModel viewModel;

        public ItinerairePage(List<int> listeIdAttractions)
        {
            InitializeComponent();
            viewModel = App.Locator.ItineraireView;
            viewModel.ListeIdAttractions = listeIdAttractions;
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
