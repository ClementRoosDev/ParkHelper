using ParkHelper.ViewModels;
using Xamarin.Forms;

namespace ParkHelper.Views
{
    public partial class HomePage
    {
        public HomePage()
        {
            InitializeComponent();
            BindingContext = new HomePageViewModel(this);
        }
    }
}
