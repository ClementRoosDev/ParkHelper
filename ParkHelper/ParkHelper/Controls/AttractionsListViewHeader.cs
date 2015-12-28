using Xamarin.Forms;

namespace ParkHelper.Controls
{
    class AttractionsListViewHeader : ViewCell
    {
        public AttractionsListViewHeader()
        {
            var text = new Label();
            text.SetBinding(Label.TextProperty, "Name");

            

            var view = new StackLayout()
            {
                Orientation = StackOrientation.Horizontal,
                Children = {
                text
            }
            };

            Height = 30;
            View = view;
        }
    }
}
