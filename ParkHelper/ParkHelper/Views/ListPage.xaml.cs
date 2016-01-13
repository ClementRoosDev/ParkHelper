using System;
using System.Linq;
using System.Threading.Tasks;
using ParkHelper.Common.Models.RequeteListeLieux;
using ParkHelper.ViewModels;
using ParkHelper.Common.WebService;
using Xamarin.Forms;

namespace ParkHelper.Views
{
    public partial class ListPage
    {
        readonly ListPageViewModel _viewModel;

        public ListPage(ParkHelper context)
        {
            InitializeComponent();
            _viewModel = App.Locator.ListPageView;
            _viewModel.Context = context;
            BindingContext = _viewModel;
            InitializeTemplate();
        }

        void InitializeTemplate()
        {
            ListView.ItemSelected += (sender, e) =>
            {
                var attraction = (Lieu)ListView.SelectedItem;
                _viewModel.Parameter = attraction;
                _viewModel.ItemDetailsCommand.Execute(_viewModel.Parameter);
            };
        }

        async void ListPage_OnAppearing(object sender, EventArgs e)
        {
            OnAppearing();
            setUIElements(false);
            _viewModel.TryToRestore();
            if(_viewModel.Listes.Count == 0)
            {
                ParkHelperWebservice Ws = new ParkHelperWebservice();
                 var objectWithFormat = await Ws.GetAttractions();

                await Task.Run(() =>
                    _viewModel.ConvertFrom(objectWithFormat.value)
                );

                if (_viewModel.Listes.Count > 0)
                {
                    ListView.ItemsSource = _viewModel.Listes;
                    _viewModel.ItineraireCommand.CanExecute(_viewModel.Listes);
                    setUIElements(true);
                }
                else
                {
                    ActivityIndicator.IsRunning = false;
                    await DisplayAlert("Error", "Connection Error", "OK", "Cancel");
                    System.Diagnostics.Debug.WriteLine("ERROR!");
                    _viewModel.HomeCommand.Execute(null);
                }
            }
        }
                          
        void setUIElements(bool choixAappliquer)
        {
            ListView.IsVisible = choixAappliquer;
            SearchBar.IsVisible = choixAappliquer;
            ItineraireCommand.IsVisible = choixAappliquer;
        }

        void SearchBar_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            ListView.BeginRefresh();

            ListView.ItemsSource = string.IsNullOrWhiteSpace(e.NewTextValue) ? _viewModel.Listes
                : _viewModel.Listes.Select(i => i.Where(a => a.Libelle.ToLower().Contains(e.NewTextValue.ToLower())));

            ListView.EndRefresh();
        }
    }
}
