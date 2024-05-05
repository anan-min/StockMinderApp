using System;
using SQLite;

namespace StockMinderApp.Data
{
	public class ProductDatabase
	{
		public ProductDatabase()
		{
		}

        SQLiteAsyncConnection _database;
        async Task Init()
        {
            if (_database is not null)
                return;

            _database = new SQLiteAsyncConnection(
                DataBaseConstants.DatabasePath,
                DataBaseConstants.Flags
                );

            var result = await _database.CreateTableAsync<Product>();
        }



        private static List<Product> GenerateProducts()
        {
            List<Product> Products = new List<Product>();

            //for (int i = 0; i < 10; i++)
            //{
            //    Products.Add(new Product
            //    {
            //        Product_title = $"Product {i + 1}",
            //        Product_content = $"Content for Product {i + 1}",
            //        date_time = DateTime.Now.AddDays(-i)
            //    });
            //}

            return Products;
        }


        private async Task InsertGeneratedProducts()
        {
            List<Product> Products = GenerateProducts();
            await Init();
            await _database.InsertAllAsync(Products);
        }


        private async Task<Product> GetProductAsync(string product_id)
        {
            await Init();
            return await _database
                .Table<Product>()
                .Where(n => n.product_id == product_id)
                .FirstOrDefaultAsync();

        }
    }
}

