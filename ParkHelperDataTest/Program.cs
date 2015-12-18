using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkHelper.Api.Models;
using ParkHelper.Data;

namespace ParkHelperDataTest
{
    class Program
    {
        static void Main(string[] args)
        {
            MethodeCalculParcours();
            TestCalculDeplacement();
            TestAttractionLaPlusProche();
            Console.Read();
        }

        private static bool MethodeCalculParcours()
        {
            int[] testAttraction = new int[3] {1,3,4 };
            CalculParcours CP = new CalculParcours(testAttraction);
            CP.CalculeParcoursOptimal();
            foreach (var item in CP.Parcours.ListeParcours)
            {
                if (item is Deplacement)
                {
                    Console.WriteLine(item.Duree + item.Ordre);
                }
                if (item is Attraction)
                {
                    Console.WriteLine(((Attraction)item).Ordre + "   "+ ((Attraction)item).Libelle);
                }                
            }
            return false;
        }

        private static bool TestCalculDeplacement()
        {
            Attraction a1 = new Attraction { Latittude = 5, Longitude = 10};
            Attraction a2 = new Attraction { Latittude = 8, Longitude = 15 };
            Deplacement d = new Deplacement(a1, a2);
            Console.WriteLine("Durée : {0}",d.Duree);
            return false;
        }

        private static bool TestAttractionLaPlusProche()
        {
            Attraction a1 = new Attraction {Libelle="Splash", Latittude = 5, Longitude = 10 };
            Attraction a2 = new Attraction {Libelle = "Grand 8", Latittude = 8, Longitude = 15 };
            Attraction a3 = new Attraction {Libelle = "Maison Hantée", Latittude = 4, Longitude = 8 };

            List<Attraction> listeAttractions = new List<Attraction>();
            listeAttractions.Add(a1);
            listeAttractions.Add(a2);
            listeAttractions.Add(a3);

            Localisation l = new Localisation(a1,listeAttractions);
            Console.WriteLine("Attraction la plus pres : {0}", l.AttractionLaPlusPres.Libelle);
            return false;
        }       

    }
}
