namespace SombraSoft.MovieRental.MongoDB
{
    public class MovieRentalDatabaseSettings : IMovieRentalDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IMovieRentalDatabaseSettings
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
