using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using ParkHelper.Common.Objets;

namespace ParkHelperPortableDataTest
{
    class Version1 : ITest
    {
        const string Urlattractions = "http://parkhelperapi.azurewebsites.net/api/ptattractions?type=json";
        const string Urlparours = "http://parkhelperapi.azurewebsites.net/api/ptparcours?type=json";

        public List<Attraction> Attractions { get; private set; }

        public Version1()
        {
            Attractions = new List<Attraction>();
        }

        public async Task<List<Attraction>> getAttractions(string urlAttractions)
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

                return JsonConvert.DeserializeObject<List<Attraction>>(result);
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
