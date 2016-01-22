using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ParkHelper.Common.Models;
using ParkHelper.Common.Models.RequeteListeLieux;
using ParkHelper.Common.Models.Visite;

namespace ParkHelper.Common.WebService
{
    public class ParkHelperWebservice
    {
        public async Task<RequeteListe> GetAttractions()
        {
            RequeteListe result = new RequeteListe();
            using (var httpClient = CreateClient(Path.ODATA))
            {
                // fututre query Lieux()?$filter=Latittude gt 1.0 and 
                //Plannings /any(a:a/idNumeroJour ge 1 and a/idNumeroJour le 3 and a/idMois eq 1)
                //&$expand=Plannings,Indications
                var response = await httpClient.GetAsync("Lieux?$filter=Latittude%20gt%201&$expand=TypeDeLieu").ConfigureAwait(false);
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

        public async Task<RequeteListeParcours> GetParcours(List<Location> ListeIdLieux)
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

        private string BuildParcoursQueryFromIds(List<Location> ListeIdLieux)
        {
            string result = "values?";
            /**foreach (var item in ListeIdLieux)
            {
                result += "values=" + item+"&";
            }*/
            foreach (var item in ListeIdLieux)
            {
                //result += "locations=" + item + "&";
                result += "locations=" + new
                {
                    item.X,
                    item.Y
                } + "&";
            }
            var resultClean = result.Remove(result.Length - 1);
            
            return resultClean;
        }
    }

    public enum Path
    {
        ODATA = 1,
        API = 2
    }
}
