using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ParkHelper.Views
{
    public partial class ListPage
    {
        public ListPage()
        {
            InitializeComponent();
            BindingContext = App.Locator.ListPageView;
        }
    }
}
