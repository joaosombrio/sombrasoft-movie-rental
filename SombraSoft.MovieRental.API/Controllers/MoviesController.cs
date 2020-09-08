using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SombraSoft.MovieRental.API.Services.Movie;
using SombraSoft.MovieRental.MongoDB.Collections;

namespace SombraSoft.MovieRental.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public async Task<IEnumerable<Movie>> Get(CancellationToken token)
        {
            return await _movieService.GetAsync(token);
        }

        [HttpGet("{id}")]
        public async Task<Movie> Get(string id)
        {
            return await _movieService.GetAsync(id);
        }

        [HttpPost]
        public async Task<Movie> Create(Movie movie)
        {
            return await _movieService.CreateAsync(movie);
        }

        [HttpPut("{id}")]
        public async Task<Movie> Update(string id, Movie movie)
        {
            return await _movieService.UpdateAsync(id, movie);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _movieService.RemoveAsync(id);
            return Ok();
        }
    }
}
