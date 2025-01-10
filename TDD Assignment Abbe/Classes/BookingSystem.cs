using System;
using System.Collections.Generic;
using System.Linq;

namespace TDD_Assignment_Abbe.Classes
{
    public class BookingSystem
    {
        private readonly List<Booking> _bookings = new List<Booking>();

        public IEnumerable<Booking> Bookings => _bookings.AsReadOnly();

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
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}

