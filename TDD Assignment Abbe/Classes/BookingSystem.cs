using System;
using System.Collections.Generic;
using System.Linq;

namespace TDD_Assignment_Abbe.Classes
{
    public class BookingSystem
    {
        // Stores a list of bookings
        private readonly List<Booking> _bookings = new List<Booking>();

        // Provides a read-only view of the bookings
        public IEnumerable<Booking> Bookings => _bookings.AsReadOnly();

        // Books a time slot if it doesn't overlap with existing bookings
        public bool BookTimeSlot(DateTime startTime, DateTime endTime)
        {
            if (startTime >= endTime)
                throw new ArgumentException("Start time must be earlier than end time.");

            if (_bookings.Any(b => b.Start < endTime && b.End > startTime))
            {
                return false; // Time slot is not available
            }

            _bookings.Add(new Booking { Start = startTime, End = endTime });
            return true;
        }

        // Retrieves available time slots within a specified range
        public List<DateTime> GetAvailableTimeSlots(DateTime dayStart, DateTime dayEnd)
        {
            var availableSlots = new List<DateTime>();
            for (var currentTime = dayStart; currentTime < dayEnd; currentTime = currentTime.AddMinutes(30))
            {
                if (!_bookings.Any(booking => booking.Start <= currentTime && booking.End > currentTime))
                {
                    availableSlots.Add(currentTime);
                }
            }
            return availableSlots;
        }
    }

    public class Booking
    {
        // Start time of the booking
        public DateTime Start { get; set; }

        // End time of the booking
        public DateTime End { get; set; }
    }
}

