namespace StockMinderApp;
using Data;

public partial class App : Application
{
	public static UserSession UserSession { get; } = new UserSession();
	public App()
	{
		InitializeComponent();
		MainPage = new Views.FlyoutTemplate();
	}
}

