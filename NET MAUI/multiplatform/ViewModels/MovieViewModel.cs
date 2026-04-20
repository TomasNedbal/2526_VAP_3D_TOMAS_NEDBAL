using System.ComponentModel;
using System.Windows.Input;
using ProjectManager.Models;
using ProjectManager.Database;

namespace ProjectManager.ViewModels
{
    public class MovieViewModel : INotifyPropertyChanged
    {
        private readonly Movie _movie;
        private readonly DatabaseService _database;

        public event PropertyChangedEventHandler? PropertyChanged;

        public MovieViewModel(Movie movie, DatabaseService database)
        {
            _movie = movie;
            _database = database;

            SaveCommand = new Command(async () => await Save());
        }

        public string Title
        {
            get => _movie.Title;
            set { _movie.Title = value; OnPropertyChanged(nameof(Title)); }
        }

        public string Description
        {
            get => _movie.Description;
            set { _movie.Description = value; OnPropertyChanged(nameof(Description)); }
        }

        public int Year
        {
            get => _movie.Year;
            set { _movie.Year = value; OnPropertyChanged(nameof(Year)); }
        }

        public string Genre
        {
            get => _movie.Genre;
            set { _movie.Genre = value; OnPropertyChanged(nameof(Genre)); }
        }

        public double Rating
        {
            get => _movie.Rating;
            set { _movie.Rating = value; OnPropertyChanged(nameof(Rating)); }
        }

        public string ImagePath
        {
            get => _movie.ImagePath;
            set { _movie.ImagePath = value; OnPropertyChanged(nameof(ImagePath)); }
        }

        public ICommand SaveCommand { get; }

        private async Task Save()
        {
            await _database.SaveMovieAsync(_movie);
        }

        private void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}