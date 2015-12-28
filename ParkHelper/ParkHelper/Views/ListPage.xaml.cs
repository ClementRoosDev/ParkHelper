using Xamarin.Forms;
using ParkHelper.Common.Objets;
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
            var dataTemplate = new DataTemplate(typeof(CustomCell));
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

            listView.ItemSelected += (object sender, SelectedItemChangedEventArgs e) =>
            {
                var attraction = listView.SelectedItem as Attraction;
                viewModel.Parameter = attraction;
                viewModel.ItemDetailsCommand.Execute(viewModel.Parameter);
            };
        }

        /**public void Init()
        {
            this.listView.ItemsSource = (await ApiClient.FindAll<Item>()).Result;
        }*/
    }
}
