using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ParkHelper.ViewModels
{
    public class HomePageViewModel : BaseViewModel
    {
        #region Fields
        private string textTest = "THIS IS A TEST !";
        #endregion

        #region Constuctor
        public HomePageViewModel(Page page) : base(page)
        {
        }
        #endregion

        #region Properties
        public string TextTest
        {
            get
            {
                return this.textTest;
            }
            set
            {
                this.textTest = value;
                OnPropertyChanged("TextTest");
            }
        }

        #endregion

        #region Methods

        #endregion
    }
}
