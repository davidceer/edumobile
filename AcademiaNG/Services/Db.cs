using System;
using AcademiaNG.Helper;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;
using System.Linq;
using AcademiaNG.Models;

namespace AcademiaNG.Services
{
    public class Db
    {
        static SQLiteAsyncConnection _database;
        public SQLiteAsyncConnection Database => _database;

        #region Constants
        const string DatabaseFilename = "AcademiaSQLite.db3"; // AcademiaSQLite.sqldb

        const SQLite.SQLiteOpenFlags Flags =
            // open the database in read/write mode
            SQLite.SQLiteOpenFlags.ReadWrite |
            // create the database if it doesn't exist
            SQLite.SQLiteOpenFlags.Create |
            // enable multi-threaded database access
            SQLite.SQLiteOpenFlags.SharedCache;

        static string DatabasePath
        {
            get
            {
                var basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                return Path.Combine(basePath, DatabaseFilename);
            }
        }
        #endregion

        public static readonly AsyncLazy<Db> Instance = new AsyncLazy<Db>(async () =>
        {
            var instance = new Db();

            var baseType = typeof(IDbEntity);
            var entityTypes = baseType.Assembly.GetExportedTypes()
                .Where(p => baseType.IsAssignableFrom(p) && p.IsClass && !p.IsAbstract);
                
            foreach (var entityType in entityTypes)
            {
                await _database.CreateTableAsync(entityType);
            }

            return instance;
        });

        private Db()
        {
            _database = new SQLiteAsyncConnection(DatabasePath, Flags);
        }

        public Task<List<T>> GetAllItemsAsync<T>() where T : class, new()
        {
            return _database.Table<T>().ToListAsync();
        }

        public Task<int> SaveItemAsync<T>(T item)
        {
            return _database.InsertAsync(item, typeof(T));
        }

        public Task<int> UpdateItemAsync<T>(T item)
        {
            return _database.UpdateAsync(item, typeof(T));
        }

    }
}

