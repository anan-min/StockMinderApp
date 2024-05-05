using System;
using SQLite;

namespace StockMinderApp.Data
{
	public class UserDatabase
	{
		public UserDatabase()
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

            var result = await _database.CreateTableAsync<User>();
        }



        private static List<User> GenerateUsers()
        {
            List<User> users = new List<User>();

            //for (int i = 0; i < 10; i++)
            //{
            //    reports.Add(new Report
            //    {
            //        report_title = $"Report {i + 1}",
            //        report_content = $"Content for Report {i + 1}",
            //        date_time = DateTime.Now.AddDays(-i)
            //    });
            //}

            return users;
        }


        private async Task InsertGeneratedReports()
        {
            List<User> users = GenerateUsers();
            await Init();
            await _database.InsertAllAsync(users);
        }


        private async Task<User> GetReportAsync(string username)
        {
            await Init();
            return await _database
                .Table<User>()
                .Where(n => n.username == username)
                .FirstOrDefaultAsync();
        }


    }
}

