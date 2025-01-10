using Xunit;
using TDD_Assignment_Abbe.Classes;

namespace TDD_Assignment_Abbe.Test
{

    public class BookingSystemTests
    {
        [Fact]
        public void BookTimeSlot_ReturnsTrue_WhenNoConflicts()
        {
            // Arrange
            var bookingSystem = new BookingSystem();

            // Act
            bool result = bookingSystem.BookTimeSlot(new DateTime(2025, 01, 10, 10, 0, 0), new DateTime(2025, 01, 10, 11, 0, 0));

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void BookTimeSlot_ReturnsFalse_WhenOverlapOccurs()
        {
            // Arrange
            var bookingSystem = new BookingSystem();
            bookingSystem.BookTimeSlot(new DateTime(2025, 01, 10, 10, 0, 0), new DateTime(2025, 01, 10, 11, 0, 0));

            // Act
            bool result = bookingSystem.BookTimeSlot(new DateTime(2025, 01, 10, 10, 30, 0), new DateTime(2025, 01, 10, 11, 30, 0));

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void GetAvailableTimeSlots_ReturnsCorrectGaps()
        {
            // Arrange
            var bookingSystem = new BookingSystem();
            bookingSystem.BookTimeSlot(new DateTime(2025, 01, 10, 09, 0, 0), new DateTime(2025, 01, 10, 10, 0, 0));
            bookingSystem.BookTimeSlot(new DateTime(2025, 01, 10, 11, 0, 0), new DateTime(2025, 01, 10, 12, 0, 0));

            // Act
            var availableSlots = bookingSystem.GetAvailableTimeSlots(new DateTime(2025, 01, 10, 08, 0, 0), new DateTime(2025, 01, 10, 13, 0, 0));

            // Assert
            Assert.Contains(new DateTime(2025, 01, 10, 10, 0, 0), availableSlots);
            Assert.Contains(new DateTime(2025, 01, 10, 12, 0, 0), availableSlots);
        }

        [Fact]
        public void BookTimeSlot_ThrowsArgumentException_WhenStartTimeIsAfterEndTime()
        {
            // Arrange
            var bookingSystem = new BookingSystem();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => bookingSystem.BookTimeSlot(new DateTime(2025, 01, 10, 11, 0, 0), new DateTime(2025, 01, 10, 10, 0, 0)));
        }
    }
}