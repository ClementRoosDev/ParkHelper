using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkHelper.Controls
{
    using Xamarin.Forms;
    public class CustomSwitchCell : ViewCell
    {
        public event EventHandler<EventArgs> SwitchTapped;

        public CustomSwitchCell()
        {
            var stack = new StackLayout()
            {
                Orientation = StackOrientation.Horizontal,
                Padding = new Thickness(10, 5, 10, 5),
                Spacing = 0
            };

            var nameLabel = new Label
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                FontSize = Device.GetNamedSize(NamedSize.Default, typeof(Label)),
                LineBreakMode = LineBreakMode.NoWrap,
                TextColor = Color.White
            };
            nameLabel.SetBinding(Label.TextProperty, "Libelle");
            stack.Children.Add(nameLabel);

            var toggleSwitch = new Switch { HorizontalOptions = LayoutOptions.End };
            toggleSwitch.SetBinding(Switch.IsToggledProperty, "EstDejaDansLeParcours");
            stack.Children.Add(toggleSwitch);

            View = stack;
        }
    }
}
