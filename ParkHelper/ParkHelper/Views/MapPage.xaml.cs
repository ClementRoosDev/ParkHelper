using Xamarin.Forms;

namespace ParkHelper.Views
{
    public partial class MapPage : ContentPage
    {
        public MapPage()
        {
            InitializeComponent();
            var viewModel = App.Locator.MapPageView;
            BindingContext = viewModel;
        }
    }
}
