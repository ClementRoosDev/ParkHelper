using System;
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
            BindingContext = _viewModel;
        }

        async void ItinerairePage_OnAppearing(object sender, EventArgs e)
        {
            OnAppearing();
            _viewModel.IsLoading = true;

            try
            {
                var Ws = new ParkHelperWebservice();
                var objectWithFormat = await Ws.GetParcours(_viewModel.ListeIdAttractions);

                _viewModel.ConvertFrom(objectWithFormat.ListeParcours);

                if (objectWithFormat.ListeParcours != null)
                {
                    if (_viewModel.listeParcours.Count > 0)
                    {
                        ListView.ItemsSource = _viewModel.listeParcours;
                        setUIElements(true);
                    }
                    else
                    {
                        await DisplayAlert("Erreur", "Liste = 0", "OK");
                        System.Diagnostics.Debug.WriteLine("ERROR!");
                        _viewModel.ListPageCommand.Execute(_viewModel.Context);
                    }
                }
                else
                {
                    await DisplayAlert("Erreur", "Parcours is null", "OK");
                    _viewModel.HomeCommand.Execute(null);
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "Connection Error", "OK", "Cancel");
                _viewModel.IsLoading = true;
                _viewModel.HomeCommand.Execute(null);
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }


            _viewModel.IsLoading = false;

        }

        void setUIElements(bool choixAappliquer)
        {
            ListView.IsVisible = choixAappliquer;
        }
    }
}
