namespace StockMinderApp.Views;

public partial class NavbarPage : ContentPage
{
	public NavbarPage()
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
    }

    async void SearchItemButtonClicked(System.Object sender, System.EventArgs e)
    {

        if (App.UserSession.IsLoggedIn)
        {
            var navPage = App.Current.MainPage as FlyoutTemplate;
            navPage.Detail = new NavigationPage(new Views.ProductsPage());
        } else
        {
            var navPage = App.Current.MainPage as FlyoutTemplate;
            navPage.Detail = new NavigationPage(new Views.LoginPage());
        }
    }

    void RegisterButtonClicked(System.Object sender, System.EventArgs e)
    {
    }

    void LoginButtonClicked(System.Object sender, System.EventArgs e)
    {
    }

    void AddItemClicked(System.Object sender, System.EventArgs e)
    {
    }


    void ViewReportButtonClicked(System.Object sender, System.EventArgs e)
    {
    }

    void SubmitReportButtonClicked(System.Object sender, System.EventArgs e)
    {
    }

}
