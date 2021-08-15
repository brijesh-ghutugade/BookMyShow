using BookMyShow.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookMyShow.Data.Repository
{
    public partial class UnitOfWork : IUnitOfWork
    {
        private DbContext _context;
        private IRepository<Cinema> _cinemaRepository;
        public IRepository<Cinema> CinemaRepository
        {
            get
            {

                if (_cinemaRepository == null)
                    _cinemaRepository = new Repository<Cinema>(_context);
                return _cinemaRepository;
            }
            set
            {
                if (value != null)
                    _cinemaRepository = value;
            }
        }

        private IRepository<Show> _showRepository;
        public IRepository<Show> ShowRepository
        {
            get
            {

                if (_showRepository == null)
                    _showRepository = new Repository<Show>(_context);
                return _showRepository;
            }
            set
            {
                if (value != null)
                    _showRepository = value;
            }
        }


        private IRepository<Booking> _bookingRepository;
        public IRepository<Booking> BookingRepository
        {
            get
            {

                if (_bookingRepository == null)
                    _bookingRepository = new Repository<Booking>(_context);
                return _bookingRepository;
            }
            set
            {
                if (value != null)
                    _bookingRepository = value;
            }
        }

        private IRepository<ShowSeat> _showSeatRepository;
        public IRepository<ShowSeat> ShowSeatRepository
        {
            get
            {

                if (_showSeatRepository == null)
                    _showSeatRepository = new Repository<ShowSeat>(_context);
                return _showSeatRepository;
            }
            set
            {
                if (value != null)
                    _showSeatRepository = value;
            }
        }

        public UnitOfWork(BookMyShowContext context)
        {
            _context = context;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this._context.Dispose();
                }
            }

            this.disposed = true;
        }
    }
}
