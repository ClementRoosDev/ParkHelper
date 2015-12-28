namespace ParkHelper.Views
{
    using ParkHelper.Common.Objets;

    public partial class AttractionDetailsPage
    {
        public AttractionDetailsPage(Attraction attraction)
        {
            InitializeComponent();
            var viewModel = App.Locator.AttractionDetailsView;
            viewModel.Attraction = attraction;
            BindingContext = viewModel;
        }
    }
}
