namespace StockMinderApp.Views;

public partial class SubmitReportPage : ContentPage
{
	public SubmitReportPage()
	{
		InitializeComponent();
	}

    private async void SubmitButtonClicked(System.Object sender, System.EventArgs e)
    {
        // if form is not filled  focus entry
        // get both info from the form and create new report
        if (AreEntriesEmpty())
        {
            await DisplayAlert("Alert", "Please fill in all fields", "OK");
            FocusFirstEmptyEntry();
        } else
        {
            //create new report
            string reportTitle = ReportTitleEntry.Text;
            string reportContent = ReportContentEntry.Text;
            await App.reportDatabase.InsertReportAsync(reportTitle, reportContent);
            await App.reportDatabase.PrintAllReportsAsync();
        }

    }

	private void FocusFirstEmptyEntry()
	{
        if (string.IsNullOrWhiteSpace(ReportTitleEntry.Text))
        {
            ReportTitleEntry.Focus();
        }

        else if(string.IsNullOrWhiteSpace(ReportContentEntry.Text))
        {
            ReportContentEntry.Focus();
        }

    }

    private bool AreEntriesEmpty()
    {
        return string.IsNullOrWhiteSpace(ReportTitleEntry.Text) || string.IsNullOrWhiteSpace(ReportContentEntry.Text);
    }
}
