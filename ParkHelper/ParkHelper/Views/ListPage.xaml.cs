using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ParkHelper.ViewModels;

namespace ParkHelper.Views
{
    using Newtonsoft.Json;
    using ParkHelper.Common.Objets;

    public partial class ListPage
    {
        readonly ListPageViewModel _viewModel;

        public ListPage()
        {
            InitializeComponent();
            setUIElements(false);
            this.ActivityIndicator.IsRunning = true;
            _viewModel = App.Locator.ListPageView;
            BindingContext = _viewModel;
            InitializeTemplate();
            
        }

        void InitializeTemplate()
        {
            ListView.ItemSelected += (sender, e) =>
            {
                var attraction = (Attraction)ListView.SelectedItem;
                _viewModel.Parameter = attraction;
                _viewModel.ItemDetailsCommand.Execute(_viewModel.Parameter);
            };
        }

        async void ListPage_OnAppearing(object sender, EventArgs e)
        {
            OnAppearing();
            var attractions = await GetAttractions();
            if(attractions.Count > 0)
            {
                setUIElements(true);
                _viewModel.ConvertFrom(attractions);
                ListView.ItemsSource = _viewModel.Listes;
                _viewModel.ItineraireCommand.CanExecute(null);
            }
            else
            {
                ActivityIndicator.IsRunning = false;
                await DisplayAlert("Error", "Connection Error", "OK", "Cancel");
                System.Diagnostics.Debug.WriteLine("ERROR!");
                _viewModel.HomeCommand.Execute(null);
            }
        }

        public async Task<List<Attraction>> GetAttractions()
        {
            IEnumerable<Attraction> attractions = Enumerable.Empty<Attraction>();

            using (var httpClient = CreateClient())
            {
                var response = await httpClient.GetAsync("Lieux").ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    if (!string.IsNullOrWhiteSpace(json))
                    {
                        var jsonv2 = json.Replace("odata.metadata", "metadata");
                        var objectWithFormat = JsonConvert.DeserializeObject<RequeteListe>(jsonv2);
                        return objectWithFormat.value;
                    }
                }
            }
            return attractions.ToList();
        }

        const string API_BASE_ADDRESS = "http://parkhelperodata.azurewebsites.net/odata/";

        static HttpClient CreateClient()
        {
            var httpClient = new HttpClient
            {
                BaseAddress = new Uri(API_BASE_ADDRESS)
            };

            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return httpClient;
        }

        void setUIElements(bool choixAappliquer)
        {
            ListView.IsVisible = choixAappliquer;
            SearchBar.IsVisible = choixAappliquer;
            ItineraireCommand.IsVisible = choixAappliquer;
        }
    }
}
