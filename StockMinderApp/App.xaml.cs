namespace StockMinderApp;
using Data;

public partial class App : Application
{
	public static UserSession UserSession { get; } = new UserSession();
	public App()
	{
		InitializeComponent();
        App.ApplyGlobalStyles();
        MainPage = new Views.FlyoutTemplate();
	}

    private static void ApplyGlobalStyles()
    {
        var navigationStyle = new Style(typeof(NavigationPage))
        {
            Setters = {
                    new Setter { Property = NavigationPage.BarBackgroundColorProperty, Value = Color.FromHex("#5256fe") }, // Set your desired color here
                    new Setter { Property = NavigationPage.BarTextColorProperty, Value = Color.FromHex("#ffffff") } // Set the title text color to white
            }
        };

        Application.Current.Resources = new ResourceDictionary
        {
            navigationStyle
        };
    }
}

