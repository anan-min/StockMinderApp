namespace StockMinderApp.Views;

public partial class MainPageDetail : ContentPage
{
	public MainPageDetail()
	{
		InitializeComponent();
	}

    async void Button_Clicked(System.Object sender, System.EventArgs e)
    {
		if (!App.UserSession.IsLoggedIn)
		{
			var result = await Application.Current.MainPage.DisplayAlert("Error", "user is not logged in", "ok", "cancle");
		}
    }
}
