using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ParkHelperPortableDataTest
{
    class Program
    {
        private const string Urlattractions = "http://parkhelperapi.azurewebsites.net/api/ptattractions?type=json";

        private const string Urlparours = "http://parkhelperapi.azurewebsites.net/api/ptparcours?type=json";

        static void Main(string[] args)
        {
            var attractions = getAttractions();
            var result = attractions.Result;
            foreach (var item in result)
            {
                Console.WriteLine(item.Id);
                Console.WriteLine(item.Attente);
                Console.WriteLine(item.CapaciteWagon);
                Console.WriteLine(item.Description);
                Console.WriteLine(item.Libelle);
                Console.WriteLine(item.Duree);
                Console.WriteLine(item.EstDejaDansLeParcours);
                Console.WriteLine(item.Latittude);
                Console.WriteLine(item.Longitude);
                Console.WriteLine(item.LienGif);
                Console.WriteLine(item.Ordre);
                Console.WriteLine(item.IdType);
                Console.WriteLine("-----------------------------------------------------");
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

                    return JsonConvert.DeserializeObject<List<Attraction>>(result);
                }
                return null;
            }
        }
    }

    class Attraction
    {
        public object Type { get; set; }
        public int Id { get; set; }
        public string Libelle { get; set; }
        public string Description { get; set; }
        public object LienGif { get; set; }
        public double Latittude { get; set; }
        public double Longitude { get; set; }
        public int Attente { get; set; }
        public int CapaciteWagon { get; set; }
        public object IdType { get; set; }
        public int Duree { get; set; }
        public bool EstDejaDansLeParcours { get; set; }
        public int Ordre { get; set; }
    }
}
