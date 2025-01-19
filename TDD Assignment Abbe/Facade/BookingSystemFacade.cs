using System;
using System.Collections.Generic;
using TDD_Assignment_Abbe.Interfaces;

namespace TDD_Assignment_Abbe.Facade
{
    // Facade for IBookingSystem
    public class BookingSystemFacade
    {
        private readonly IBookingSystem _bookingSystem;

        // Injects a booking system
        public BookingSystemFacade(IBookingSystem bookingSystem)
        {
            _bookingSystem = bookingSystem ?? throw new ArgumentNullException(nameof(bookingSystem));
        }

        // Books a time slot
        public bool BookTimeSlot(DateTime startTime, DateTime endTime)
        {
            return _bookingSystem.BookTimeSlot(startTime, endTime);
        }

        // Gets available slots in a range
        public IEnumerable<(DateTime Start, DateTime End)> GetAvailableTimeSlots(DateTime dayStart, DateTime dayEnd)
        {
            return _bookingSystem.GetAvailableTimeSlots(dayStart, dayEnd);
        }
    }
}


