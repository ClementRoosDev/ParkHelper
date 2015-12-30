using ParkHelper.ViewModels;

namespace ParkHelper.Views
{
    public partial class HomePage
    {
        HomePageViewModel viewModel;

        public HomePage()
        {
            InitializeComponent();
            viewModel = App.Locator.Main;
            BindingContext = viewModel;
        }
    }
}
