using System;
using SQLite;

namespace StockMinderApp.Data
{
	public class Product
	{
            [PrimaryKey]
            public string product_id { get; set; }
            public string product_name { get; set; }
            public int stock_level { get; set; }
            public string stock_location { get; set; }
            public string product_description { get; set; }
            public string image_path { get; set; }

    }
}

