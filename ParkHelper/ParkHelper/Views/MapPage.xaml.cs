namespace ParkHelper.Views
{
    public partial class MapPage
    {
        public MapPage()
        {
            InitializeComponent();
            var viewModel = App.Locator.MapPageView;
            BindingContext = viewModel;
        }
    }
}
