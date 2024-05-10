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

    void OnProductSelected(System.Object sender, Microsoft.Maui.Controls.SelectionChangedEventArgs e)
    {
        Console.WriteLine("product is selected");
        if (e.CurrentSelection.FirstOrDefault() is Product selectedProduct)
        {
            // Navigate to the product page passing the selected product
            Navigation.PushAsync(new ProductPage(selectedProduct));
        }

            // Deselect the item
            ((CollectionView)sender).SelectedItem = null;
    }



}
