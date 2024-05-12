namespace StockMinderApp.Views;
using StockMinderApp.Modules;

public partial class MainPageDetail : ContentPage
{
	public MainPageDetail()
	{
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
    }

    void Button_Clicked(System.Object sender, System.EventArgs e)
    {
        if (App.UserSession.IsLoggedIn)
        {
            NavigationHelper.ChangeFlyoutDetails(new Views.ProductsPage());

        }
        else
        {
            App.previousPage = new ProductsPage();
            NavigationHelper.ChangeFlyoutDetails(new Views.LoginPage());
        }
    }

    void AddProductTapped(System.Object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        if (App.UserSession.IsLoggedIn)
        {
            NavigationHelper.ChangeFlyoutDetails(new Views.AddProductPage());

        }
        else
        {
            App.previousPage = new AddProductPage();
            NavigationHelper.ChangeFlyoutDetails(new Views.LoginPage());
        }
    }


    void ProductsTapped(System.Object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        if (App.UserSession.IsLoggedIn)
        {
            NavigationHelper.ChangeFlyoutDetails(new Views.ProductsPage());

        }
        else 
        {
            App.previousPage = new ProductsPage();
            NavigationHelper.ChangeFlyoutDetails(new Views.LoginPage());
        }
    }
}
