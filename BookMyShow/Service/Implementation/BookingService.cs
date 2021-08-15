using BookMyShow.Data.Repository;
using BookMyShow.DTO;
using BookMyShow.Models;
using BookMyShow.Service.Interface;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookMyShow.Service.Implementation
{
    public class BookingService : IBookingService
    {
        IUnitOfWork _unitOfWork;
        ILogger _logger;

        public BookingService(IUnitOfWork unitOfWork, ILogger<BookingService> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public void BookSeats(BookingDto bookingDto)
        {
            try
            {
                var show = _unitOfWork.ShowRepository.GetWithChildren(bookingDto.ShowId, "Seats");

                foreach (var seat in show.Seats.Where(s => bookingDto.Seats.Contains(s.SeatNumber)))
                {
                    if (seat.IsReserved) {
                        _logger.LogWarning($"Booking for seat {seat.SeatNumber} can not be processed as it is already booked!");
                        throw new ApplicationException($"Booking for seat {seat.SeatNumber} can not be processed as it is already booked!");
                    }
                    seat.IsReserved = true;
                    _unitOfWork.ShowSeatRepository.Edit(seat);
                }

                var booking = new Booking()
                {
                    ShowID = show.ShowID,
                    Show = show,
                    Seats = show.Seats.Where(s => bookingDto.Seats.Contains(s.SeatNumber)).ToList(),
                    Status = BookingStatus.CONFIRMED
                };

                _unitOfWork.BookingRepository.Insert(booking);
                _unitOfWork.Save();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Booking failed due to {ex.Message}");
                throw;
            }
          
        }
    }
}
