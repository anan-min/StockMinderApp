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

    async Task<int> IncreaseStockClicked(System.Object sender, System.EventArgs e)
    {
        this.product.stock_level += 1;
        UpdateButtonText();
        return await UpdateStockLevel();
    }

    async Task<int> DecreaseStockClicked(System.Object sender, System.EventArgs e)
    {
        if (this.product.stock_level > 0)
        {
            this.product.stock_level -= 1;
        }
        UpdateButtonText();
        return await UpdateStockLevel();
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
