namespace ParkHelper.Views
{
    public partial class VisiteDetailsPage
    {
        public VisiteDetailsPage(ParkHelper context)
        {
            InitializeComponent();
            var viewModel = App.Locator.VisiteDetailsPageView;
            viewModel.Context = context;
            BindingContext = viewModel;
        }
    }
}
