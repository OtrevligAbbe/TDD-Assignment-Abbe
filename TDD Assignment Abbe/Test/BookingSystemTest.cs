using System;
using TDD_Assignment_Abbe.Classes;
using Xunit;

namespace TDD_Assignment_Abbe.Test
{
    public class BookingSystemTest
    {
        private readonly BookingSystem _bookingSystem;

        // Initializes a new BookingSystem instance for each test
        public BookingSystemTest()
        {
            _bookingSystem = new BookingSystem();
        }

        // Tests that booking a time slot returns true when the slot is available
        [Fact]
        public void BookTimeSlot_ReturnsTrue_WhenSlotIsAvailable()
        {
            var result = _bookingSystem.BookTimeSlot(DateTime.Now.AddHours(1), DateTime.Now.AddHours(2));
            Assert.True(result);
        }

        // Tests that booking a time slot returns false when the slot is already taken
        [Fact]
        public void BookTimeSlot_ReturnsFalse_WhenSlotIsNotAvailable()
        {
            _bookingSystem.BookTimeSlot(DateTime.Now.AddHours(1), DateTime.Now.AddHours(2));
            var result = _bookingSystem.BookTimeSlot(DateTime.Now.AddHours(1).AddMinutes(30), DateTime.Now.AddHours(2));
            Assert.False(result);
        }

        // Tests that booking a time slot throws an exception when the start time is after the end time
        [Fact]
        public void BookTimeSlot_ThrowsArgumentException_WhenStartTimeIsAfterEndTime()
        {
            Assert.Throws<ArgumentException>(() => _bookingSystem.BookTimeSlot(DateTime.Now.AddHours(2), DateTime.Now.AddHours(1)));
        }

        // Tests that GetAvailableTimeSlots returns the correct available slots
        [Fact]
        public void GetAvailableTimeSlots_ReturnsCorrectSlots()
        {
            var dayStart = DateTime.Now.AddHours(1);
            var dayEnd = dayStart.AddHours(5);

            _bookingSystem.BookTimeSlot(dayStart.AddMinutes(30), dayStart.AddMinutes(60));
            _bookingSystem.BookTimeSlot(dayStart.AddMinutes(90), dayStart.AddMinutes(120));

            var availableSlots = _bookingSystem.GetAvailableTimeSlots(dayStart, dayEnd);

            Assert.NotNull(availableSlots);
            Assert.DoesNotContain(dayStart.AddMinutes(30), availableSlots);
            Assert.DoesNotContain(dayStart.AddMinutes(90), availableSlots);
        }
    }
}
