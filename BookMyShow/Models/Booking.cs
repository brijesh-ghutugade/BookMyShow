using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookMyShow.Models
{
    public class Booking
    {
        public int BookingID { get; set; }
        public DateTime CreatedOn { get; set; }
        public BookingStatus Status { get; set; }
        public int ShowID { get; set; }
        public Show Show { get; set; }
        public List<ShowSeat> Seats { get; set; }
    }

    public enum BookingStatus
    {
        REQUESTED,
        PENDING,
        CONFIRMED,
        CHECKED_IN,
        CANCELED,
        ABANDONED
    }
}
