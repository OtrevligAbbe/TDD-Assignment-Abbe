using System;
using System.Collections.Generic;
using System.Linq;

namespace TDD_Assignment_Abbe.Classes
{
    public class BookingSystem
    {
        private readonly List<Booking> bookings = new List<Booking>();

        // Books a time slot if it's available.
        public virtual bool BookTimeSlot(DateTime startTime, DateTime endTime)
        {
            if (startTime >= endTime)
                throw new ArgumentException("Invalid time range.");

            // Check for overlapping bookings
            if (bookings.Any(b => b.Start < endTime && b.End > startTime))
                return false;

            // Add the new booking
            bookings.Add(new Booking { Start = startTime, End = endTime });
            return true;
        }

        // Returns available time slots in the given range.
        public virtual IEnumerable<(DateTime Start, DateTime End)> GetAvailableTimeSlots(DateTime dayStart, DateTime dayEnd)
        {
            if (dayStart >= dayEnd)
                throw new ArgumentException("Invalid day range.");

            var availableSlots = new List<(DateTime Start, DateTime End)>();
            var currentTime = dayStart;

            // Find gaps between bookings
            foreach (var booking in bookings.OrderBy(b => b.Start))
            {
                if (booking.Start > currentTime)
                    availableSlots.Add((currentTime, booking.Start));
                currentTime = Math.Max(currentTime.Ticks, booking.End.Ticks) == booking.End.Ticks ? booking.End : currentTime;
            }

            // Add remaining time after last booking
            if (currentTime < dayEnd)
                availableSlots.Add((currentTime, dayEnd));

            return availableSlots;
        }

        private class Booking
        {
            public DateTime Start { get; set; }
            public DateTime End { get; set; }
        }
    }
}


