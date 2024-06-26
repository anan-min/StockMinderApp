﻿using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
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


        public async Task<ObservableCollection<Product>> SearchProducts(String searchTerm)

        {
            await Init();
            var products = await _database.Table<Product>()
                                .Where(u => u.product_id.Contains(searchTerm) ||
                                            u.product_name.Contains(searchTerm) ||
                                            u.product_description.Contains(searchTerm) ||
                                            u.stock_location.Contains(searchTerm))
                                .ToListAsync();

            return new ObservableCollection<Product>(products);
        }


        public async void ResetAndInitializeDatabase()
        {
            await Init();
            await ResetDatabaseAsync();
            await InsertProductsAsync(GenerateProducts());
        }


        public async Task<Product> InsertProductAsync(string product_id, string product_name, string product_description, int stock_level, string stock_location, string image_path)
        {
            await Init();

            if (image_path is null )
            {
                image_path = "product.jpeg";
            }

            Product product = (new Product
            {
                product_id = product_id,
                product_name = product_name,
                product_description = product_description,
                stock_level = stock_level,
                stock_location = stock_location,
                image_path = image_path,
            });

            await _database.InsertAsync(product);
            return product;

        }

        public async Task<bool> isProductIdExisted(String ProductID)
        {
            await Init();
            var product = await _database.Table<Product>()
                              .Where(u => u.product_id == ProductID)
                              .FirstOrDefaultAsync();

            return product != null;
        }


        public async Task<bool> ResetDatabaseAsync()
        {
            try
            {
                await Init();
                await _database.DeleteAllAsync<Product>();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to delete all products: {ex.Message}");
                return false;
            }
        }


        public async Task<int> UpdateProductAsync(Product product)
        {
            await Init();
            int rowsAffected = await _database.UpdateAsync(product);

            if (rowsAffected > 0)
            {
                Console.WriteLine("Product updated successfully.");
            }
            else
            {
                Console.WriteLine("Product update failed.");
            }

            return rowsAffected;
        }


        private async Task<bool> InsertProductsAsync(List<Product> products)
        {
            try
            {
                await Init();
                await _database.InsertAllAsync(products);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to insert users: {ex.Message}");
                return false;
            }
        }


        public async Task<ObservableCollection<Product>> GetAllProductsAsync()
        {
            await Init();
            var products = await _database.Table<Product>().ToListAsync();
            return new ObservableCollection<Product>(products);
        }



        private async Task<Product> GetProductAsync(string product_id)
        {
            await Init();
            return await _database
                .Table<Product>()
                .Where(n => n.product_id == product_id)
                .FirstOrDefaultAsync();

        }


        public static List<Product> GenerateProducts()
        {
            List<Product> products = new List<Product>();

            string[] imagePaths = { "img1.jpeg", "img2.jpeg", "img3.jpeg" };

            for (int i = 0; i < 10; i++)
            {
                string productId = $"P-{DateTime.Now.Year}-{"0000" + i}-{"SUPR"}-{"HDS"}-{"WDGTX5000"}";
                string productName = $"Product {i + 1}";
                int stockLevel = new Random().Next(1, 1000);
                string stockLocation = $"A-{i + 1}-B";
                string productDescription = $"Description for Product {i + 1}";
                string imagePath = imagePaths[i % imagePaths.Length];

                Product product = new Product
                {
                    product_id = productId,
                    product_name = productName,
                    stock_level = stockLevel,
                    stock_location = stockLocation,
                    product_description = productDescription,
                    image_path = imagePath
                };

                products.Add(product);
            }

            return products;
        }




        public async Task PrintAllProducts()
        {
            await Init();

            var products = await _database.Table<Product>().ToListAsync();

            foreach (var product in products)
            {
                Console.WriteLine($"Product ID: {product.product_id}");
                Console.WriteLine($"Product Name: {product.product_name}");
                Console.WriteLine($"Description: {product.product_description}");
                Console.WriteLine($"Stock Level: {product.stock_level}");
                Console.WriteLine($"Stock Location: {product.stock_location}");

                Console.WriteLine();
            }
        }



    }
}

