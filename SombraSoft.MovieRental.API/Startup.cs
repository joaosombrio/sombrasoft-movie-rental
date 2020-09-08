using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using SombraSoft.MovieRental.API.Services.Member;
using SombraSoft.MovieRental.API.Services.Movie;
using SombraSoft.MovieRental.API.Services.Purchase;
using SombraSoft.MovieRental.MongoDB;
using SombraSoft.MovieRental.MongoDB.DataSeed;
using SombraSoft.MovieRental.MongoDB.Repositories.Member;
using SombraSoft.MovieRental.MongoDB.Repositories.Movie;
using SombraSoft.MovieRental.MongoDB.Repositories.Purchase;

namespace SombraSoft.MovieRental.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddCors();
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "Movie Rental API", Version = "v1" });
            });

            services.Configure<MovieRentalDatabaseSettings>(
                Configuration.GetSection(nameof(MovieRentalDatabaseSettings)));

            services.AddSingleton<IMovieRentalDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<MovieRentalDatabaseSettings>>().Value);

            services.AddTransient<IMovieRepository, MovieRepository>();
            services.AddTransient<IMemberRepository, MemberRepository>();
            services.AddTransient<IPurchaseRepository, PurchaseRepository>();

            services.AddTransient<IMovieService, MovieService>();
            services.AddTransient<IMemberService, MemberService>();
            services.AddTransient<IPurchaseService, PurchaseService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(option =>
            {
                option.AllowAnyOrigin();
                option.AllowAnyHeader();
                option.AllowAnyMethod();
            });
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Movie Rental API v1");
            });

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            var movieRepository = app.ApplicationServices.GetService<IMovieRepository>();
            var memberRepository = app.ApplicationServices.GetService<IMemberRepository>();
            var purchaseRepository = app.ApplicationServices.GetService<IPurchaseRepository>();

            // This piece of code seeds fake data to the database 
            DataSeeder.CreateMovies(movieRepository);
            DataSeeder.CreateMembers(memberRepository);
            DataSeeder.CreatePurchases(movieRepository, memberRepository, purchaseRepository);
        }
    }
}
