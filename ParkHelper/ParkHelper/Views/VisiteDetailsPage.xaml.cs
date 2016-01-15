using System;
using System.Diagnostics;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using ParkHelper.Common.Models.Visite;
using ParkHelper.Common.Models.RequeteListeLieux;
using ParkHelper.ViewModels;

namespace ParkHelper.Views
{
    public partial class VisiteDetailsPage
    {
        private readonly VisiteDetailsViewModel viewModel;

        public VisiteDetailsPage(ParkHelper context)
        {
            InitializeComponent();
            viewModel = App.Locator.VisiteDetailsPageView;
            viewModel.Context = context;
            InitailisationDeLaVisite(viewModel.Context);
            BindingContext = viewModel;
        }

        private void InitailisationDeLaVisite(ParkHelper context)
        {
            if(context.VisitePark == null)
            {
                viewModel.Context.VisitePark = new Informations
                {
                    Entree = DateTime.Now,
                    Sortie = DateTime.Now,
                    Nocturne = false,
                    Reservation = new Sejour
                    {
                        NumeroResa = 0,
                        Hotel = new Lieu(),
                        Chambre = 0,
                        NbPeople = 0
                    }
                };
            }
        }


        private void VisiteDetailsPage_OnAppearing(object sender, EventArgs e)
        {
            OnAppearing();
            var currentPageKeyString = ServiceLocator.Current
            .GetInstance<INavigationService>()
            .CurrentPageKey;
            Debug.WriteLine("Current page key: " + currentPageKeyString);
        }
    }
}
