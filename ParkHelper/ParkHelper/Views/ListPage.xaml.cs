using System;
using System.Diagnostics;
using System.Linq;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using ParkHelper.Common.Models.RequeteListeLieux;
using ParkHelper.Common.Models.Visite;
using ParkHelper.ViewModels;
using Xamarin.Forms;

namespace ParkHelper.Views
{
    public partial class ListPage
    {
        private readonly ListPageViewModel _viewModel;
        RequeteListe requeteLieux;

        public ListPage(ParkHelper context)
        {
            InitializeComponent();
            _viewModel = App.Locator.ListPageView;
            _viewModel.Context = context;
            requeteLieux = context.requeteLieux;
            BindingContext = _viewModel;
            InitializeTemplate();
        }


        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            var vm = BindingContext as ListPageViewModel;

            if (vm == null) return;
            UiPicker.Items.Clear();
            foreach (var it in vm.TempsEstime)
            {
                UiPicker.Items.Add(it);
            }
        }

        private void InitializeTemplate()
        {
            ListViewCategories.ItemSelected += (sender, e) =>
            {
                var attraction = (Lieu) ListViewCategories.SelectedItem;
                _viewModel.Parameter = attraction;
                _viewModel.ItemDetailsCommand.Execute(_viewModel.Parameter);
            };
        }

        private async void ListPage_OnAppearing(object sender, EventArgs e)
        {
            OnAppearing();
            var currentPageKeyString = ServiceLocator.Current
                .GetInstance<INavigationService>()
                .CurrentPageKey;
            Debug.WriteLine("Current page key: " + currentPageKeyString);

            if (_viewModel.Context.VisitePark == null)
            {
                _viewModel.Context.VisitePark = new Informations
                {
                    Entree = DateTime.Now,
                    Sortie = DateTime.Now,
                    Nocturne = false,
                };
            }

            _viewModel.IsLoading = true;

            _viewModel.TryToRestore();


            if (_viewModel.Listes.Count == 0)
            {
                try
                {
                    //var Ws = new ParkHelperWebservice();
                    //RequeteListe requeteLieux = await Ws.GetAttractions();

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
                    Debug.WriteLine(ex.Message);
                }
            }
            else
            {
                ListViewCategories.ItemsSource = _viewModel.Listes;
            }
            _viewModel.IsLoading = false;
        }

        private void SearchBar_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            ListViewCategories.BeginRefresh();

            ListViewCategories.ItemsSource = string.IsNullOrWhiteSpace(e.NewTextValue)
                ? _viewModel.Listes
                : _viewModel.Listes.Select(i => i.Where(a => a.Libelle.ToLower().Contains(e.NewTextValue.ToLower())));

            ListViewCategories.EndRefresh();
        }
    }
}