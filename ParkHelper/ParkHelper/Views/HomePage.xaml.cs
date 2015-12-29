namespace ParkHelper.Views
{
    public partial class HomePage
    {
        public HomePage()
        {
            InitializeComponent();
            BindingContext = App.Locator.Main;
        }
    }
}
