using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace ParkHelper.Views
{
    public partial class AttractionDetailPage : ContentPage
    {
        public AttractionDetailPage(string attractionId)
        {
            InitializeComponent();
            var viewModel = App.Locator.AttractionDetailsView;
            BindingContext = viewModel;

            viewModel.AttractionId = string.IsNullOrEmpty(attractionId) ? "No parameter set" : attractionId;
        }
    }
}
