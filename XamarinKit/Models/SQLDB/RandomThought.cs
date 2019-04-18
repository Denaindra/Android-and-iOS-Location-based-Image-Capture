using System;
using SQLite;

namespace XamarinKit.Models.SQLDB
{
    public class RandomThought
    {
        public RandomThought()
        {
        }

        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Thought { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
