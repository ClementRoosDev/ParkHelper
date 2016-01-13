using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using ParkHelper.Common.Models.RequeteListeLieux;

namespace ParkHelperPortableDataTest
{
    class Version1 : ITest
    {
        const string Urlattractions = "http://parkhelperapi.azurewebsites.net/api/ptattractions?type=json";
        const string Urlparours = "http://parkhelperapi.azurewebsites.net/api/ptparcours?type=json";

        public List<Lieu> Attractions { get; private set; }

        public Version1()
        {
            Attractions = new List<Lieu>();
        }

        public async Task<List<Lieu>> getAttractions(string urlAttractions)
        {
            MediaTypeWithQualityHeaderValue jsonHeader = new MediaTypeWithQualityHeaderValue("application/json");

            using (var client = new HttpClient() { BaseAddress = new Uri(urlAttractions) })
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(jsonHeader);
                const string query = "";
                var apiResponse = await client.GetAsync(query).ConfigureAwait(false);

                if (!apiResponse.IsSuccessStatusCode)
                {
                    return null;
                }
                var result = await apiResponse.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<List<Lieu>>(result);
            }
        }

        public void getParcours(string parcours)
        {
        }

        public void Update()
        {
            Attractions = getAttractions(Urlattractions).Result;
        }
    }
}
