namespace StockMinderApp.Views;

public partial class UserNavPage : ContentPage
{
	public UserNavPage()
	{
		InitializeComponent();
    }

    void CloseNavBar(System.Object sender, System.EventArgs e)
    {
        if (Application.Current.MainPage is FlyoutPage flyoutPage)
        {
            // Close the flyout
            flyoutPage.IsPresented = false;
        }
    }

    void MainPageButtonClicked(System.Object sender, System.EventArgs e)
    {
        if (App.UserSession.IsLoggedIn)
        {
            var navPage = App.Current.MainPage as FlyoutTemplate;
            navPage.Detail = new NavigationPage(new Views.ProductsPage());
        }
        else
        {
            var navPage = App.Current.MainPage as FlyoutTemplate;
            navPage.Detail = new NavigationPage(new Views.MainPageDetail());
        }
    }

    void SearchItemButtonClicked(System.Object sender, System.EventArgs e)
    {

        if (App.UserSession.IsLoggedIn)
        {
            var navPage = App.Current.MainPage as FlyoutTemplate;
            navPage.Detail = new NavigationPage(new Views.ProductsPage());
        }
        else
        {
            var navPage = App.Current.MainPage as FlyoutTemplate;
            navPage.Detail = new NavigationPage(new Views.LoginPage());
        }
    }

    void RegisterButtonClicked(System.Object sender, System.EventArgs e)
    {
        {
            var navPage = App.Current.MainPage as FlyoutTemplate;
            navPage.Detail = new NavigationPage(new Views.RegisterPage());
        }
    }

    void LoginButtonClicked(System.Object sender, System.EventArgs e)
    {
        var navPage = App.Current.MainPage as FlyoutTemplate;
        navPage.Detail = new NavigationPage(new Views.LoginPage());
    }

    void AddItemClicked(System.Object sender, System.EventArgs e)
    {
        if (App.UserSession.IsLoggedIn)
        {
            var navPage = App.Current.MainPage as FlyoutTemplate;
            navPage.Detail = new NavigationPage(new Views.AddProductPage())
            {
                //BarBackground = Color.FromHex("#5256fe")
                BarBackground = Color.FromRgb(0x52, 0x56, 0xFE)
            };

        }
        else
        {
            var navPage = App.Current.MainPage as FlyoutTemplate;
            navPage.Detail = new NavigationPage(new Views.LoginPage());
        }
    }


    void ViewReportButtonClicked(System.Object sender, System.EventArgs e)
    {
        if (App.UserSession.IsLoggedIn)
        {
            var navPage = App.Current.MainPage as FlyoutTemplate;
            navPage.Detail = new NavigationPage(new Views.ReportsPage());
        }
        else
        {
            var navPage = App.Current.MainPage as FlyoutTemplate;
            navPage.Detail = new NavigationPage(new Views.LoginPage());
        }
    }

    void SubmitReportButtonClicked(System.Object sender, System.EventArgs e)
    {
        if (App.UserSession.IsLoggedIn)
        {
            var navPage = App.Current.MainPage as FlyoutTemplate;
            navPage.Detail = new NavigationPage(new Views.SubmitReportPage());
        }
        else
        {
            var navPage = App.Current.MainPage as FlyoutTemplate;
            navPage.Detail = new NavigationPage(new Views.LoginPage());
        }
    }
}
