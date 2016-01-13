using System;
using ParkHelper.Common.Models.Visite;
using ParkHelper.ViewModels;

namespace ParkHelper.Views
{
    public partial class VisiteDetailsPage
    {
        public VisiteDetailsPage(ParkHelper context)
        {
            InitializeComponent();
            var viewModel = App.Locator.VisiteDetailsPageView;
            viewModel.Context = context;
            viewModel.Context.VisitePark = new Informations
            {
                Entree = DateTime.Now,
                Sortie = DateTime.Now,
                Nocturne = false,
                Reservation = new Hotel
                {
                    NumeroResa = 0,
                    Id = 0,
                    Chambre = 0,
                    NbPeople = 0
                }
            };
            BindingContext = viewModel;
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
