using System;
using System.Collections.Generic;

namespace TDD_Assignment_Abbe.Interfaces
{
    // Interface for a booking system
    public interface IBookingSystem
    {
        // Attempts to book a time slot
        bool BookTimeSlot(DateTime startTime, DateTime endTime);

        // Gets available slots in a date range
        IEnumerable<(DateTime Start, DateTime End)> GetAvailableTimeSlots(DateTime dayStart, DateTime dayEnd);
    }
}

