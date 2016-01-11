using Newtonsoft.Json;
using ParkHelper.Common.Objets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ParkHelper.Common.WebService
{
    public class ParkHelperWebservice
    {
        public async Task<RequeteListe> GetAttractions()
        {
            RequeteListe result = new RequeteListe();
            using (var httpClient = CreateClient(Path.ODATA))
            {
                // Latittude greater than 1 & IdEtat equal 1
                var response = await httpClient.GetAsync("Lieux?$filter=Latittude%20gt%201&$expand=TypeDeLieu,Indications").ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    if (!string.IsNullOrWhiteSpace(json))
                    {
                        var jsonv2 = json.Replace("odata.metadata", "metadata");
                        result = JsonConvert.DeserializeObject<RequeteListe>(jsonv2);
                    }
                }
            }
            return result;
        }

        public async Task<RequeteListeParcours> GetParcours(List<int> ListeIdLieux)
        {
            RequeteListeParcours result = new RequeteListeParcours();
            using (var httpClient = CreateClient(Path.API))
            {
                string query = BuildParcoursQueryFromIds(ListeIdLieux);

                var response = await httpClient.GetAsync(query).ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    if (!string.IsNullOrWhiteSpace(json))
                    {
                        var jsonv2 = json.Replace("odata.metadata", "metadata");
                        result = JsonConvert.DeserializeObject<RequeteListeParcours>(jsonv2);
                    }
                }
            }
            return result;
        }

        const string ODATA_BASE_ADDRESS = "http://parkhelperodata.azurewebsites.net/odata/";

        const string API_BASE_ADDRESS = "http://parkhelperodata.azurewebsites.net/api/";

        private HttpClient CreateClient(Path path)
        {
            var httpClient = new HttpClient();

            if (path == Path.API)
                httpClient.BaseAddress = new Uri(API_BASE_ADDRESS);

            if (path == Path.ODATA)
                httpClient.BaseAddress = new Uri(ODATA_BASE_ADDRESS);

            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return httpClient;
        }

        private string BuildParcoursQueryFromIds(List<int> ListeIdLieux)
        {
            string result = "values?";
            foreach (var item in ListeIdLieux)
            {
                result += "values=" + item+"&";
            }
            result.Remove(result.Length - 1);

            return result;
        }
    }

    public enum Path
    {
        ODATA = 1,
        API = 2
    }
}
