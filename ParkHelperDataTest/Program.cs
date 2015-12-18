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
            Console.WriteLine(string.Format("Methode Calcul Parcours : {0}",MethodeCalculParcours()));
        }

        private static bool MethodeCalculParcours()
        {
            int[] testAttraction = new int[5] {1,3,4,5,6 };
            CalculParcours CP = new CalculParcours(testAttraction);
            foreach (var item in CP.Parcours.ListeParcours)
            {
                if (item.GetType() == typeof(Deplacement))
                {
                    Console.WriteLine(item.Duree + item.Ordre);
                }
                if (item.GetType() == typeof(Deplacement))
                {
                    Console.WriteLine(item.Duree + item.Ordre);
                }
                
            }
            return false;
        }


    }
}
