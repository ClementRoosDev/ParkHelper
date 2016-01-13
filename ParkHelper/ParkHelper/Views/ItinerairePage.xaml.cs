using System;
using System.Threading.Tasks;
using ParkHelper.Common.WebService;
using ParkHelper.ViewModels;

namespace ParkHelper.Views
{
    public partial class ItinerairePage
    {
        private readonly ItinerairePageViewModel _viewModel;

        public ItinerairePage(ParkHelper context)
        {
            InitializeComponent();
            setUIElements(false);
            _viewModel = App.Locator.ItineraireView;
            _viewModel.SetContext(context);
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
                var Ws = new ParkHelperWebservice();
                var objectWithFormat = await Ws.GetParcours(_viewModel.ListeIdAttractions);

                await Task.Run(() =>
                    _viewModel.ConvertFrom(objectWithFormat.ListeParcours)
                );

            if (objectWithFormat.ListeParcours != null)
            {
                if (_viewModel.Listes.Count > 0)
                {
                    ListView.ItemsSource = _viewModel.ParcoursFinal;
                    setUIElements(true);
                }
                else
                {
                    await DisplayAlert("Erreur", "Retour à la page des attractions", "OK");
                    System.Diagnostics.Debug.WriteLine("ERROR!");
                    _viewModel.ListPageCommand.Execute(_viewModel.Context);
                }
            }
            else
            {
                //ActivityIndicator.IsRunning = false;
                await DisplayAlert("Erreur", "Connection Error", "OK");
                System.Diagnostics.Debug.WriteLine("ERROR!");
                _viewModel.HomeCommand.Execute(null);
            }

        }

        void setUIElements(bool choixAappliquer)
        {
            ListView.IsVisible = choixAappliquer;
        }
    }
}
