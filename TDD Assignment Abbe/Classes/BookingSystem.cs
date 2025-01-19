using System;
using System.Collections.Generic;
using System.Linq;
using TDD_Assignment_Abbe.Interfaces;

namespace TDD_Assignment_Abbe.Classes
{
    // Real booking system implementation
    public class BookingSystem : IBookingSystem
    {
        private readonly List<Booking> _bookings = new List<Booking>();

        // Books a slot if no overlap
        public bool BookTimeSlot(DateTime startTime, DateTime endTime)
        {
            if (startTime >= endTime)
                throw new ArgumentException("Invalid range.");

            bool overlaps = _bookings.Any(b => startTime < b.End && endTime > b.Start);
            if (overlaps) return false;

            _bookings.Add(new Booking { Start = startTime, End = endTime });
            return true;
        }

        // Returns free slots in the range
        public IEnumerable<(DateTime Start, DateTime End)> GetAvailableTimeSlots(DateTime dayStart, DateTime dayEnd)
        {
            var freeSlots = new List<(DateTime Start, DateTime End)>();
            DateTime current = dayStart;

            var sorted = _bookings
                .Where(b => b.End > dayStart && b.Start < dayEnd)
                .OrderBy(b => b.Start)
                .ToList();

            foreach (var b in sorted)
            {
                if (current < b.Start)
                    freeSlots.Add((current, b.Start));
                current = (b.End > current) ? b.End : current;
            }

            if (current < dayEnd)
                freeSlots.Add((current, dayEnd));

            return freeSlots;
        }

        private class Booking
        {
            public DateTime Start { get; set; }
            public DateTime End { get; set; }
        }
    }
}


