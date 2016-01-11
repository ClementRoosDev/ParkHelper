using ParkHelper.Common.Objets;

namespace ParkHelper.Views
{
    public partial class LieuDetailsPage
    {
        public LieuDetailsPage(Lieu lieu)
        {
            InitializeComponent();
            var viewModel = App.Locator.LieuDetailsView;
            viewModel.Lieu = lieu;
            BindingContext = viewModel;
        }
    }
}
