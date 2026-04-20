using SQLite;

namespace ProjectManager.Models
{
    public class Movie
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public string Genre { get; set; }
        public double Rating { get; set; }
        public string ImagePath { get; set; }
    }
}