using System;
using System.Linq;
using Xunit;
using TDD_Assignment_Abbe.Classes;

namespace TDD_Assignment_Abbe.Test
{
    // Tests the real BookingSystem
    public class BookingSystemTest
    {
        [Fact]
        public void BookTimeSlot_ShouldReturnTrue_WhenSlotIsFree()
        {
            var system = new BookingSystem();
            var start = new DateTime(2025, 1, 21, 10, 0, 0);
            var end = new DateTime(2025, 1, 21, 11, 0, 0);

            var result = system.BookTimeSlot(start, end);
            Assert.True(result);
        }

        [Fact]
        public void BookTimeSlot_ShouldReturnFalse_WhenOverlaps()
        {
            var system = new BookingSystem();
            system.BookTimeSlot(
                new DateTime(2025, 1, 21, 10, 0, 0),
                new DateTime(2025, 1, 21, 11, 0, 0)
            );

            var result = system.BookTimeSlot(
                new DateTime(2025, 1, 21, 10, 30, 0),
                new DateTime(2025, 1, 21, 10, 45, 0)
            );

            Assert.False(result);
        }

        [Fact]
        public void GetAvailableTimeSlots_ShouldExcludeBooked()
        {
            var system = new BookingSystem();
            var dayStart = new DateTime(2025, 1, 21, 8, 0, 0);
            var dayEnd = new DateTime(2025, 1, 21, 12, 0, 0);

            system.BookTimeSlot(
                new DateTime(2025, 1, 21, 9, 0, 0),
                new DateTime(2025, 1, 21, 10, 0, 0)
            );
            system.BookTimeSlot(
                new DateTime(2025, 1, 21, 10, 30, 0),
                new DateTime(2025, 1, 21, 11, 0, 0)
            );

            var slots = system.GetAvailableTimeSlots(dayStart, dayEnd).ToList();

            Assert.Contains(slots, s => s.Start == dayStart && s.End == new DateTime(2025, 1, 21, 9, 0, 0));
            Assert.Contains(slots, s => s.Start == new DateTime(2025, 1, 21, 10, 0, 0) && s.End == new DateTime(2025, 1, 21, 10, 30, 0));
            Assert.Contains(slots, s => s.Start == new DateTime(2025, 1, 21, 11, 0, 0) && s.End == dayEnd);
        }
    }
}

