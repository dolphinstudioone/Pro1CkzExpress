using System.Collections.Generic;
using System.Threading.Tasks;
using NewsForBuh.Models;
using SQLite;

namespace NewsForBuh.Services
{
    public class NewsRepository
    {
        //создаем таблицу в базе данных
        SQLiteAsyncConnection database;

        public NewsRepository(string databasePath)
        {
            database = new SQLiteAsyncConnection(databasePath);
            database.CreateTableAsync<itemNews>();
        
        
        }

        //метод возвращает список новостей
        public Task<List<itemNews>> GetAllNewsAsync()
        {
            return database.Table<itemNews>().OrderByDescending(u=>u.Date).ToListAsync();
        }

        //метод возвращает список новостей в закладках
        public Task<List<itemNews>> GetBookmarksNewsAsync()
        {
            return database.Table<itemNews>().Where(i => i.Bookmark == true).ToListAsync();
        }

        //метод возвращает список новостей по заданным параметрам настроек
        public Task<List<itemNews>> GetNewsWithArgsAsync(string NewsSection)
        {
            
            if (NewsSection == "Все разделы")
               return database.Table<itemNews>().OrderByDescending(u => u.Date).ToListAsync();
            else
               return database.Table<itemNews>().Where(s => s.SectionNews == NewsSection).OrderByDescending(u => u.Date).ToListAsync();
        }

        //метод возращает новость
        public Task<itemNews> GetNewsAsync(int id)
        {
            return database.GetAsync<itemNews>(id);
        }

        //метод удаляет новость
        public Task<int> DeleteNewsAsync(int id)
        {
            return database.DeleteAsync<itemNews>(id);
        }

        //метод сохраняет или обновляет новость
        public Task<int> SaveNewsAsync(itemNews item)
        {
            if (item.Id != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }

        //добавляем новую новость , если новость имеется то обновляем
        public Task<int> AddNewsAsync(itemNews item)
        {
           return database.InsertAsync(item);
        }

        public Task<int> UpdateNewsAsync(itemNews item)
        {
            return database.UpdateAsync(item);
        }

        //ищем и возвращаем уже имеющуюся запись в БД по полю idbx
        public Task<itemNews> ReturnFindItemNews(itemNews item)
        {
            return database.Table<itemNews>().Where(i => i.Idbx == item.Idbx).FirstOrDefaultAsync();
        }

    }
}
