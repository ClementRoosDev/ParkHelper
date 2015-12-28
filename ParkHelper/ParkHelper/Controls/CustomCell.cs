using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkHelper.Controls
{
    using Xamarin.Forms;

    class CustomCell : ViewCell
    {
        public CustomCell()
        {
            var cityText = new Label();
            cityText.SetBinding(Label.TextProperty, "Libelle");

            var view = new StackLayout()
            {
                Orientation = StackOrientation.Horizontal,
                Children =
            {
                cityText
            }
            };

            View = view;
        }
    }
}