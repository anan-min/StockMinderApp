using System;
using SQLite;

namespace StockMinderApp.Data
{
	public class ReportDatabase
	{
		public ReportDatabase()
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

            var result = await _database.CreateTableAsync<Report>();
        }



        public static List<Report> GenerateReports()
        {
            List<Report> reports = new List<Report>();

            for (int i = 0; i < 10; i++)
            {
                reports.Add(new Report
                {
                    report_title = $"Report {i + 1}",
                    report_content = $"Content for Report {i + 1}",
                    date_time = DateTime.Now.AddDays(-i)
                });
            }

            return reports;
        }


        private async Task InsertGeneratedReports()
        {
            List<Report> reports = GenerateReports();
            await Init();
            await _database.InsertAllAsync(reports);
        }


        private async Task<Report> GetReportAsync(int reportId)
        {
            await Init();
            return await _database
                .Table<Report>()
                .Where(n => n.report_id == reportId)
                .FirstOrDefaultAsync();
        }





        public async Task Main()
        {
            await Init();
            await InsertGeneratedReports();

            // Get report with ID 1
            int reportId = 1;
            Report report = await GetReportAsync(reportId);

            if (report != null)
            {
                report.PrintReport();
            }
            else
            {
                Console.WriteLine($"Report with ID {reportId} not found.");
            }

        }
    }
}

