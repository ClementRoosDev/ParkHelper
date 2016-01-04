using System;
using System.Collections.Generic;
using System.Linq;
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
            Console.WriteLine("******TEST CALCUL PARCOURS*******");
            int[] testAttraction = new int[3] {1,3,4 };
            CalculParcours CP = new CalculParcours(testAttraction);
            CP.CalculeParcoursOptimal();
            foreach (var item in CP.Parcours.ListeParcours.OrderBy(a=>a.Ordre))
            {
                Console.WriteLine("Ordre : " + item.Ordre);
                if (item is Deplacement)
                {
                    Console.WriteLine("Deplacement : " + item.Duree );
                }
                if (item is Lieu)
                {
                    Console.WriteLine("Attraction : "+ ((Lieu)item).Libelle);
                }                
            }
            Console.WriteLine("******FIN TEST*******");
            return false;
        }

        private static bool TestCalculDeplacement()
        {
            Console.WriteLine("******TEST Calcul Deplacement*******");
            Lieu a1 = new Lieu { Latittude = 5, Longitude = 10};
            Lieu a2 = new Lieu { Latittude = 8, Longitude = 15 };
            Deplacement d = new Deplacement(a1, a2);
            Console.WriteLine("Durée : {0}",d.Duree);
            Console.WriteLine("******FIN TEST*******");
            return false;
        }

        private static bool TestAttractionLaPlusProche()
        {
            Console.WriteLine("******TEST Attraction la plus proche*******");

            Lieu a1 = new Lieu { Libelle="Splash", Latittude = 5, Longitude = 10 };
            Lieu a2 = new Lieu { Libelle = "Grand 8", Latittude = 8, Longitude = 15 };
            Lieu a3 = new Lieu { Libelle = "Maison Hantée", Latittude = 4, Longitude = 8 };

            List<Lieu> listeAttractions = new List<Lieu>();
            listeAttractions.Add(a1);
            listeAttractions.Add(a2);
            listeAttractions.Add(a3);

            Localisation l = new Localisation(a1,listeAttractions);
            l.CalculeAttractionLaPlusPres();
            Console.WriteLine("Attraction la plus pres : {0}", l.AttractionLaPlusPres.Libelle);
            Console.WriteLine("******FIN TEST*******");
            return false;
        }       

    }
}
