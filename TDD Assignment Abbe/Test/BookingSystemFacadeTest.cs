using System;
using System.Collections.Generic;
using Xunit;
using Moq;
using TDD_Assignment_Abbe.Facade;
using TDD_Assignment_Abbe.Classes;

namespace TDD_Assignment_Abbe.Test
{
    public class BookingSystemFacadeTest
    {
        private readonly BookingSystemFacade _facade;
        private readonly Mock<BookingSystem> _mockBookingSystem;

        // Constructor to initialize the mock and inject it into the facade
        public BookingSystemFacadeTest()
        {
            // Initialize the mock
            _mockBookingSystem = new Mock<BookingSystem>();

            // Inject the mock into the facade
            _facade = new BookingSystemFacade(_mockBookingSystem.Object);
        }

        // Tests that booking a valid time slot returns true
        [Fact]
        public void BookSlot_ReturnsTrue_WhenBookingIsSuccessful()
        {
            // Arrange
            var startTime = DateTime.Now.AddHours(1);
            var endTime = DateTime.Now.AddHours(2);

            _mockBookingSystem
                .Setup(bs => bs.BookTimeSlot(startTime, endTime))
                .Returns(true);

            // Act
            var result = _facade.BookSlot(startTime, endTime);

            // Assert
            Assert.True(result);
            _mockBookingSystem.Verify(bs => bs.BookTimeSlot(startTime, endTime), Times.Once);
        }

        // Tests that booking with an invalid time range throws an exception
        [Fact]
        public void BookSlot_ThrowsArgumentException_WhenStartTimeIsAfterEndTime()
        {
            // Arrange
            var startTime = DateTime.Now.AddHours(2);
            var endTime = DateTime.Now.AddHours(1);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => _facade.BookSlot(startTime, endTime));

            // Verify that the mock method was never called
            _mockBookingSystem.Verify(bs => bs.BookTimeSlot(It.IsAny<DateTime>(), It.IsAny<DateTime>()), Times.Never);
        }

        // Tests that available time slots are retrieved correctly
        [Fact]
        public void GetAvailableTimeSlots_ReturnsCorrectTimeSlots()
        {
            // Arrange
            var dayStart = DateTime.Now.Date;
            var dayEnd = dayStart.AddDays(1);

            var expectedSlots = new List<DateTime>
            {
                dayStart.AddHours(9),
                dayStart.AddHours(10),
                dayStart.AddHours(11)
            };

            _mockBookingSystem
                .Setup(bs => bs.GetAvailableTimeSlots(dayStart, dayEnd))
                .Returns(expectedSlots);

            // Act
            var availableSlots = _facade.GetAvailableTimeSlots(dayStart, dayEnd);

            // Assert
            Assert.Equal(expectedSlots, availableSlots);
            _mockBookingSystem.Verify(bs => bs.GetAvailableTimeSlots(dayStart, dayEnd), Times.Once);
        }
    }
}

