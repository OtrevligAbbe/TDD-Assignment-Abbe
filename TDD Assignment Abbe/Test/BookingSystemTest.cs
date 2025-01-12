using System;
using System.Collections.Generic;
using Xunit;
using TDD_Assignment_Abbe.Classes;

namespace TDD_Assignment_Abbe.Test
{
    public class BookingSystemTest
    {
        private readonly BookingSystem _bookingSystem;

        public BookingSystemTest()
        {
            _bookingSystem = new BookingSystem();
        }

        [Fact]
        public void BookTimeSlot_ShouldReturnTrue_WhenSlotIsAvailable()
        {
            // Arrange
            var startTime = DateTime.Now;
            var endTime = startTime.AddHours(1);

            // Act
            var result = _bookingSystem.BookTimeSlot(startTime, endTime);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void BookTimeSlot_ShouldReturnFalse_WhenSlotIsUnavailable()
        {
            // Arrange
            var startTime = DateTime.Now;
            var endTime = startTime.AddHours(1);
            _bookingSystem.BookTimeSlot(startTime, endTime); // Book an overlapping slot

            // Act
            var result = _bookingSystem.BookTimeSlot(startTime.AddMinutes(30), endTime.AddMinutes(30));

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void GetAvailableTimeSlots_ShouldReturnAllSlots_WhenNoBookingsExist()
        {
            // Arrange
            var dayStart = DateTime.Today;
            var dayEnd = dayStart.AddDays(1);

            // Act
            var availableSlots = _bookingSystem.GetAvailableTimeSlots(dayStart, dayEnd);

            // Assert
            var enumerator = availableSlots.GetEnumerator();
            Assert.True(enumerator.MoveNext()); // Ensure there is at least one slot
            Assert.Equal(dayStart, enumerator.Current.Start.Date); // Compare only the date
            Assert.Equal(dayEnd, enumerator.Current.End.Date);     // Compare only the date
        }


        [Fact]
        public void GetAvailableTimeSlots_ShouldExcludeBookedSlots()
        {
            // Arrange
            var dayStart = DateTime.Today;
            var dayEnd = dayStart.AddDays(1);
            var bookingStart = dayStart.AddHours(2);
            var bookingEnd = bookingStart.AddHours(2);

            _bookingSystem.BookTimeSlot(bookingStart, bookingEnd);

            // Act
            var availableSlots = _bookingSystem.GetAvailableTimeSlots(dayStart, dayEnd);

            // Assert
            Assert.Contains((dayStart, bookingStart), availableSlots);
            Assert.Contains((bookingEnd, dayEnd), availableSlots);
        }
    }
}

