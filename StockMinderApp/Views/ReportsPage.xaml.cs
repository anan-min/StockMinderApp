using System.Collections.ObjectModel;
using StockMinderApp.Data;

namespace StockMinderApp.Views;

public partial class ReportsPage : ContentPage
{

    public ReportsPage()
    {
        InitializeComponent();
        List<Report> reports = ReportDatabase.GenerateReports();
        ObservableCollection<Report> Reports = new(reports);
        reportCollectionView.ItemsSource = Reports;
    }

}
