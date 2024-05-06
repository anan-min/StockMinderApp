namespace StockMinderApp.Views;
using StockMinderApp.Modules;

public partial class NavbarPage : ContentPage
{
	public NavbarPage()
	{
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
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
        NavigationHelper.ChangeFlyoutDetails(new Views.MainPageDetail());
    }

    void SearchItemButtonClicked(System.Object sender, System.EventArgs e)
    {

        if (App.UserSession.IsLoggedIn)
        {
            NavigationHelper.ChangeFlyoutDetails(new Views.ProductsPage());

        }
        else
        {
            NavigationHelper.ChangeFlyoutDetails(new Views.LoginPage());
        }
    }

    void RegisterButtonClicked(System.Object sender, System.EventArgs e)
    {
        NavigationHelper.ChangeFlyoutDetails(new Views.RegisterPage());
    }

    void LoginButtonClicked(System.Object sender, System.EventArgs e)
    {
        NavigationHelper.ChangeFlyoutDetails(new Views.LoginPage());
    }

    void AddItemClicked(System.Object sender, System.EventArgs e)
    {
        if (App.UserSession.IsLoggedIn)
        {
            NavigationHelper.ChangeFlyoutDetails(new Views.AddProductPage());
        }
        else
        {
            NavigationHelper.ChangeFlyoutDetails(new Views.LoginPage());
        }
    }


    void ViewReportButtonClicked(System.Object sender, System.EventArgs e)
    {
        if (App.UserSession.IsLoggedIn)
        {
            NavigationHelper.ChangeFlyoutDetails(new Views.ReportsPage());
        }
        else
        {
            NavigationHelper.ChangeFlyoutDetails(new Views.LoginPage());
        }
    }

    void SubmitReportButtonClicked(System.Object sender, System.EventArgs e)
    {
        if (App.UserSession.IsLoggedIn)
        {
            NavigationHelper.ChangeFlyoutDetails(new Views.SubmitReportPage());
        }
        else
        {
            NavigationHelper.ChangeFlyoutDetails(new Views.LoginPage());
        }
    }

}
