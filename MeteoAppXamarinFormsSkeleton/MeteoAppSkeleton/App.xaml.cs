using MeteoAppSkeleton.Views;
using Xamarin.Forms;
using MeteoAppSkeleton.persistence;
namespace MeteoAppSkeleton
{
    public partial class App : Application
    {
        private static SQLiteService database;

        public static SQLiteService Database
        {
            get
            {
                if (database == null)
                    database = new persistence.SQLiteService();

                return database;
            }
        }

        public App()
        {
            InitializeComponent();

            var nav = new NavigationPage(new MeteoListPage())
            {
                BarBackgroundColor = Color.MediumPurple,
                BarTextColor = Color.White
            };

            MainPage = nav;
        }

        protected override void OnStart()
        {

            Database.init();

        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
