using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using ParkHelper.ViewModels;

namespace ParkHelper
{
    public class Locator
    {
        /// <summary>
        /// Register all the used ViewModels, Services et. al. witht the IoC Container
        /// </summary>
        static Locator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            // ViewModels
            SimpleIoc.Default.Register<SplashScreenViewModel>();
            SimpleIoc.Default.Register<HomePageViewModel>();
            SimpleIoc.Default.Register<ListPageViewModel>();
            SimpleIoc.Default.Register<MapPageViewModel>();
            SimpleIoc.Default.Register<LieuDetailsViewModel>();
            SimpleIoc.Default.Register<ItinerairePageViewModel>();
        }
        public const string SplashScreenPage = "SplashScreenPage";
        public const string HomePage = "HomePage";
        public const string ListPage = "ListPage";
        public const string MapPage = "MapPage";
        public const string LieuDetailsPage = "LieuDetailsPage";
        public const string ItinerairePage = "ItinerairePage";

        /// <summary>
        /// Gets the SplashScreen property.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public SplashScreenViewModel SplashScreenView
        {
            get
            {
                if (!SimpleIoc.Default.IsRegistered<SplashScreenViewModel>())
                    SimpleIoc.Default.Register<SplashScreenViewModel>();
                return ServiceLocator.Current.GetInstance<SplashScreenViewModel>();
            }
        }


        /// <summary>
        /// Gets the Main property.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public HomePageViewModel HomePageView
        {
            get
            {
                if (!SimpleIoc.Default.IsRegistered<HomePageViewModel>())
                    SimpleIoc.Default.Register<HomePageViewModel>();
                return ServiceLocator.Current.GetInstance<HomePageViewModel>();
            }
        }

        /// <summary>
        /// Gets the Second property.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public ListPageViewModel ListPageView
        {
            get
            {
                if (!SimpleIoc.Default.IsRegistered<ListPageViewModel>())
                    SimpleIoc.Default.Register<ListPageViewModel>();
                return ServiceLocator.Current.GetInstance<ListPageViewModel>();
            }
        }

        /// <summary>
        /// Gets the third property.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public MapPageViewModel MapPageView
        {
            get
            {
                if (!SimpleIoc.Default.IsRegistered<MapPageViewModel>())
                    SimpleIoc.Default.Register<MapPageViewModel>();
                return ServiceLocator.Current.GetInstance<MapPageViewModel>();
            }
        }

        /// <summary>
        /// Gets the detailsPage property.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public LieuDetailsViewModel LieuDetailsView
        {
            get
            {
                if (!SimpleIoc.Default.IsRegistered<LieuDetailsViewModel>())
                    SimpleIoc.Default.Register<LieuDetailsViewModel>();
                return ServiceLocator.Current.GetInstance<LieuDetailsViewModel>();
            }
        }

        /// <summary>
        /// Gets the itinerairePage property.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public ItinerairePageViewModel ItineraireView
        {
            get
            {
                if (!SimpleIoc.Default.IsRegistered<ItinerairePageViewModel>())
                    SimpleIoc.Default.Register<ItinerairePageViewModel>();
                return ServiceLocator.Current.GetInstance<ItinerairePageViewModel>();
            }
        }
    }
}
