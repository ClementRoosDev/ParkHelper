using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkHelper.Data
{
    public class Deplacement : IElementDeParcours
    {
        #region Fields
        private Attraction LieuDepart { get; set; }
        private Attraction LieuArrivee { get; set; }
        public int Duree { get; set; }
        public int Ordre { get; set; }

        public bool EstDejaDansLeParcours { get; set; }

        #endregion

        #region Constructeur

        public Deplacement(Attraction LieuDepart, Attraction LieuArrivee)
        {
            this.LieuDepart = LieuDepart;
            this.LieuArrivee = LieuArrivee;
            CalculeDuree();
        }

        #endregion

        #region Methodes

        //Calcule la durée entre deux point (on va dire que distance = durée)
        private void CalculeDuree()
        {
            double duree =
            Math.Sqrt
            (
                Math.Pow
                (
                    (
                        Convert.ToDouble(LieuDepart.Latittude) - Convert.ToDouble(LieuArrivee.Latittude)
                    ), 2
                ) +
                Math.Pow
                (
                    (
                        Convert.ToDouble(LieuDepart.Longitude) - Convert.ToDouble(LieuArrivee.Longitude)
                    ), 2
                )
            );
            Duree = Convert.ToInt32(Math.Round(duree));
        }

        #endregion
    }
}
