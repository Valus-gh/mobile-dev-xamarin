using MeteoAppSkeleton.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace MeteoAppSkeleton.persistence
{
    public class SQLiteService
    {

        private readonly SQLiteAsyncConnection database;

        public SQLiteService()
        { 
            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "WeatherAppDB.db3");
            database = new SQLiteAsyncConnection(path);

        }

        public void init()
        {
            database.CreateTableAsync<Entry>().Wait();
        }

        //#################### CRUD ####################//

        public Task<List<Entry>> GetAllItems()
        {
            return database.Table<Entry>().ToListAsync();
        }

        public Task<List<Entry>> GetItemsForId(string id)
        {
            return database.QueryAsync<Entry>("SELECT * FROM [ENTRY] WHERE [Id] = ?", id);
        }

        public Task<int> AddItem(Entry item)
        {
            if (GetItemsForId(item.ID).Result.Count > 0)
                return database.UpdateAsync(item);

            return database.InsertAsync(item);
        }

        public Task<int> DeleteItem(Entry item)
        {
            return database.DeleteAsync(item);
        }

    }
}
