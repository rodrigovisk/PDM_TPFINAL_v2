using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using TP04.Data;
using TP04.Droid;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLite_Android))]

namespace TP04.Droid
{
    public class SQLite_Android : ISQLite
    {
        public SQLite_Android()
        {
        }
        public SQLite.SQLiteConnection
        GetConexao()
        {
            var arquivodb = "ifspdb.db3";
            string caminho =
            System.Environment.GetFolderPath
            (System.Environment.SpecialFolder.Personal);
            var local = Path.Combine(caminho, arquivodb);
            var conexao = new
            SQLite.SQLiteConnection(local);
            return conexao;
        }
    }
}