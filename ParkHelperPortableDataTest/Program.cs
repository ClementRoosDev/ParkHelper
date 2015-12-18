using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ParkHelperPortableDataTest
{
    class Program
    {
        private const string Urlattractions = "http://parkhelperapi.azurewebsites.net/api/ptattractions";

        private const string Urlparours = "http://parkhelperapi.azurewebsites.net/api/ptattractions";

        static void Main(string[] args)
        {
            var attractions = getAttractions();
            foreach (var item in attractions.Result)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }

        public async static Task<List<Attraction>> getAttractions()
        {
            var attractions = new List<Attraction>();
            MediaTypeWithQualityHeaderValue jsonHeader = new MediaTypeWithQualityHeaderValue("application/json");

            using (var client = new HttpClient() { BaseAddress = new Uri(Urlattractions) })
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(jsonHeader);
                string query = "";
                HttpResponseMessage apiResponse = await client.GetAsync(query).ConfigureAwait(false);

                if (apiResponse.IsSuccessStatusCode)
                {
                    var result = await apiResponse.Content.ReadAsStringAsync();

                    attractions.AddRange(result.Split(',').ToList().Select(JsonConvert.DeserializeObject<Attraction>));
                    return attractions;
                }
                return null;
            }
        }
    }

    class Attraction
    {
        private int Id { get; set; }
        private string Libelle { get; set; }
    }
}
