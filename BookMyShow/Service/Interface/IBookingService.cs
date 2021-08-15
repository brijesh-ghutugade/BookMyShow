using BookMyShow.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookMyShow.Service.Interface
{
    public interface IBookingService
    {
        void BookSeats(BookingDto bookingDto);
    }
}
