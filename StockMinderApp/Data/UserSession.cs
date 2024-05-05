using System;
namespace StockMinderApp.Data
{
	public class UserSession
	{
		private bool _isLoggedIn = false;
		public bool IsLoggedIn => _isLoggedIn;



		public UserSession()
		{

		}
		public void Login()
		{
			_isLoggedIn = true;
		}
		public void Logout()
		{
			_isLoggedIn = false;
		}
	}
}

