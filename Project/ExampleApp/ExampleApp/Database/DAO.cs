using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using SQLite.Net;

using Xamarin.Forms;

namespace ExampleApp.Database
{
    class DAO : IDisposable
    {
        private SQLiteConnection _conn;

        public DAO()
        {
            var config = DependencyService.Get<IDBConfig>();
            _conn = new SQLiteConnection(config.Plataform, Path.Combine(config.DBPath, "database.db3"));

            _conn.CreateTable<Contato>();
        }

        public void Save(Contato contato)
        {
            if (contato.Id > 0)
            {
                Update(contato);
            } else
            {
                Insert(contato);
            }
        }

        public void Insert(Contato contato)
        {
            _conn.Insert(contato);
        }

        public void Update(Contato contato)
        {
            _conn.Update(contato);
        }

        public void Delete(Contato contato)
        {
            _conn.Delete(contato);
        }

        public Contato GetById(int id)
        {
            return _conn.Table<Contato>().FirstOrDefault(c => c.Id == id);
        }

        public List<Contato> Get()
        {
            return _conn.Table<Contato>().OrderBy(c => c.Nome.ToLower()).ToList();
        }

        public void Dispose()
        {
            _conn.Dispose();
        }
    }
}
