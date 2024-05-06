using System.Collections.ObjectModel;
using StockMinderApp.Data;
namespace StockMinderApp.Views;

public partial class ProductsPage : ContentPage
{
	public ProductsPage()
	{
        InitializeComponent();
        // Generate and bind products
        List<Product> productList = ProductDatabase.GenerateDummyProducts();
        ObservableCollection<Product> Products = new(productList);
        productCollectionView.ItemsSource = Products;
    }



}
