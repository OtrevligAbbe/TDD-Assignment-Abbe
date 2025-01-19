using System;
using System.Collections.Generic;
using NSubstitute;
using Xunit;
using TDD_Assignment_Abbe.Facade;
using TDD_Assignment_Abbe.Interfaces;

namespace TDD_Assignment_Abbe.Test
{
    // Tests BookingSystemFacade with NSubstitute
    public class BookingSystemFacadeTest
    {
        [Fact]
        public void BookTimeSlot_ShouldCallIBookingSystem()
        {
            var mockSystem = Substitute.For<IBookingSystem>();
            var facade = new BookingSystemFacade(mockSystem);

            var start = new DateTime(2025, 1, 21, 10, 0, 0);
            var end = new DateTime(2025, 1, 21, 11, 0, 0);

            mockSystem.BookTimeSlot(start, end).Returns(true);

            var result = facade.BookTimeSlot(start, end);
            Assert.True(result);

            mockSystem.Received(1).BookTimeSlot(start, end);
        }

        [Fact]
        public void GetAvailableTimeSlots_ShouldReturnMockedSlots()
        {
            var mockSystem = Substitute.For<IBookingSystem>();
            var facade = new BookingSystemFacade(mockSystem);

            var dayStart = new DateTime(2025, 1, 21, 8, 0, 0);
            var dayEnd = new DateTime(2025, 1, 21, 12, 0, 0);

            var expected = new List<(DateTime Start, DateTime End)>
            {
                (dayStart, new DateTime(2025, 1, 21, 9, 0, 0))
            };

            mockSystem.GetAvailableTimeSlots(dayStart, dayEnd).Returns(expected);

            var slots = facade.GetAvailableTimeSlots(dayStart, dayEnd);
            Assert.Equal(expected, slots);
        }

        [Fact]
        public void BookTimeSlot_ShouldThrow_WhenSystemThrows()
        {
            var mockSystem = Substitute.For<IBookingSystem>();
            var facade = new BookingSystemFacade(mockSystem);

            mockSystem
                .When(x => x.BookTimeSlot(Arg.Any<DateTime>(), Arg.Any<DateTime>()))
                .Do(_ => throw new ArgumentException("Invalid range."));

            Assert.Throws<ArgumentException>(() =>
                facade.BookTimeSlot(DateTime.Now, DateTime.Now));
        }
    }
}

