using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SQLite;
using Xamarin.Forms;
using XamarinKit.Interfaces;
using XamarinKit.Models.SQLDB;

namespace XamarinKit.Utilityies
{
    public class RandomThoughtDatabase
    {
        private SQLiteConnection _connection;

        public RandomThoughtDatabase()
        {

        }
        public void CreateDb()
        {
            if (_connection == null)
            {
                var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "TestSQLite.db3");


                _connection = new SQLiteConnection(dbPath);
                _connection.CreateTable<RandomThought>();
            }

            AddThought("1");
            AddThought("2");
            AddThought("3");
        }
        public IEnumerable<RandomThought> GetThoughts()
        {
            return (from t in _connection.Table<RandomThought>()
                    select t).ToList();
        }

        public RandomThought GetThought(int id)
        {
            return _connection.Table<RandomThought>().FirstOrDefault(t => t.ID == id);
        }

        public void DeleteThought(int id)
        {
            _connection.Delete<RandomThought>(id);
        }

        public void AddThought(string thought)
        {
            var newThought = new RandomThought
            {
                Thought = thought,
                CreatedOn = DateTime.Now
            };

            _connection.Insert(newThought);
        }
    }
}
