namespace StockMinderApp.Views;
using StockMinderApp.Modules;

public partial class RegisterPage : ContentPage
{
	public RegisterPage()
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

    private async void SubmitButtonClicked(System.Object sender, System.EventArgs e)
    {
        string employee_id = IdEntry.Text;
        string username = UsernameEntry.Text;
        string password = PasswordEntry.Text;
        string email = EmailEntry.Text;
        string department = DepartmentEntry.Text;

        if (AreEntriesEmpty())
        {
            await DisplayAlert("Alert", "Please fill in all fields", "OK");
            FocusFirstEmptyEntry();
        } else
        {
            bool isEmployeeIdExisted = await App.userDatabase.IsEmployeeIdAlreadyExists(employee_id);
            bool isUsernameExisted = await App.userDatabase.IsUsernameAlreadyExists(username);
            bool isEmailExisted = await App.userDatabase.IsEmailAlreadyExists(email);

            if (isEmployeeIdExisted)
            {
                await DisplayAlert("Alert", "Employee id aldready used", "OK");
                ClearAndFocusEntry(IdEntry);
            } else if (isUsernameExisted)
            {
                await DisplayAlert("Alert", "Username Already Exists", "OK");
                ClearAndFocusEntry(UsernameEntry);
            } else if(isEmailExisted)
            {
                await DisplayAlert("Alert", "Email Already Used", "OK");
                ClearAndFocusEntry(EmailEntry);
            } else
            {
                await DisplayAlert("Alert", "Register Successfully", "OK");
                await App.userDatabase.InsertUserAsync(employee_id, username, password, email, department);
                App.UserSession.Login();
            }

        }
    }

    private void FocusFirstEmptyEntry()
    {
        if (string.IsNullOrWhiteSpace(IdEntry.Text))
        {
            IdEntry.Focus();
        }
        else if (string.IsNullOrWhiteSpace(UsernameEntry.Text))
        {
            UsernameEntry.Focus();
        }
        else if (string.IsNullOrWhiteSpace(PasswordEntry.Text))
        {
            PasswordEntry.Focus();
        }
        else if (string.IsNullOrWhiteSpace(EmailEntry.Text))
        {
            EmailEntry.Focus();
        }
        else if (string.IsNullOrWhiteSpace(DepartmentEntry.Text))
        {
            DepartmentEntry.Focus();
        }

    }

    private bool AreEntriesEmpty()
    {
        return string.IsNullOrWhiteSpace(IdEntry.Text)
                || string.IsNullOrWhiteSpace(UsernameEntry.Text)
                || string.IsNullOrWhiteSpace(PasswordEntry.Text)
                || string.IsNullOrWhiteSpace(EmailEntry.Text)
                || string.IsNullOrWhiteSpace(DepartmentEntry.Text);
    }


    private void ClearAndFocusEntry(Entry entry)
    {
        entry.Text = "";
        entry.Focus();
    }
}
