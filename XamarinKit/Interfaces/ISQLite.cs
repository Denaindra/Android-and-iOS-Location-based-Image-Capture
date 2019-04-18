using System;
using SQLite;

namespace XamarinKit.Interfaces
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
