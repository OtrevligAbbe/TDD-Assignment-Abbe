using System;
using System.Collections.Generic;
using TDD_Assignment_Abbe.Classes;
using TDD_Assignment_Abbe.Facade;
using Xunit;

namespace TDD_Assignment_Abbe.Test.Facade
{
    public class BookingSystemFacadeTest
    {
        private readonly BookingSystemFacade _facade;
        private readonly BookingSystem _bookingSystem;

        public BookingSystemFacadeTest()
        {
            _bookingSystem = new BookingSystem();
            _facade = new BookingSystemFacade(_bookingSystem);
        }

        [Fact]
        public void BookSlot_ReturnsTrue_WhenSlotIsAvailable()
        {
            var result = _facade.BookSlot(DateTime.Now.AddHours(1), DateTime.Now.AddHours(2));
            Assert.True(result);
        }

        [Fact]
        public void BookSlot_ThrowsArgumentException_WhenStartTimeIsAfterEndTime()
        {
            Assert.Throws<ArgumentException>(() => _facade.BookSlot(DateTime.Now.AddHours(2), DateTime.Now.AddHours(1)));
        }

        [Fact]
        public void GetAvailableTimeSlots_ReturnsCorrectTimeSlots()
        {
            var dayStart = DateTime.Now.AddHours(1);
            var dayEnd = dayStart.AddHours(5);

            _facade.BookSlot(dayStart.AddMinutes(30), dayStart.AddMinutes(60));
            _facade.BookSlot(dayStart.AddMinutes(90), dayStart.AddMinutes(120));

            var availableSlots = _facade.GetAvailableTimeSlots(dayStart, dayEnd);

            Assert.NotNull(availableSlots);
            Assert.DoesNotContain(dayStart.AddMinutes(30), availableSlots);
            Assert.DoesNotContain(dayStart.AddMinutes(90), availableSlots);
        }
    }
}

