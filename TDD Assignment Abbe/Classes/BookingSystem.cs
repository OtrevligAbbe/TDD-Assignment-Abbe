using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

public class BookingSystem
{
    public List<Booking> Bookings { get; private set; } = new List<Booking>();

    public bool BookTimeSlot(DateTime startTime, DateTime endTime)
    {
        // Validate input
        if (startTime >= endTime)
        {
            throw new ArgumentException("Start time must be earlier than end time.");
        }

        // Check for conflicts
        foreach (var booking in Bookings)
        {
            if (startTime < booking.EndTime && endTime > booking.StartTime)
            {
                return false; // Overlap detected
            }
        }

        // Add new booking
        Bookings.Add(new Booking { StartTime = startTime, EndTime = endTime });
        return true;
    }

    public List<DateTime> GetAvailableTimeSlots(DateTime dayStart, DateTime dayEnd)
    {
        var availableSlots = new List<DateTime>();

        if (Bookings.Count == 0)
        {
            availableSlots.Add(dayStart);
            availableSlots.Add(dayEnd);
            return availableSlots;
        }

        // Sort bookings by start time
        var sortedBookings = Bookings.OrderBy(b => b.StartTime).ToList();

        // Add gaps between bookings
        DateTime currentTime = dayStart;

        foreach (var booking in sortedBookings)
        {
            if (currentTime < booking.StartTime)
            {
                availableSlots.Add(currentTime);
                availableSlots.Add(booking.StartTime);
            }
            currentTime = booking.EndTime;
        }

        // Add remaining time after last booking
        if (currentTime < dayEnd)
        {
            availableSlots.Add(currentTime);
            availableSlots.Add(dayEnd);
        }

        return availableSlots;
    }
}

public class Booking
{
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
}

