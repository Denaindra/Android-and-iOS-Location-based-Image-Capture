using System;
using SQLite;

namespace XamarinKit.Models.SQLDB
{
    public class ItemGroup
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
