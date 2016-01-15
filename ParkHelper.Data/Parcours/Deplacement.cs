using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

// ReSharper disable once CheckNamespace
namespace ParkHelper.Data
{
    [KnownType(typeof(Deplacement))]
    public class Deplacement : IElementDeParcours
    {
        #region Fields
        private Lieu LieuDepart { get; set; }
        private Lieu LieuArrivee { get; set; }
        public int Duree { get; set; }
        public int Ordre { get; set; }
        [Required]
        public string Libelle { get; set; }
        [Required]
        public int IdType { get { return 0; } } 

        public bool EstDejaDansLeParcours { get; set; }

        #endregion

        #region Constructeur

        public Deplacement(Lieu LieuDepart, Lieu LieuArrivee)
        {
            this.LieuDepart = LieuDepart;
            this.LieuArrivee = LieuArrivee;           

            CalculeDuree();

            Libelle = string.Format("Déplacement : {0} minutes ", Duree.ToString());
        }

        #endregion

        public Type type
        {
            get
            {
                return this.GetType();
            }
        }

        #region Methodes

        //Calcule la durée entre deux point (on va dire que distance = durée)
        void CalculeDuree()
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
