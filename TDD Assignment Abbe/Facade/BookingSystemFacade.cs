using System;
using System.Collections.Generic;
using TDD_Assignment_Abbe.Classes;

namespace TDD_Assignment_Abbe.Facade
{
    public class BookingSystemFacade
    {
        private readonly BookingSystem _bookingSystem;

        // Initializes the facade with a BookingSystem instance
        public BookingSystemFacade(BookingSystem bookingSystem)
        {
            _bookingSystem = bookingSystem ?? throw new ArgumentNullException(nameof(bookingSystem));
        }

        // Books a time slot using the underlying BookingSystem
        public bool BookSlot(DateTime startTime, DateTime endTime)
        {
            if (startTime >= endTime)
                throw new ArgumentException("Start time must be earlier than end time.");

            return _bookingSystem.BookTimeSlot(startTime, endTime);
        }

        // Retrieves available time slots within the specified range
        public List<DateTime> GetAvailableTimeSlots(DateTime dayStart, DateTime dayEnd)
        {
            return _bookingSystem.GetAvailableTimeSlots(dayStart, dayEnd);
        }
    }
}


