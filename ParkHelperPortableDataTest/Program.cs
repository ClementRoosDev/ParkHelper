using System;
using System.Collections.Generic;
using ParkHelper.Common.Objets;

namespace ParkHelperPortableDataTest
{
    static class Program
    {
        const string Urlattractions = "http://parkhelperapi.azurewebsites.net/api/ptattractions?type=json";
        const string Urlparours = "http://parkhelperapi.azurewebsites.net/api/ptparcours?type=json";

        static void Main(string[] args)
        {
            ITest api = new Version1();
            api.Update();
            Affichage(api.Attractions);
            Console.ReadKey();
        }

        static void Affichage(List<Lieu> result)
        {
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
        }
    }
}
