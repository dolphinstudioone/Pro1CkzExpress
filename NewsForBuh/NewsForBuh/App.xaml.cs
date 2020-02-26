using Xamarin.Forms;
using NewsForBuh.Views;
using NewsForBuh.Services;
using System;
using System.IO;
using NewsForBuh;


[assembly: Dependency(typeof(App))]
namespace NewsForBuh
{
    public partial class App : Application
    {
        
        public const string DATABASE_NAME = "newsforbuh2.db";
        public static NewsRepository database;
        public static NewsRepository Database
        {
            get
            {
                if (database == null)
                {
                    switch (Device.RuntimePlatform)
                    {
                        case Device.Android:
                            database = new NewsRepository(
                                Path.Combine(
                                    Environment.GetFolderPath(Environment.SpecialFolder.Personal), DATABASE_NAME));
                            break;
                        case Device.iOS:
                            string libraryPath = Path.Combine(
                                Environment.GetFolderPath(Environment.SpecialFolder.Personal), "..", "Library"); // папка библиотеки
                            database = new NewsRepository(Path.Combine(libraryPath, DATABASE_NAME));      
                            break;
                        case Device.UWP:
                            database = new NewsRepository(
                                Path.Combine(Environment.GetFolderPath(
                                    Environment.SpecialFolder.LocalApplicationData), DATABASE_NAME));
                            break;
                        default:
                            database = new NewsRepository(
                                Path.Combine(Environment.GetFolderPath(
                                    Environment.SpecialFolder.LocalApplicationData), DATABASE_NAME)); ;
                            break;
                    }                   
                }
       
                return database;
                
            }
        }
        

        public App()
        { 
            InitializeComponent();
            ParserNews parserNews = new ParserNews();
            parserNews.ParseDataSite();
            
            MainPage = new MainPage();
            
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
