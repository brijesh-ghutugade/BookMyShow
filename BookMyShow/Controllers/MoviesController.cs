using BookMyShow.Models;
using BookMyShow.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookMyShow.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private IMovieService _movieService;
        public MoviesController(IMovieService movieService)
        {
            this._movieService = movieService;
        }


        // GET: api/Transaction
        [HttpGet("{city}")]
        public ActionResult<IEnumerable<Movie>> Get(string city)
        {
            return Ok(_movieService.GetAllByCity(city));
        }



    }
}
