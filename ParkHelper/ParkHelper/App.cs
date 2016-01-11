using ParkHelper.Views;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using ParkHelper.Helper;
using Xamarin.Forms;

namespace ParkHelper
{
    public class App : Application
    {
        static Locator _locator;
        NavigationService nav;
        public static Locator Locator { get { return _locator ?? (_locator = new Locator()); } }

        public App()
        {

            nav = new NavigationService();
            nav.Configure(Locator.SplashScreenPage, typeof(SplashScreenPage));
            nav.Configure(Locator.HomePage, typeof(HomePage));
            nav.Configure(Locator.ListPage, typeof(ListPage));
            nav.Configure(Locator.MapPage, typeof(MapPage));
            nav.Configure(Locator.LieuDetailsPage, typeof(LieuDetailsPage));
            nav.Configure(Locator.ItinerairePage, typeof(ItinerairePage));

            SimpleIoc.Default.Reset();
            SimpleIoc.Default.Register<INavigationService>(() => nav);

            var firstPage = new NavigationPage(new SplashScreenPage());

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