using BookMyShow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookMyShow.Service.Interface
{
    public interface IShowService
    {
        IEnumerable<Show> GetAllShowsForMovie(string movieName);

        IEnumerable<ShowSeat> GetShowSeats(int showId);
    }
}
