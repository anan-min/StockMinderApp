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


        public async Task<bool> IsEmployeeIdAlreadyExists(string EmployeeId)
        {;
            await Init();
            var user = await _database.Table<User>()
                              .Where(u => u.employee_id == EmployeeId)
                              .FirstOrDefaultAsync();

            return user != null;
        }


        public async Task<bool> IsUsernameAlreadyExists(String Username)
        {
            await Init();
            var user = await _database.Table<User>()
                              .Where(u => u.username == Username)
                              .FirstOrDefaultAsync();

            return user != null;
        }


        public async Task<bool> IsEmailAlreadyExists(String Email)
        {
            await Init();
            var user = await _database.Table<User>()
                              .Where(u => u.email == Email)
                              .FirstOrDefaultAsync();

            return user != null;
        }


        public async Task<User> InsertUserAsync(string employeeid, string username, string password, string email, string department)
        {
            await Init();
            User user = (new User
            {
                employee_id = employeeid,
                username = username,
                password = password,
                email = email,
                department = department,
            });

            await _database.InsertAsync(user);
            return user;

        }
    }
}

