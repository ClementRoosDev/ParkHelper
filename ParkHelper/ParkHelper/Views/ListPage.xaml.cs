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
            ListViewCategories.ItemSelected += (sender, e) =>
            {
                var attraction = (Lieu)ListViewCategories.SelectedItem;
                _viewModel.Parameter = attraction;
                _viewModel.ItemDetailsCommand.Execute(_viewModel.Parameter);
            };
        }

        async void ListPage_OnAppearing(object sender, EventArgs e)
        {
            OnAppearing();

            _viewModel.IsLoading = true;

            _viewModel.TryToRestore();


            if (_viewModel.Listes.Count == 0)
            {
                try
                {
                    ParkHelperWebservice Ws = new ParkHelperWebservice();
                    RequeteListe requeteLieux = await Ws.GetAttractions(_viewModel.Context.VisitePark);

                    _viewModel.ConvertFrom(requeteLieux.value);

                    if (_viewModel.Listes.Count > 0)
                    {
                        ListViewCategories.ItemsSource = _viewModel.Listes;
                        _viewModel.ItineraireCommand.CanExecute(_viewModel.Listes);
                    }
                    else
                    {
                        await DisplayAlert("Error", "Connection Error", "OK", "Cancel");
                        _viewModel.HomeCommand.Execute(null);
                    }
                }
                catch (Exception ex)
                {
                    await DisplayAlert("Error", "Connection Error", "OK", "Cancel");
                    _viewModel.HomeCommand.Execute(null);
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
            }
            else
            {
                ListViewCategories.ItemsSource = _viewModel.Listes;
            }
            _viewModel.IsLoading = false;
        }

        void SearchBar_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            ListViewCategories.BeginRefresh();

            ListViewCategories.ItemsSource = string.IsNullOrWhiteSpace(e.NewTextValue) ? _viewModel.Listes
                : _viewModel.Listes.Select(i => i.Where(a => a.Libelle.ToLower().Contains(e.NewTextValue.ToLower())));

            ListViewCategories.EndRefresh();
        }
    }
}
