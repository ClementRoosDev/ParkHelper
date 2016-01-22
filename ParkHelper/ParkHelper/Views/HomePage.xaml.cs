namespace ParkHelper.Views
{
    public partial class HomePage
    {
        public HomePage(ParkHelper context)
        {
            InitializeComponent();
            var viewModel = App.Locator.HomePageView;
            viewModel.Context = context;
            viewModel.IsListFilled = context.HasApplicationList;
            BindingContext = viewModel;
        }
    }
}
