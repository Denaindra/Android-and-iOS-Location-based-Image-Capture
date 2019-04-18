using System;
using SQLite;
using Xamarin.Forms;

namespace XamarinKit.Models.SQLDB
{
    public class Item
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string SerialNo { get; set; }
        public string Group { get; set; }
        public string Storage { get; set; }
        public string ItemType { get; set; }
        public byte[] Photo { get; set; }
        public double Latitude { get; set; }
        public double Logitude { get; set; }
    }

    public class UIItemType
    {
        public int ID { get; set; }
        public string TypeName { get; set; }
        public ImageSource TypePhoto { get; set; }
        public string TypeSpec { get; set; }
    }
}
