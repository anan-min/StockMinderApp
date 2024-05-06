using System;
using StockMinderApp.Views;
namespace StockMinderApp.Modules
{
	public class NavigationHelper
	{
		public NavigationHelper()
		{
		}

        public static void ChangeFlyoutDetails(Page page)
        {
            if (Application.Current.MainPage is FlyoutPage flyoutPage)
            {
                var flyout = Application.Current.MainPage as FlyoutTemplate;
                flyout.Detail = new NavigationPage(page);
            }
        }

        public static void ChangeFlyoutFlyout(Page page)
        {
            if (Application.Current.MainPage is FlyoutPage flyoutPage)
            {
                var flyout = Application.Current.MainPage as FlyoutTemplate;
                flyout.Detail = page;
            }
        }


    }
}

