using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using ParkHelper.Common.Objets;
using Xamarin.Forms;

namespace ParkHelper.Views
{
    public partial class AttractionDetailsPage
    {
        public AttractionDetailsPage(string attraction)
        {
            InitializeComponent();
            var viewModel = App.Locator.AttractionDetailsView;
            BindingContext = viewModel;

            viewModel.Attraction = attraction;
        }
    }
}
