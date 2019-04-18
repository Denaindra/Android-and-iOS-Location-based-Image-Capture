using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinKit.Models;
using XamarinKit.Utilityies;
using XamarinKit.Views;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace XamarinKit
{
    public partial class App : Application
    {
        static DatabaseUtility database;

        public App()
        {
            InitializeComponent();
            MainPage = new GroupPage();
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

        public static DatabaseUtility Database
        {
            get
            {
                if (database == null)
                {
                    database = new DatabaseUtility(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "GroupItemSQLite.db3"));
                }
                return database;
            }
        }
    }
}
