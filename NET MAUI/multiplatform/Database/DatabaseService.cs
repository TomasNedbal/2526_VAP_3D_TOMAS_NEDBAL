using ProjectManager.Models;
using SQLite;

namespace ProjectManager.Database
{
    public class DatabaseService
    {
        private readonly SQLiteAsyncConnection _database;

        public DatabaseService(string dbPath = "movies.db3")
        {
            _database = new SQLiteAsyncConnection(
                Path.Combine(FileSystem.AppDataDirectory, dbPath));

            _database.CreateTableAsync<Movie>().Wait();
        }

        public Task<List<Movie>> GetMoviesAsync()
        {
            return _database.Table<Movie>().ToListAsync();
        }

        public async Task<int> SaveMovieAsync(Movie movie)
        {
            if (movie.Id != 0)
                return await _database.UpdateAsync(movie);
            else
                return await _database.InsertAsync(movie);
        }

        public Task<int> DeleteMovieAsync(Movie movie)
        {
            return _database.DeleteAsync(movie);
        }
    }
}