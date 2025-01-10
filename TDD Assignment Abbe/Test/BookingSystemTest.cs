using System;
using TDD_Assignment_Abbe.Classes;
using Xunit;

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
        public void BookTimeSlot_ReturnsTrue_WhenSlotIsAvailable()
        {
            var result = _bookingSystem.BookTimeSlot(DateTime.Now.AddHours(1), DateTime.Now.AddHours(2));
            Assert.True(result);
        }

        [Fact]
        public void BookTimeSlot_ReturnsFalse_WhenSlotIsNotAvailable()
        {
            _bookingSystem.BookTimeSlot(DateTime.Now.AddHours(1), DateTime.Now.AddHours(2));
            var result = _bookingSystem.BookTimeSlot(DateTime.Now.AddHours(1).AddMinutes(30), DateTime.Now.AddHours(2));
            Assert.False(result);
        }

        [Fact]
        public void BookTimeSlot_ThrowsArgumentException_WhenStartTimeIsAfterEndTime()
        {
            Assert.Throws<ArgumentException>(() => _bookingSystem.BookTimeSlot(DateTime.Now.AddHours(2), DateTime.Now.AddHours(1)));
        }

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
