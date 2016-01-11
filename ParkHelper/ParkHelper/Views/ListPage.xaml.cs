using System;
using System.Threading.Tasks;
using ParkHelper.ViewModels;
using ParkHelper.Common.Objets;
using ParkHelper.Common.WebService;

namespace ParkHelper.Views
{
    public partial class ListPage
    {
        readonly ListPageViewModel _viewModel;

        public ListPage(ParkHelper context)
        {
            InitializeComponent();
            setUIElements(false);
            this.ActivityIndicator.IsRunning = true;
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

        void SearchBar_OnPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            /**if (SearchBar != null && _viewModel!=null && !SearchBar.Text.Equals("Rechercher") &&
            _viewModel.Listes.Count < _viewModel.ListesCount && _viewModel.Listes.Count > 0)
            {
                ListView.ItemsSource = _viewModel.Listes;
            }*/
        }

        void SearchBar_OnTextChanged(object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            if (!SearchBar.Text.Equals("Rechercher") &&
                _viewModel.Listes.Count < _viewModel.ListesCount && _viewModel.Listes.Count > 0)
            {
                ListView.ItemsSource = _viewModel.Listes;
            }
        }
    }
}
