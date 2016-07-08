using System;

using ExampleApp.Database;
using SQLite.Net.Interop;
using SQLite.Net.Platform.WinRT;

using Xamarin.Forms;
using Windows.Storage;

[assembly: Dependency(typeof(ExampleApp.WinPhone.DBConfig))]

namespace ExampleApp.WinPhone
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
                    _dbPath = ApplicationData.Current.LocalFolder.Path;
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
                    _plataform = new SQLitePlatformWinRT();
                }

                return _plataform;
            }
        }
    }
}
