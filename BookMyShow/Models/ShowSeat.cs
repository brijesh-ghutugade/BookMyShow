using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookMyShow.Models
{
    public class ShowSeat  
    {
        public int ShowSeatID { get; set; }       

        public string SeatNumber { get; set; }

        public bool IsReserved { get; set; }

        public decimal Price { get; set; }

        public int ShowID { get; set; }

    }
}
