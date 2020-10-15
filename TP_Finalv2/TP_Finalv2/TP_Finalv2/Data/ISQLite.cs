using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace TP_Finalv2.Data
{
    public interface ISQLite
    {
        SQLiteConnection GetConexao();
    }
}
