using System;
using SQLite;

namespace StockMinderApp.Data
{
	public class Report
	{
        [PrimaryKey, AutoIncrement]
        public int report_id { get; set; }
        public string report_title { get; set; }
        public string report_content { get; set; }
        public DateTime date_time { get; set; }

        public void PrintReport()
        {
            Console.WriteLine($"Report ID: {report_id}");
            Console.WriteLine($"Title: {report_title}");
            Console.WriteLine($"Content: {report_content}");
            Console.WriteLine($"Date: {date_time}");
        }
    }
}

