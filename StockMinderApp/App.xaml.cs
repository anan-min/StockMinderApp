namespace StockMinderApp;
using Data;

public partial class App : Application
{
	public static UserSession UserSession { get; } = new UserSession();
    public static ReportDatabase reportDatabase = new();
    public static UserDatabase userDatabase = new();
    public static ProductDatabase productDatabase = new();

    [Obsolete]
    public App()
	{
		InitializeComponent();
        ApplyGlobalStyles();
        SetupDatabase();

        MainPage = new Views.FlyoutTemplate();
    }


    private void SetupDatabase()
    {
        userDatabase.ResetAndInitializeDatabase();
        productDatabase.ResetAndInitializeDatabase();
        // do this for report database and product database
    }

    [Obsolete]
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

