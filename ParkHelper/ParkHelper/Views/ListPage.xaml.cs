using Xamarin.Forms;
using Attraction = ParkHelper.Common.Objets.Attraction;
using ParkHelper.Controls;
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
            BindingContext = viewModel;
            //Init();
            InitializeTemplate();
        }

        void InitializeTemplate()
        {
            /**var dataTemplate = new DataTemplate(typeof(AttractionsListViewCell));
            dataTemplate.SetBinding(TextCell.TextProperty, "Libelle");
            dataTemplate.SetBinding(Switch.IsToggledProperty, "EstDejaDansLeParcours");
            this.listView.ItemTemplate = dataTemplate;


            var listView = new ListView()
            {
                IsGroupingEnabled = true,
                GroupDisplayBinding = new Binding("Name"),
                GroupShortNameBinding = new Binding("Name"),
                ItemsSource = viewModel.Listes,
                ItemTemplate = dataTemplate
            };

            Content = listView;

            listView.ItemSelected += (sender, e) =>
            {
                var attraction = (Attraction)listView.SelectedItem;
                viewModel.Parameter = attraction;
                viewModel.ItemDetailsCommand.Execute(viewModel.Parameter);
            };*/
            viewModel.InitListAttractions();

            var dataTemplate = new DataTemplate(typeof(CustomSwitchCell));
            dataTemplate.SetBinding(TextCell.TextProperty, "Libelle");
            dataTemplate.SetBinding(Switch.IsToggledProperty, "EstDejaDansLeParcours");
            this.listView.ItemTemplate = dataTemplate;

            var listView = new ListView()
            {
                IsGroupingEnabled = true,
                GroupDisplayBinding = new Binding("Name"),
                GroupShortNameBinding = new Binding("Name"),
                ItemsSource = viewModel.Listes,
                ItemTemplate = dataTemplate
            };

            listView.ItemSelected += (sender, e) =>
            {
                var attraction = (Attraction)listView.SelectedItem;
                viewModel.Parameter = attraction;
                viewModel.ItemDetailsCommand.Execute(viewModel.Parameter);
            };

            Content = listView;
        }

        /**public void Init()
        {
            this.listView.ItemsSource = (await ApiClient.FindAll<Item>()).Result;
        }*/
    }
}
