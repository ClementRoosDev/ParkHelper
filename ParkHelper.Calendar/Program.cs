using System;
using ParkHelper.Data;
// ReSharper disable UnusedParameter.Local

namespace ParkHelper.Calendar
{
    class Program
    {
        static void Main(string[] args)
        {
            var configuration = new Configuration();
            var idJourdebut = 1;
            var jourdebutMois = idJourdebut;
            int id=2828;
            using (var myContext = new ParcHelperEntities())
            {
                myContext.Configuration.ProxyCreationEnabled = false;
                //All attractions
                for (var j = 1; j <= configuration.idMax; j++)
                {
                    //Alldays
                    for (var i = 1; i <= configuration.JourFin; i++)
                    {
                        if(j != 63)
                        {
                            if (i == 1)
                            {
                                jourdebutMois = idJourdebut;
                            }
                            else
                            {
                                //Gestio numero jour
                                if (jourdebutMois == 7)
                                {
                                    jourdebutMois = 1;
                                }
                                else
                                {
                                    jourdebutMois++;
                                }
                            }
                            var nouvelleLigne = new Planning(
                                //id,
                                id,
                                //idLieu
                                j,
                                //IdJour
                                jourdebutMois,
                                //IdNumeroJour
                                i,
                                //IdMois
                                2,
                                //IdHoraire
                                1,
                                //IdEtat
                                1);
                            myContext.Plannings.Add(nouvelleLigne);
                            myContext.SaveChanges();


                            Console.WriteLine("id :" + id + " idLieu :" + j + " idJour :" + jourdebutMois + " idNumeroJ :" + i + " idMois :" + 1 + " idHoraire :" + 1 + " idEtat :" + 1);
                            id++;
                        }
                    }
                }
            }
        }
    }
}
