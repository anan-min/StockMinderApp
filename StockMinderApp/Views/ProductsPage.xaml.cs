using System.Collections.ObjectModel;
using StockMinderApp.Data;

namespace StockMinderApp.Views;

public partial class ProductsPage : ContentPage
{
	public ProductsPage()
	{
        InitializeComponent();
        fetchProducts();
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
            IEnumerable<Product> productsEnumerable = await App.productDatabase.GetAllProductsAsync();
            ObservableCollection<Product> products = new(productsEnumerable);
            productCollectionView.ItemsSource = products;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching products: {ex.Message}");
        }
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
