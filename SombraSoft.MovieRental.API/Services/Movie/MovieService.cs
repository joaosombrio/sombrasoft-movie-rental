using SombraSoft.MovieRental.MongoDB.Repositories.Movie;

namespace SombraSoft.MovieRental.API.Services.Movie
{
    public class MovieService : BaseService<MongoDB.Collections.Movie, IMovieRepository>, IMovieService
    {
        public MovieService(IMovieRepository movieRepository) : base(movieRepository) { }
    }
}
