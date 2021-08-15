using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookMyShow.Models
{
    public class Show
    {
        public int ShowID { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int CinemaID { get; set; }
        public Cinema Cinema { get; set; }
        public int MovieID { get; set; }
        public Movie Movie { get; set; }
        public List<ShowSeat> Seats { get; set; }
    }
}
