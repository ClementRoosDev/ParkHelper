using Xamarin.Forms;

namespace ParkHelper.ViewModels
{
    using System.Collections.Generic;
    using System.Linq;
    using ParkHelper.Common.Objets;

    public class ListPageViewModel : BaseViewModel
    {
        #region Fields
        private List<Attraction> attractions;
        private IEnumerable<IGrouping<int, Attraction>> listes;
        #endregion

        #region Constuctor
        public ListPageViewModel(Page page) : base(page)
        {
            attractions = new List<Attraction>();
            InitAttractions();
            Listes = attractions.GroupBy(i => i.Type.Id);
        }

        public ListPageViewModel()
            : base(null)
        {
            attractions = new List<Attraction>();
            InitAttractions();
            Listes = attractions.GroupBy(i => i.Type.Id);
        }

        #endregion

        #region Properties
        public List<Attraction> Attractions 
        {
            get
            {
                return attractions;
            }
            set
            {
                attractions = value;
                OnPropertyChanged("Attractions");
            }
        }

        public IEnumerable<IGrouping<int, Attraction>> Listes
        {
            get
            {
                return listes;
            }
            set
            {
                listes = value;
                OnPropertyChanged("Listes");
            }
        }
        #endregion

        #region Methods

        private void InitAttractions()
        {
            attractions = new List<Attraction>()
            {
                new Attraction()
                {
                    Attente = 20,
                    CapaciteWagon = 4,
                    Description = "Attraction super cool",
                    Duree = 10,
                    EstDejaDansLeParcours = false,
                    Id = 1,
                    IdType = new Type(){Id = 1, Libelle = "Type 1"},
                    Latittude = 38.99,
                    Longitude = 37.87,
                    Libelle = "Attraction 1",
                    LienGif = "http://aaa.com/a.gif",
                    Ordre = 0
                },
                new Attraction()
                {
                    Attente = 30,
                    CapaciteWagon = 8,
                    Description = "Attraction pas tres cool",
                    Duree = 160,
                    EstDejaDansLeParcours = false,
                    Id = 2,
                    IdType = new Type(){Id = 2, Libelle = "Type 2"},
                    Latittude = 35.20,
                    Longitude = 40.60,
                    Libelle = "Attraction 2",
                    LienGif = "http://aaa.com/b.gif",
                    Ordre = 0
                },
                new Attraction()
                {
                    Attente = 0,
                    CapaciteWagon = 1,
                    Description = "Attraction hyper cool",
                    Duree = 20,
                    EstDejaDansLeParcours = false,
                    Id = 3,
                    IdType = new Type(){Id = 3, Libelle = "Type 3"},
                    Latittude = 37.20,
                    Longitude = 10.60,
                    Libelle = "Attraction 3",
                    LienGif = "http://aaa.com/c.gif",
                    Ordre = 0
                }
            };
        }
        #endregion
    }
}
