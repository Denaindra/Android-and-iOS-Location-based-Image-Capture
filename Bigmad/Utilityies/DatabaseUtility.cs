using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using SQLite;
using XamarinKit.Models.SQLDB;

namespace XamarinKit.Utilityies
{
    public class DatabaseUtility
    {
        private SQLiteConnection _connection;

        public DatabaseUtility(string dbPath)
        {
            _connection = new SQLiteConnection(dbPath);
            Createtables();
        }

        private void Createtables()
        {
            _connection.CreateTable<ItemGroup>();
            _connection.CreateTable<ItemType>();
            _connection.CreateTable<Item>();
        }

        public IEnumerable<ItemGroup> GetGroups()
        {
            return (from t in _connection.Table<ItemGroup>() select t).ToList();
        }

        public IEnumerable<ItemType> GetItemTypes()
        {
            return (from t in _connection.Table<ItemType>() select t).ToList();
        }

        public IEnumerable<Item> GetItems()
        {

            return (from t in _connection.Table<Item>() select t).ToList();
        }

        // get id from auto incremanet ID
        public ItemGroup GetGroupt(int id)
        {
            return _connection.Table<ItemGroup>().FirstOrDefault(t => t.ID == id);
        }

        public ItemType GetItemType(int id)
        {
            return _connection.Table<ItemType>().FirstOrDefault(t => t.ID == id);
        }

        public Item GetItem(int id)
        {
            return _connection.Table<Item>().FirstOrDefault(t => t.ID == id);
        }

        // Delete id from auto incremanet ID
        public void DeleteGroup(int id)
        {
            _connection.Delete<ItemGroup>(id);
        }

        public void DeleteItemType(int id)
        {
            _connection.Delete<ItemType>(id);
        }

        public void DeleteItem(int id)
        {
            _connection.Delete<Item>(id);
        }

        //insert item
        public void AddItemGroup(ItemGroup itemgroup)
        {
            _connection.Insert(itemgroup);
        }

        public void AddItemType(ItemType itemType)
        {
            _connection.Insert(itemType);
        }

        public void AddItem(Item item)
        {
            _connection.Insert(item);
        }

        //update Item

        public void UpdateItem(Item item)
        {
            if (item.Photo != null)
            {
                _connection.Execute("UPDATE Item SET Name = ?, SerialNo = ?, Photo = ?, ItemType = ? WHERE ID = ?",
                new object[] { item.Name, item.SerialNo, item.Photo, item.ItemType, item.ID });
            }
            else
            {
                _connection.Execute("UPDATE Item SET Name = ?, SerialNo = ?, ItemType = ? WHERE ID = ?",
               new object[] { item.Name, item.SerialNo, item.ItemType, item.ID });
            }
        }

        public void UpdateItemTypes(ItemType item)
        {
            if (item.TypePhoto != null)
            {
                _connection.Execute("UPDATE ItemType SET TypeName = ?, TypeSpec = ?, TypePhoto = ? WHERE ID = ?",
                new object[] { item.TypeName, item.TypeSpec, item.TypePhoto, item.ID });
            }
            else
            {
                _connection.Execute("UPDATE ItemType SET TypeName = ?, TypeSpec = ? WHERE ID = ?",
               new object[] { item.TypeName, item.TypeSpec, item.ID });
            }
        }
    }
}
