using BookMyShow.DTO;
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
    public class BookingsController : ControllerBase
    {
        private IBookingService _bookingService;
        public BookingsController(IBookingService bookingService)
        {
            this._bookingService = bookingService;
        }


        // GET: api/Transaction
        [HttpPost]
        public ActionResult Post([FromBody]BookingDto booking)
        {
            try
            {
                _bookingService.BookSeats(booking);

                return Ok("You have successsfully booked seats!");
            }
            catch (ApplicationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Something went wrong! Please try again.");
            }

        }       
    }
}
