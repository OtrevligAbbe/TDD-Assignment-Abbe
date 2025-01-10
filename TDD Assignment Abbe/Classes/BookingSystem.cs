using System;
using System.Collections.Generic;
using System.Linq;

public class Booking
{
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
}

public class BookingSystem
{
    // Lista över aktuella bokningar
    public List<Booking> Bookings { get; } = new List<Booking>();

    // Metod för att boka en tid
    public bool BookTimeSlot(DateTime startTime, DateTime endTime)
    {
        // Kontrollera att sluttiden är efter starttiden
        if (endTime <= startTime)
        {
            throw new ArgumentException("End time must be after start time.");
        }

        // Kontrollera om tiden redan är bokad
        foreach (var booking in Bookings)
        {
            if (startTime < booking.EndTime && endTime > booking.StartTime)
            {
                return false; // Tiden är redan bokad
            }
        }

        // Lägg till bokningen
        Bookings.Add(new Booking { StartTime = startTime, EndTime = endTime });
        return true;
    }

    // Metod för att hämta lediga tidsluckor
    public List<DateTime> GetAvailableTimeSlots(DateTime startOfDay, DateTime endOfDay, TimeSpan slotDuration)
    {
        List<DateTime> availableSlots = new List<DateTime>();

        // Börja med startOfDay och iterera tills endOfDay
        for (DateTime currentTime = startOfDay; currentTime + slotDuration <= endOfDay; currentTime += slotDuration)
        {
            bool isAvailable = true;

            foreach (var booking in Bookings)
            {
                if (currentTime < booking.EndTime && currentTime + slotDuration > booking.StartTime)
                {
                    isAvailable = false;
                    break;
                }
            }

            if (isAvailable)
            {
                availableSlots.Add(currentTime);
            }
        }

        return availableSlots;
    }
}

