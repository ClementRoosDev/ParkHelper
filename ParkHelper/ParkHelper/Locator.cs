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
        public Locator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            // ViewModels
            SimpleIoc.Default.Register<HomePageViewModel>();
            SimpleIoc.Default.Register<ListPageViewModel>();
            SimpleIoc.Default.Register<MapPageViewModel>();
            SimpleIoc.Default.Register<AttractionDetailsViewModel>();
        }

        public const string HomePage = "HomePage";
        public const string ListPage = "ListPage";
        public const string MapPage = "MapPage";
        public const string AttractionDetailsPage = "AttractionDetailsPage";

        /// <summary>
        /// Gets the Main property.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public HomePageViewModel Main
        {
            get
            {
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
                return ServiceLocator.Current.GetInstance<MapPageViewModel>();
            }
        }

        /// <summary>
        /// Gets the detailsPage property.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public AttractionDetailsViewModel AttractionDetailsView
        {
            get
            {
                return ServiceLocator.Current.GetInstance<AttractionDetailsViewModel>();
            }
        }
    }
}
