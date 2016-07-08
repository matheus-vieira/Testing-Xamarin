using System;
using SQLite.Net.Interop;

namespace ExampleApp.Database
{
    public interface IDBConfig
    {
        string DBPath { get; }
        ISQLitePlatform Plataform { get; }
    }
}
