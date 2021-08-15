using BookMyShow.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookMyShow.Data
{
    public class DataGenerator
    {
        public static void SeedData(BookMyShowContext context)
        {


            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Cinemas.Any())
            {
                return;   // DB has been seeded
            }

            var cinemas = new Cinema[]
            {
                    new Cinema{CinemaID =1, City="Pune", Name = "ESquare"},
                    new Cinema{CinemaID = 2, City = "Pune", Name = "Mangala"},

            };


            foreach (Cinema cinema in cinemas)
            {
                context.Cinemas.Add(cinema);
            }
            context.SaveChanges();

            var movies = new Movie[]
            {
                     new Movie{MovieID =1, Title="Avengers" },
                     new Movie{MovieID =2, Title="Chichore" },

            };
            foreach (Movie m in movies)
            {
                context.Movies.Add(m);
            }
            context.SaveChanges();

            var shows = new Show[]
            {
                      new Show{ShowID=1,MovieID =1, CinemaID= 1 },
                      new Show{ShowID=2,MovieID =1, CinemaID= 1 },
                      new Show{ShowID=3,MovieID =2, CinemaID= 2 },
                      new Show{ShowID=4,MovieID =2, CinemaID= 2 },

            };
            foreach (Show s in shows)
            {
                context.Shows.Add(s);
            }


            var showSeats = new ShowSeat[]
           {
                    new ShowSeat{ ShowSeatID=1, ShowID=1, Price=100, SeatNumber="A1"},
                    new ShowSeat{ ShowSeatID=2, ShowID=1, Price=100, SeatNumber="A2"},
                    new ShowSeat{ ShowSeatID=3, ShowID=2, Price=100, SeatNumber="A1"},
                    new ShowSeat{ ShowSeatID=4, ShowID=2, Price=100, SeatNumber="A2"},
                    new ShowSeat{ ShowSeatID=5, ShowID=3, Price=100, SeatNumber="A1"},
                    new ShowSeat{ ShowSeatID=6, ShowID=3, Price=100, SeatNumber="A2"},
                    new ShowSeat{ ShowSeatID=7, ShowID=4, Price=100, SeatNumber="A1"},
                    new ShowSeat{ ShowSeatID=8, ShowID=4, Price=100, SeatNumber="A2"}
           };

            foreach (ShowSeat s in showSeats)
            {
                context.ShowSeats.Add(s);
            }


            context.SaveChanges();


        }
    }
}
