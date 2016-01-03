using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Attraction = ParkHelper.Common.Objets.Attraction;
using ParkHelper.ViewModels;

namespace ParkHelper.Views
{
    public partial class ListPage
    {
        private readonly ListPageViewModel _viewModel;

        public ListPage()
        {
            InitializeComponent();
            ListView.IsVisible = false;
            SearchBar.IsVisible = false;
            ItineraireCommand.IsVisible = false;
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

        private async void ListPage_OnAppearing(object sender, EventArgs e)
        {
            OnAppearing();
            var attractions = await GetConferences();
            if(attractions.Count > 0)
            {
                ListView.IsVisible = true;
                SearchBar.IsVisible = true;
                ItineraireCommand.IsVisible = true;
                ListView.ItemsSource = _viewModel.ConvertFrom(attractions);
                _viewModel.ItineraireCommand.CanExecute(null);
            }
            else
            {
                await DisplayAlert("Error", "Connection Error", "OK", "Cancel");
                System.Diagnostics.Debug.WriteLine("ERROR!");
            }
        }

        public async Task<List<Attraction>> GetConferences()
        {
            IEnumerable<Attraction> conferences = Enumerable.Empty<Attraction>();

            using (var httpClient = CreateClient())
            {
                var response = await httpClient.GetAsync("Attractions").ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    if (!string.IsNullOrWhiteSpace(json))
                    {
                        //TODO : Deserializer ici puis sotcker dans le VM
                        /**conferences = await Task.Run(() =>
                            //Mapper.Map<IEnumerable<Attraction>>(conferenceDtos)
                        ).ConfigureAwait(false);*/
                    }
                }
            }

            return conferences.ToList();
        }

        private const string ApiBaseAddress = "http://parkhelperodata.azurewebsites.net/odata/";

        private static HttpClient CreateClient()
        {
            var httpClient = new HttpClient
            {
                BaseAddress = new Uri(ApiBaseAddress)
            };

            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return httpClient;
        }

    }
}
