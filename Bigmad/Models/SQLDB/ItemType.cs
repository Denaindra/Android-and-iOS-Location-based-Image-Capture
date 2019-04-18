using System;
using SQLite;
using Xamarin.Forms;

namespace XamarinKit.Models.SQLDB
{
    public class ItemType
    {

        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string TypeName { get; set; }
        public byte[] TypePhoto { get; set; }
        public string TypeSpec { get; set; }
    }

}
