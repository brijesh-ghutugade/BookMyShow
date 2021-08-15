using BookMyShow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookMyShow.Data.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Cinema> CinemaRepository { get; set; }

        IRepository<Show> ShowRepository { get; set; }

        IRepository<Booking> BookingRepository { get; set; }

        IRepository<ShowSeat> ShowSeatRepository { get; set; }

        void Save();
    }
}
