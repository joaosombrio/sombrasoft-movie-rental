using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading;
using Bogus;
using SombraSoft.MovieRental.MongoDB.Collections;
using SombraSoft.MovieRental.MongoDB.Repositories.Member;
using SombraSoft.MovieRental.MongoDB.Repositories.Movie;
using SombraSoft.MovieRental.MongoDB.Repositories.Purchase;

namespace SombraSoft.MovieRental.MongoDB.DataSeed
{
    public static class DataSeeder
    {
        public static void CreateMovies(IMovieRepository movieRepository)
        {
            if (movieRepository.CollectionExistsAsync().Result) return;

            var movies = JsonSerializer.Deserialize<IEnumerable<Movie>>(Datasets.Movies);
            foreach (var movie in movies)
            {
                movie.RentalCost = decimal.Round((new Randomizer().Decimal() * 5) + 1, 2, MidpointRounding.AwayFromZero);
                movie.RentalDuration = new Randomizer().Int(2, 4);
            }
            movieRepository.CreateManyAsync(movies).Wait();
        }

        public static void CreateMembers(IMemberRepository memberRepository)
        {
            if (memberRepository.CollectionExistsAsync().Result) return;

            var bogus = new Faker();
            var bogusMembers = Enumerable.Range(1, 150).Select(i => new Member()
            {
                Address = bogus.Address.FullAddress(),
                FullName = bogus.Name.FullName(),
                PhoneNumber = bogus.Phone.PhoneNumber()
            });

            memberRepository.CreateManyAsync(bogusMembers).Wait();
        }

        public static void CreatePurchases(IMovieRepository movieRepository, IMemberRepository memberRepository, IPurchaseRepository purchaseRepository)
        {
            if (purchaseRepository.CollectionExistsAsync().Result) return;

            var bogus = new Faker();
            var allMembers = memberRepository.GetAsync(CancellationToken.None).Result.ToList();
            var allMovies = movieRepository.GetAsync(CancellationToken.None).Result.ToList();
            var bogusPurchases = new List<Purchase>();
            var random = new Random();

            for (var i = 0; i <= 3000; i++)
            {
                var rentalDate = bogus.Date.Between(new DateTime(2005, 1, 1), DateTime.Today);
                var rentalExpiryDate = rentalDate.Date.AddDays(random.Next(2, 4));
                var moviesRented = allMovies.OrderBy(x => random.Next()).Take(random.Next(2, 7)).ToList();

                bogusPurchases.Add(new Purchase
                {
                    MemberId = allMembers[random.Next(allMembers.Count - 1)].Id,
                    RentalDate = rentalDate,
                    RentalExpiry = rentalExpiryDate,
                    CreatedOn = rentalDate,
                    UpdatedOn = rentalExpiryDate,
                    MovieIds = moviesRented.Select(m => m.Id),
                    TotalCost = moviesRented.Sum(m => m.RentalCost)
                });
            }

            purchaseRepository.CreateManyAsync(bogusPurchases);
        }
    }
}
