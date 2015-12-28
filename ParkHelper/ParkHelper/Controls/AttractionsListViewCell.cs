using Xamarin.Forms;

namespace ParkHelper.Controls
{
    class AttractionsListViewCell : ViewCell
    {
        public AttractionsListViewCell()
        {
            var libelleText = new Label();
            libelleText.SetBinding(Label.TextProperty, "Libelle");

            var switcher = new Switch { IsToggled = false };

            switcher.SetBinding(Switch.IsToggledProperty, "EstDejaDansLeParcours");
            var view = new StackLayout()
            {
                Orientation = StackOrientation.Horizontal,
                Children =
                {
                    libelleText,
                    switcher
                }
            };

            View = view;
        }
    }
}