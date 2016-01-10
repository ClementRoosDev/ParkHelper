namespace ParkHelper.Views
{
    public partial class HomePage
    {
        public HomePage()
        {
            InitializeComponent();
            var viewModel = App.Locator.HomePageView;
            BindingContext = viewModel;
        }
    }
}
