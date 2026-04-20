using ProjectManager.Database;
using System.Collections.ObjectModel;

namespace ProjectManager.ViewModels
{
    public class MainViewModel
    {
        public ObservableCollection<MovieViewModel> Movies { get; set; } = new();

        private readonly DatabaseService _database;

        public MainViewModel(DatabaseService database)
        {
            _database = database;
            LoadMovies();
        }

        private async void LoadMovies()
        {
            var movies = await _database.GetMoviesAsync();

            foreach (var movie in movies)
            {
                Movies.Add(new MovieViewModel(movie, _database));
            }
        }
    }
}