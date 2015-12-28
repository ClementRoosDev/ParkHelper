using Xamarin.Forms;

namespace ParkHelper.Views
{
    using ParkHelper.Common.Objets;
    using ParkHelper.Controls;
    using ParkHelper.ViewModels;

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
            this.listView.ItemTemplate = dataTemplate;


            var listView = new ListView()
            {
                IsGroupingEnabled = true,
                GroupDisplayBinding = new Binding("Name"),
                GroupShortNameBinding = new Binding("Id"),
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

        public async void Init()
        {
            //this.listView.ItemsSource = (await ApiClient.FindAll<Item>()).Result;
        }
    }
}
