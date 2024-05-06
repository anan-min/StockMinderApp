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

        public async void ResetAndInitializeDatabase()
        {
            await Init();
            await _database.DeleteAllAsync<User>();
            await InsertUsersAsync(GenerateUsers());
            await PrintAllUsers();
        }



        private static List<User> GenerateUsers()
        {
            List<User> users = new List<User>();

            // Generate 10 random users
            for (int i = 0; i < 10; i++)
            {
                User user = new User
                {
                    employee_id = $"EMP{i + 1}",
                    username = $"User{i + 1}",
                    password = $"Password{i + 1}",
                    email = $"user{i + 1}@example.com",
                    department = $"Department{i + 1}"
                };
                users.Add(user);
            }

            // Generate a test user with all attributes set
            User testUser = new User
            {
                employee_id = "test",
                username = "test",
                password = "test",
                email = "test@example.com",
                department = "TestDepartment"
            };
            users.Add(testUser);

            return users;
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

        public async Task<bool> InsertUsersAsync(List<User> users)
        {
            try
            {
                await Init();
                await _database.InsertAllAsync(users);
                return true;
            }
            catch (Exception ex)
            {
                // Handle exception if insertion fails
                Console.WriteLine($"Failed to insert users: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> IsCorrectCredentials(string username, string password)
        {
            await Init();
            var user = await _database.Table<User>()
                                .Where(u => u.username == username && u.password == password)
                                .FirstOrDefaultAsync();

            return user != null;
        }


        public async Task PrintAllUsers()
        {
            await Init();

            var users = await _database.Table<User>().ToListAsync();

            foreach (var user in users)
            {
                Console.WriteLine($"Employee ID: {user.employee_id}");
                Console.WriteLine($"Username: {user.username}");
                Console.WriteLine($"Email: {user.email}");
                Console.WriteLine($"Department: {user.department}");
                Console.WriteLine();
            }
        }

    }
}

