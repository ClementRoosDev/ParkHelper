namespace ParkHelper.Views
{
    public partial class EditHotelDetailsPage
    {
        public EditHotelDetailsPage(ParkHelper context)
        {
            InitializeComponent();
            var viewModel = App.Locator.EditHotelDetailsPageView;
            viewModel.Context = context;
            BindingContext = viewModel;
        }
    }
}
