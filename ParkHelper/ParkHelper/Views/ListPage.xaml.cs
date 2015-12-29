using Xamarin.Forms;
using Attraction = ParkHelper.Common.Objets.Attraction;
using ParkHelper.Controls;
using ParkHelper.ViewModels;

namespace ParkHelper.Views
{
    using System;
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;

    public partial class ListPage
    {
        ListPageViewModel viewModel;


        public ListPage()
        {
            InitializeComponent();
            viewModel = App.Locator.ListPageView;
            viewModel.IsBusy = true;
            BindingContext = viewModel;
            InitializeTemplate();
        }

        void InitializeTemplate()
        {
            var dataTemplate = new DataTemplate(typeof(CustomSwitchCell));
            dataTemplate.SetBinding(TextCell.TextProperty, "Libelle");
            dataTemplate.SetBinding(Switch.IsToggledProperty, "EstDejaDansLeParcours");
            listView.ItemTemplate = dataTemplate;

            var listViewLocal = new ListView()
            {
                IsGroupingEnabled = true,
                GroupDisplayBinding = new Binding("Name"),
                GroupShortNameBinding = new Binding("Name"),
                ItemsSource = viewModel.Listes,
                ItemTemplate = dataTemplate
            };

            listViewLocal.ItemSelected += (sender, e) =>
            {
                var attraction = (Attraction)listViewLocal.SelectedItem;
                viewModel.Parameter = attraction;
                viewModel.ItemDetailsCommand.Execute(viewModel.Parameter);
            };

            Content = listViewLocal;
            viewModel.IsBusy = false;
        }
        /**public void Init()
        {
            this.listView.ItemsSource = (await ApiClient.FindAll<Item>()).Result;
        }*/
    }
}
