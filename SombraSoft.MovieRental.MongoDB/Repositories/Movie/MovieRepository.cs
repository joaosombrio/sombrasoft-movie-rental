namespace SombraSoft.MovieRental.MongoDB.Repositories.Movie
{
    public class MovieRepository : BaseRepository<Collections.Movie>, IMovieRepository
    {
        public MovieRepository(IMovieRentalDatabaseSettings dbSettings) : base(dbSettings)
        {
            
        }
    }
}
