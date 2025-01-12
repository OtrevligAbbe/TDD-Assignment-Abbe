using System;
using System.Collections.Generic;
using TDD_Assignment_Abbe.Classes;

namespace TDD_Assignment_Abbe.Facade
{
    public class BookingSystemFacade
    {
        private readonly BookingSystem _bookingSystem;

        // Initializes the facade with a BookingSystem instance.
        public BookingSystemFacade(BookingSystem bookingSystem)
        {
            _bookingSystem = bookingSystem ?? throw new ArgumentNullException(nameof(bookingSystem));
        }

        // Books a time slot using the underlying BookingSystem.
        public bool BookTimeSlot(DateTime startTime, DateTime endTime)
        {
            return _bookingSystem.BookTimeSlot(startTime, endTime);
        }

        // Retrieves available time slots within the specified range.
        public IEnumerable<(DateTime Start, DateTime End)> GetAvailableTimeSlots(DateTime dayStart, DateTime dayEnd)
        {
            return _bookingSystem.GetAvailableTimeSlots(dayStart, dayEnd);
        }
    }
}


