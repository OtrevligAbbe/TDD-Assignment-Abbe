using System;
using System.Collections.Generic;
using Moq;
using Xunit;
using TDD_Assignment_Abbe.Classes;
using TDD_Assignment_Abbe.Facade;

namespace TDD_Assignment_Abbe.Test
{
    public class BookingSystemFacadeTest
    {
        private readonly Mock<BookingSystem> _mockBookingSystem;
        private readonly BookingSystemFacade _facade;

        public BookingSystemFacadeTest()
        {
            _mockBookingSystem = new Mock<BookingSystem>();
            _facade = new BookingSystemFacade(_mockBookingSystem.Object);
        }

        [Fact]
        public void BookTimeSlot_ShouldReturnTrue_WhenSlotIsAvailable()
        {
            // Arrange
            var startTime = DateTime.Now;
            var endTime = startTime.AddHours(1);

            _mockBookingSystem
                .Setup(bs => bs.BookTimeSlot(startTime, endTime))
                .Returns(true);

            // Act
            var result = _facade.BookTimeSlot(startTime, endTime);

            // Assert
            Assert.True(result);
            _mockBookingSystem.Verify(bs => bs.BookTimeSlot(startTime, endTime), Times.Once);
        }

        [Fact]
        public void BookTimeSlot_ShouldReturnFalse_WhenSlotIsUnavailable()
        {
            // Arrange
            var startTime = DateTime.Now;
            var endTime = startTime.AddHours(1);

            _mockBookingSystem
                .Setup(bs => bs.BookTimeSlot(startTime, endTime))
                .Returns(false);

            // Act
            var result = _facade.BookTimeSlot(startTime, endTime);

            // Assert
            Assert.False(result);
            _mockBookingSystem.Verify(bs => bs.BookTimeSlot(startTime, endTime), Times.Once);
        }

        [Fact]
        public void GetAvailableTimeSlots_ShouldReturnCorrectSlots()
        {
            // Arrange
            var dayStart = DateTime.Today;
            var dayEnd = dayStart.AddDays(1);
            var expectedSlots = new List<(DateTime Start, DateTime End)>
            {
                (dayStart, dayStart.AddHours(2)),
                (dayStart.AddHours(3), dayEnd)
            };

            _mockBookingSystem
                .Setup(bs => bs.GetAvailableTimeSlots(dayStart, dayEnd))
                .Returns(expectedSlots);

            // Act
            var result = _facade.GetAvailableTimeSlots(dayStart, dayEnd);

            // Assert
            Assert.Equal(expectedSlots, result);
            _mockBookingSystem.Verify(bs => bs.GetAvailableTimeSlots(dayStart, dayEnd), Times.Once);
        }
    }
}

