﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ParkHelper.Common.Models;
using ParkHelper.Common.Models.RequeteListeLieux;

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
                var response = await httpClient.GetAsync("Lieux?$filter=Latittude%20gt%201.0%20and%20Id%20ne%2063&$expand=Indications,TypeDeLieu").ConfigureAwait(false);
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
            var result = "values?";
            result += "values=63&";
            foreach (var item in ListeIdLieux)
            {
                result += "values=" + item + "&";
            }
            result += "values=63";
            return result;
        }
    }

    public enum Path
    {
        ODATA = 1,
        API = 2
    }
}
