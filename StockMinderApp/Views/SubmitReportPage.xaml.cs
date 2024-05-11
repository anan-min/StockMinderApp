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
            await InsertReportToDataBase(reportTitle, reportContent);
            await DisplayAlert("Alert", "Report Submitted", "OK");

            await Navigation.PushAsync(new ReportsPage());
        }

    }


    private async Task InsertReportToDataBase(string reportTitle, string reportContent)
    {
        try
        {
            await App.reportDatabase.InsertReportAsync(reportTitle, reportContent);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to insert report: {ex.Message}");
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
