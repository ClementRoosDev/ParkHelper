using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ParkHelper.Common.Objets;
using ParkHelper.ViewModels;


namespace ParkHelper.Views
{
    public partial class ListPage
    {
        public ListPage()
        {
            InitializeComponent();
            BindingContext = App.Locator.ListPageView;
            //Init();
        }
        public async void Init()
        {
            //this.listView.ItemsSource = (await ApiClient.FindAll<Item>()).Result;
        }
    }
}
