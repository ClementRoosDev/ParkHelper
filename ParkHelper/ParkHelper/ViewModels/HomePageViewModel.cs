using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ParkHelper.ViewModels
{
    public class HomePageViewModel : BaseViewModel
    {
        #region Fields
        private string textTest = "THIS IS A TEST ! Je suis un fraisier";
        #endregion

        #region Constuctor
        public HomePageViewModel(Page page) : base(page)
        {
        }

        public HomePageViewModel()
            : base(null)
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
        async void OnButtonClicked(object sender, EventArgs args)
        {
            Button button = (Button)sender;
            await DisplayAlert("Clicked!",
                "The button labeled '" + button.Text + "' has been clicked",
                "OK");
        }

        private async Task<string> DisplayAlert(string v1, string v2, string v3)
        {
            return "tata";
        }
        #endregion
    }
}
