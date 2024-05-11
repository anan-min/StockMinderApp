using System;
using System.Collections.ObjectModel;
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

        // GetAllReportsAsync
        public async Task<ObservableCollection<Report>> GetAllReportsAsync()
        {
            await Init();
            var reports = await _database.Table<Report>().ToListAsync();
            return new ObservableCollection<Report>(reports);
        }



        public async void ResetAndInitializeDatabase()
        {
            await Init();
            await ResetDatabaseAsync();
            await InsertReporstAsync(GenerateReports());
            await PrintAllReports();
        }


        public async Task<bool> ResetDatabaseAsync()
        {
            try
            {
                await Init();
                await _database.DeleteAllAsync<Report>();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to delete all users: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> InsertReporstAsync(List<Report> reports)
        {
            try
            {
                await Init();
                await _database.InsertAllAsync(reports);
                return true;
            }
            catch (Exception ex)
            {
                // Handle exception if insertion fails
                Console.WriteLine($"Failed to insert users: {ex.Message}");
                return false;
            }
        }




        public static List<Report> GenerateReports()
        {
            List<Report> reports = new List<Report>();

            string loremIpsum = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed ac justo non nisi ultricies tristique. Quisque ultricies pharetra erat, et tincidunt mi tincidunt a. Nullam sed enim eu erat posuere vestibulum. Proin tristique libero at augue cursus, at condimentum libero venenatis. Suspendisse potenti. Nullam hendrerit metus eu nisl mattis, sit amet pulvinar lacus imperdiet. Sed ac nulla facilisis, tempus metus at, feugiat mi. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Donec et nulla sed lectus feugiat bibendum at vel ligula.";

            for (int i = 0; i < 10; i++)
            {
                reports.Add(new Report
                {
                    report_title = $"Report {i + 1}",
                    report_content = $"{loremIpsum}",
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

        public async Task<Report> InsertReportAsync(string ReportTitle, string ReportContent)
        {
            await Init();
            Report report = (new Report
            {
                report_title = ReportTitle,
                report_content = ReportContent,
                date_time = DateTime.Now
            });

            await _database.InsertAsync(report);
            return report;
             
        }


        public async Task PrintAllReportsAsync()
        {
            await Init();

            var reports = await _database.Table<Report>().ToListAsync();

            foreach (var report in reports)
            {
                report.PrintReport();
                Console.WriteLine(); // Add a newline for readability
            }
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


        public async Task PrintAllReports()
        {
            await Init();

            var reports = await _database.Table<Report>().ToListAsync();

            foreach (var report in reports)
            {
                Console.WriteLine($"Report ID: {report.report_id}");
                Console.WriteLine($"Title: {report.report_title}");
                Console.WriteLine($"Content: {report.report_content}");
                Console.WriteLine($"Date and Time: {report.date_time}");
                Console.WriteLine();
            }
        }

    }
}

