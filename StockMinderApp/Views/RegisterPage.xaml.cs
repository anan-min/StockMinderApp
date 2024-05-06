namespace StockMinderApp.Views;

public partial class RegisterPage : ContentPage
{
	public RegisterPage()
	{
		InitializeComponent();
	}

    void SubmitButtonClicked(System.Object sender, System.EventArgs e)
    {
		//
        if (AreEntriesEmpty())
        {
            FocusFirstEmptyEntry();
        } else
        {

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
        return     string.IsNullOrWhiteSpace(IdEntry.Text)
                || string.IsNullOrWhiteSpace(UsernameEntry.Text)
                || string.IsNullOrWhiteSpace(PasswordEntry.Text)
                || string.IsNullOrWhiteSpace(EmailEntry.Text)
                || string.IsNullOrWhiteSpace(DepartmentEntry.Text);

    }
}
