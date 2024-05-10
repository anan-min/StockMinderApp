namespace StockMinderApp.Views;
using StockMinderApp.Data;

public partial class ProductPage : ContentPage
{
    private Product product;
	public ProductPage(Product product)
	{
		InitializeComponent();
        this.product = product;
		BindingContext = product;
	}

    public async void IncreaseStockClicked(System.Object sender, System.EventArgs e)
    {
        product.stock_level += 1;
        UpdateButtonText();
        await UpdateStockLevel();
    }

    public async void DecreaseStockClicked(System.Object sender, System.EventArgs e)
    {
        if (product.stock_level > 0)
        {
            product.stock_level -= 1;
        }
        UpdateButtonText();
        await UpdateStockLevel();
    }


    void UpdateButtonText()
    {
        stock_level_label.Text  = $"Current Stock Level: {this.product.stock_level} units";
        stock_level_display.Text  = this.product.stock_level.ToString();
    }
    // update the stock level with buttons
    // how to update button stocklevel with product

    async Task<int> UpdateStockLevel()
    {
        return await App.productDatabase.UpdateProductAsync(product);
    }
}
