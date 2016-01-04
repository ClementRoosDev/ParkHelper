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
            var attractions = await GetConferences();
            if(attractions.Count > 0)
            {
                setUIElements(true);
                ListView.ItemsSource = _viewModel.ConvertFrom(attractions);
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

        public async Task<List<Attraction>> GetConferences()
        {
            IEnumerable<Attraction> attractions = Enumerable.Empty<Attraction>();

            using (var httpClient = CreateClient())
            {
                var response = await httpClient.GetAsync("Lieux").ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    //var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    var json = "{\r\n  \"odata.metadata\":\"http://parkhelperodata.azurewebsites.net/odata/$metadata#Lieux\"," +
                               "\"value\":[\r\n    {\r\n      \"Id\":1,\"Libelle\":\"Tonnerre de Zeus\"," +
                               "\"Description\":\"Montez au sommet de l\\u2019Olympe et lancez-vous dans une descente vertigineuse de plus de 30 m\\u00e8tres !\\r\\n\"," +
                               "\"LienGif\":null,\"Latittude\":8.0,\"Longitude\":3.0,\"Attente\":20,\"Duree\":10,\"CapaciteWagon\":4,\"IdType\":1,\"Ordre\":0," +
                               "\"EstDejaDansLeParcours\":false\r\n    },{\r\n      \"Id\":2,\"Libelle\":\"Goudurix\"," +
                               "\"Description\":\"Le grand huit aux 7 loopings pour ceux qui ont le go\\u00fbt du risque\\r\\n\"," +
                               "\"LienGif\":null,\"Latittude\":15.0,\"Longitude\":10.0,\"Attente\":15,\"Duree\":20,\"CapaciteWagon\":3," +
                               "\"IdType\":1,\"Ordre\":0,\"EstDejaDansLeParcours\":false\r\n    },{\r\n      \"Id\":3," +
                               "\"Libelle\":\"La trace du houra\",\"Description\":\"Vivez une exp\\u00e9rience de glisse incomparable \\u00e0 pr\\u00e8s de 60km/h\\r\\n\"," +
                               "\"LienGif\":null,\"Latittude\":18.0,\"Longitude\":2.0,\"Attente\":10,\"Duree\":30,\"CapaciteWagon\":4,\"IdType\":2,\"Ordre\":0," +
                               "\"EstDejaDansLeParcours\":false\r\n    },{\r\n      \"Id\":4,\"Libelle\":\"Le grand splash\"," +
                               "\"Description\":\"N\\u2019ayez pas peur des \\u00e9claboussures\",\"LienGif\":null,\"Latittude\":13.0," +
                               "\"Longitude\":8.0,\"Attente\":25,\"Duree\":15,\"CapaciteWagon\":4,\"IdType\":3,\"Ordre\":0,\"EstDejaDansLeParcours\":false\r\n    }\r\n  ]\r\n}";
                    if (!string.IsNullOrWhiteSpace(json))
                    {
                        //TODO : Deserializer ici puis sotcker dans le VM
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
