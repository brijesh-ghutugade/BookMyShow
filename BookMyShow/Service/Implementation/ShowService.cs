using BookMyShow.Data.Repository;
using BookMyShow.Models;
using BookMyShow.Service.Interface;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookMyShow.Service.Implementation
{
    public class ShowService : IShowService
    {
        IUnitOfWork _unitOfWork;
        ILogger _logger;

        public ShowService(IUnitOfWork unitOfWork, ILogger<ShowService> logger)
        {
            this._unitOfWork = unitOfWork;
            _logger = logger;
        }

        public IEnumerable<Show> GetAllShowsForMovie(string movieName)
        {
            var shows = _unitOfWork.ShowRepository.FindBy(s => s.Movie.Title.Equals(movieName, StringComparison.InvariantCultureIgnoreCase), new List<string> { "Cinema" });

            return shows.ToList();
        }

        public IEnumerable<ShowSeat> GetShowSeats(int showId)
        {
            var show = _unitOfWork.ShowRepository.FindBy(s => s.ShowID.Equals(showId), new List<string>() { "Seats" }).FirstOrDefault();

            if (show is null)
            {
                _logger.LogInformation($"Show not found for showId: {showId}");
                throw new KeyNotFoundException();
            }
            else
            {
                return show.Seats;
            }
        }
    }

}
