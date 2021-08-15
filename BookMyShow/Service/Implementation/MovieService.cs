using BookMyShow.Data.Repository;
using BookMyShow.Models;
using BookMyShow.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookMyShow.Service.Implementation
{
    public class MovieService : IMovieService
    {
        IUnitOfWork unitOfWork;

        public MovieService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<Movie> GetAllByCity(string city)
        {
            var shows = unitOfWork.ShowRepository.FindBy(c => c.Cinema.City.Equals(city, StringComparison.InvariantCultureIgnoreCase), new List<string> { "Shows.Movie"});

            return  shows.Select(s => s.Movie).Distinct();
        }

        public IEnumerable<Show> GetAllShows(string movieName)
        {
            var shows = unitOfWork.ShowRepository.FindBy(s => s.Movie.Title.Equals(movieName, StringComparison.InvariantCultureIgnoreCase), new List<string> { "Cinema", "Movie" });

            return shows.ToList(); 
        }
    }
}
