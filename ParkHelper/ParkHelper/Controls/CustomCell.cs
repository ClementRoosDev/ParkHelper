using Xamarin.Forms;
using XLabs.Forms.Controls;

namespace ParkHelper.Controls
{
    class CustomCell : ViewCell
    {
        public CustomCell()
        {
            var cityText = new Label();
            cityText.SetBinding(Label.TextProperty, "Libelle");

            var slider = new Switch { IsToggled = false };

            slider.SetBinding(Switch.IsToggledProperty, "EstDejaDansLeParcours");
            var view = new StackLayout()
            {
                Orientation = StackOrientation.Horizontal,
                Children =
                {
                    cityText,
                    slider
                }
            };

            View = view;
        }
    }
}