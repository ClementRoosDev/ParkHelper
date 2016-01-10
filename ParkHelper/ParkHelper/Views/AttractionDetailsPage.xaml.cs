using ParkHelper.Common.Objets;

namespace ParkHelper.Views
{
    public partial class AttractionDetailsPage
    {
        public AttractionDetailsPage(Lieu lieu)
        {
            InitializeComponent();
            var viewModel = App.Locator.AttractionDetailsView;
            viewModel.Lieu = lieu;
            BindingContext = viewModel;
        }
    }
}
