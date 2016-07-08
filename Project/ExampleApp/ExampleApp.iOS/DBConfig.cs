using ExampleApp.Database;
using SQLite.Net.Interop;
using SQLite.Net.Platform.XamarinIOS;
using System;
using Xamarin.Forms;

[assembly: Dependency(typeof(ExampleApp.iOS.DBConfig))]

namespace ExampleApp.iOS
{
    class DBConfig : IDBConfig
    {
        private string _dbPath;
        public string DBPath
        {
            get
            {
                if (string.IsNullOrEmpty(_dbPath))
                {
                    var path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                    _dbPath = System.IO.Path.Combine(path, "..", "Library");
                }

                return _dbPath;
            }
        }

        private ISQLitePlatform _plataform;
        public ISQLitePlatform Plataform
        {
            get
            {
                if (_plataform == null)
                {
                    _plataform = new SQLitePlatformIOS();
                }

                return _plataform;
            }
        }
    }
}
