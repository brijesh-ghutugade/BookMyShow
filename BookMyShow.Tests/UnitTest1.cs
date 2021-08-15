using BookMyShow.Data.Repository;
using BookMyShow.Models;
using BookMyShow.Service.Implementation;
using Castle.Core.Logging;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Tests
{
    public class BookingServiceTests
    {

        private Mock<IUnitOfWork> _unitOfWork = new Mock<IUnitOfWork>();
        private Mock<ILogger<BookingService>> _logger = new Mock<ILogger<BookingService>>();

        private BookingService _bookingService;






        [SetUp]
        public void Setup()
        {
            _bookingService = new BookingService(_unitOfWork.Object, _logger.Object);

        }

        [Test]
        public void BookSeats_ShouldThrow_ApplicationException_IfSeatIsReserved()
        {
            Show show = new Show()
            {
                ShowID = 1,
                Seats = new List<ShowSeat>() {
                new ShowSeat(){
                    SeatNumber = "A1",
                    IsReserved = true
                }
            }
            };
            _unitOfWork.Setup(s => s.ShowRepository.GetWithChildren(It.IsAny<int>(), It.IsAny<string>())).Returns(show);

            var bookingDto = new BookMyShow.DTO.BookingDto()
            {

                ShowId = 1,
                Seats = new List<string>() { "A1" }
            };

            Assert.Throws<ApplicationException>(() => { _bookingService.BookSeats(bookingDto); });
        }


        [Test]
        public void BookSeats_ShouldCall_BookingRepository_Insert_ShowSeatRepository_Edit()
        {
            Show show = new Show()
            {
                ShowID = 1,
                Seats = new List<ShowSeat>() {
                new ShowSeat(){
                    SeatNumber = "A1",
                    IsReserved = false
                },
                 new ShowSeat(){
                    SeatNumber = "A2",
                    IsReserved = false
                }
            }
            };
            _unitOfWork.Setup(s => s.ShowRepository.GetWithChildren(It.IsAny<int>(), It.IsAny<string>())).Returns(show);
            _unitOfWork.Setup(s => s.ShowSeatRepository.Edit(It.IsAny<ShowSeat>()));
            _unitOfWork.Setup(s => s.BookingRepository.Insert(It.IsAny<Booking>()));

            var bookingDto = new BookMyShow.DTO.BookingDto()
            {
                ShowId = 1,
                Seats = new List<string>() { "A1", "A2" }
            };

            _bookingService.BookSeats(bookingDto);
            _unitOfWork.Verify(u => u.ShowSeatRepository.Edit(It.IsAny<ShowSeat>()), Times.Exactly(2));
            _unitOfWork.Verify(u => u.BookingRepository.Insert(It.IsAny<Booking>()), Times.Once);

        }
    }
}