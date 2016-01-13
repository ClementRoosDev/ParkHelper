using System;
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

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            var vm = BindingContext as VisiteDetailsViewModel;

            if (vm == null) return;
            UiPicker.Items.Clear();
            foreach (var it in vm.TempsEstime)
            {
                UiPicker.Items.Add(it);
            }
        }
    }
}
