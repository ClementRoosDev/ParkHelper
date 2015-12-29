using Attraction = ParkHelper.Common.Objets.Attraction;
using ParkHelper.ViewModels;

namespace ParkHelper.Views
{
    public partial class ListPage
    {
        ListPageViewModel viewModel;

        public ListPage()
        {
            InitializeComponent();
            viewModel = App.Locator.ListPageView;
            viewModel.IsBusy = true;
            if (viewModel.Listes.Count == 0)
            {
                viewModel.InitListAttractions();
            }
            BindingContext = viewModel;
            InitializeTemplate();
            viewModel.IsBusy = false;
        }

        void InitializeTemplate()
        {
            listView.ItemSelected += (sender, e) =>
            {
                var attraction = (Attraction)listView.SelectedItem;
                viewModel.Parameter = attraction;
                viewModel.ItemDetailsCommand.Execute(viewModel.Parameter);
            };
        }
    }
}
