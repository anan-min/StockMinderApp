using System;
using SQLite;

namespace StockMinderApp.Data
{
	public class User
	{
        [PrimaryKey]
        public string employee_id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string department { get; set; }
    }
}

