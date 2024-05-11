using Xamarin.Google.Crypto.Tink.Shaded.Protobuf;

namespace StockMinderApp.Views;
using StockMinderApp.Modules;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
      
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        if (App.UserSession.IsLoggedIn)
        {
            NavigationHelper.ChangeFlyoutDetails(new MainPageDetail());
        }
    }

    void CreateNewAccountCliked(System.Object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        var navPage = App.Current.MainPage as FlyoutTemplate;
        navPage.Detail = new NavigationPage(new Views.MainPageDetail());
        Navigation.PushAsync(new RegisterPage());
    }

    private async void LoginButtonClicked(System.Object sender, System.EventArgs e)
    {
        string username = UsernameEntry.Text;
        string password = PasswordEntry.Text;

        if (AreEntriesEmpty())
        {
            await DisplayAlert("Alert", "Please fill in all fields", "OK");
            FocusFirstEmptyEntry();
        }
        else
        {
            bool _isCorrectCredentials = await App.userDatabase.IsCorrectCredentials(username, password);
            if (_isCorrectCredentials)
            {
                App.UserSession.Login();
                await DisplayAlert("Alert", "Login Successfully", "OK");

                NavigateBackToPreviousPage();
                //if (App.previousPage is null)
                //{
                //    NavigationHelper.ChangeFlyoutDetails(new MainPageDetail());
                //}
                //else
                //{
                //    NavigationHelper.ChangeFlyoutDetails(App.previousPage);
                //    App.previousPage = null;

                //}

            }
        }
    }


    private void NavigateBackToPreviousPage()
    {
        if (App.previousPage is null)
        {
            NavigationHelper.ChangeFlyoutDetails(new MainPageDetail());
        }
        else
        {
            NavigationHelper.ChangeFlyoutDetails(App.previousPage);
            App.previousPage = null;
        }
    }



    private void FocusFirstEmptyEntry()
    {

        if (string.IsNullOrWhiteSpace(UsernameEntry.Text))
        {
            UsernameEntry.Focus();
        }
        else if (string.IsNullOrWhiteSpace(PasswordEntry.Text))
        {
            PasswordEntry.Focus();
        }

    }

    private bool AreEntriesEmpty()
    {
        return string.IsNullOrWhiteSpace(UsernameEntry.Text)
                || string.IsNullOrWhiteSpace(PasswordEntry.Text);
    }

}
