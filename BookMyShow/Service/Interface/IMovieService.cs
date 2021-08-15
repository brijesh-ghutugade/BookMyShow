using BookMyShow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookMyShow.Service.Interface
{
    public interface IMovieService
    {
        IEnumerable<Movie> GetAllByCity(string city);    
    }
}
