using System.Collections.ObjectModel;
using StockMinderApp.Data;

namespace StockMinderApp.Views;

public partial class ReportsPage : ContentPage
{

    public ReportsPage()
    {
        InitializeComponent();
        fetchProducts();
        //List<Report> reports = ReportDatabase.GenerateReports();
        //ObservableCollection<Report> Reports = new(reports);
        //reportCollectionView.ItemsSource = Reports;
    }



    protected override void OnAppearing()
    {
        base.OnAppearing();
        fetchProducts();
    }

    private async void fetchProducts()
    {
        try
        {
            IEnumerable<Report> reportsEnumerable = await App.reportDatabase.GetAllReportsAsync();
            ObservableCollection<Report> products = new(reportsEnumerable);
            reportCollectionView.ItemsSource = products;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching products: {ex.Message}");
        }
    }

}
