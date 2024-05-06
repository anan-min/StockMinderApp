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

    async void Button_Clicked(System.Object sender, System.EventArgs e)
    {
		if (!App.UserSession.IsLoggedIn)
		{
			var result = await Application.Current.MainPage.DisplayAlert("Error", "user is not logged in", "ok", "cancle");
		}
    }
}
