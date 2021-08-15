using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookMyShow.DTO
{
    public class BookingDto
    {
        public int ShowId { get; set; }

        public List<string> Seats { get; set; }
    }
}
