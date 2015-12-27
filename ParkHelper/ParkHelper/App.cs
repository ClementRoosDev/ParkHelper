using ParkHelper.Views;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using ParkHelper.Helper;
using Xamarin.Forms;

namespace ParkHelper
{
    public class App : Application
    {
        private static Locator _locator;
        public static Locator Locator { get { return _locator ?? (_locator = new Locator()); } }

        public App()
        {
            // The root page of your application
            //MainPage = new NavigationPage(new HomePage());

            var nav = new NavigationService();
            nav.Configure(Locator.HomePage, typeof(HomePage));
            nav.Configure(Locator.ListPage, typeof(ListPage));
            nav.Configure(Locator.MapPage, typeof(MapPage));
            SimpleIoc.Default.Register<INavigationService>(() => nav);

            var firstPage = new NavigationPage(new HomePage());

            nav.Initialize(firstPage);

            //SimpleIoc.Default.Register<INavigationService>(() => nav);

            MainPage = firstPage;

        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}

#region Fields
#endregion
#region Constuctor
#endregion
#region Properties
#endregion
#region Methods
#endregion