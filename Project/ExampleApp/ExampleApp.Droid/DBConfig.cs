using ExampleApp.Database;
using SQLite.Net.Interop;
using SQLite.Net.Platform.XamarinAndroid;
using System;
using Xamarin.Forms;

[assembly: Dependency(typeof(ExampleApp.Droid.DBConfig))]

namespace ExampleApp.Droid
{
    class DBConfig : IDBConfig
    {
        private string _dbPath;
        public string DBPath
        {
            get
            {
                if(string.IsNullOrEmpty(_dbPath))
                {
                    _dbPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                }

                return _dbPath;
            }
        }

        private ISQLitePlatform _plataform;
        public ISQLitePlatform Plataform
        {
            get
            {
                if(_plataform == null)
                {
                    _plataform = new SQLitePlatformAndroid();
                }

                return _plataform;
            }
        }
    }
}