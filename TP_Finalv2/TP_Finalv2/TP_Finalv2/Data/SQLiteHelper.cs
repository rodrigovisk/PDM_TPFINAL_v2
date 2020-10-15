using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TP_Finalv2.Models;

namespace TP_Finalv2
{
    public class SQLiteHelper
    {
        SQLiteAsyncConnection db;
        public SQLiteHelper(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<Mercadoria>().Wait();
        }

        //Insert and Update new record  
        public Task<int> SaveItemAsync(Mercadoria mercadoria)
        {
            if (mercadoria.Id != 0)
            {
                return db.UpdateAsync(mercadoria);
            }
            else
            {
                return db.InsertAsync(mercadoria);
            }
        }

        internal IEnumerable<object> Table<T>()
        {
            throw new NotImplementedException();
        }

        //Delete  
        public Task<int> DeleteItemAsync(Mercadoria mercadoria)
        {
            return db.DeleteAsync(mercadoria);
        }

        //Read All Items  
        public Task<List<Mercadoria>> GetItemsAsync()
        {
            return db.Table<Mercadoria>().ToListAsync();
        }


        //Read Item  
        public Task<Mercadoria> GetItemAsync(int mercadoriaId)
        {
            return db.Table<Mercadoria>().Where(i => i.Id == mercadoriaId).FirstOrDefaultAsync();
        }
    }
}
