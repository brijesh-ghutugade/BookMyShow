using BookMyShow.Models;
using BookMyShow.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookMyShow.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShowsController : ControllerBase
    {
        private IShowService _showService;
        private ILogger _logger;
        public ShowsController(IShowService showService, ILogger<ShowsController> logger)
        {
            this._showService = showService;
            _logger = logger;
        }


        [HttpGet("{movie}")]
        public IEnumerable<Show> Get(string movie)
        {
            return _showService.GetAllShowsForMovie(movie);
        }

        [HttpGet("{id}/ShowSeats")]
        public ActionResult<IEnumerable<ShowSeat>> Get(int id)
        {
            try
            {
                var showSeats = _showService.GetShowSeats(id);
                return Ok(showSeats);
            }
            catch (KeyNotFoundException ex)
            {
               
                return NotFound();
            }
        }

    }
}
