using System;
using Xunit;
using TDD_Assignment_Abbe.Classes;

namespace TDD_Assignment_Abbe
{
    public class StringProcessorTest
    {
        [Fact]
        public void ToLowerCase_ConvertsStringToLowerCase()
        {
            // Arrange
            string input = "Hello";
            string expected = "hello";

            // Act
            string result = StringProcessor.ToLowerCase(input);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void ToLowerCase_ThrowsArgumentNullException_WhenInputIsNull()
        {
            // Arrange
            string input = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => StringProcessor.ToLowerCase(input));
        }

        [Fact]
        public void Sanitize_RemovesSpecialCharacters()
        {
            // Arrange
            string input = "Hello@World!";
            string expected = "HelloWorld";

            // Act
            string result = StringProcessor.Sanitize(input);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Sanitize_ReturnsEmpty_WhenInputIsEmpty()
        {
            // Arrange
            string input = "";
            string expected = "";

            // Act
            string result = StringProcessor.Sanitize(input);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Sanitize_ThrowsArgumentNullException_WhenInputIsNull()
        {
            // Arrange
            string input = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => StringProcessor.Sanitize(input));
        }

        [Fact]
        public void AreEqual_ReturnsTrue_WhenBothStringsAreNull()
        {
            // Arrange
            string str1 = null;
            string str2 = null;

            // Act
            bool result = StringProcessor.AreEqual(str1, str2);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void AreEqual_ReturnsTrue_WhenBothStringsAreEmpty()
        {
            // Arrange
            string str1 = "";
            string str2 = "";

            // Act
            bool result = StringProcessor.AreEqual(str1, str2);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void AreEqual_ReturnsFalse_WhenOneStringIsNull()
        {
            // Arrange
            string str1 = null;
            string str2 = "hello";

            // Act
            bool result = StringProcessor.AreEqual(str1, str2);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void AreEqual_ReturnsFalse_WhenStringsDoNotMatch()
        {
            // Arrange
            string str1 = "Hello";
            string str2 = "World";

            // Act
            bool result = StringProcessor.AreEqual(str1, str2);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void AreEqual_ReturnsTrue_WhenStringsMatchAfterSanitizationAndLowerCase()
        {
            // Arrange
            string str1 = "Hello@World!";
            string str2 = "hello world";

            // Act
            bool result = StringProcessor.AreEqual(str1, str2);

            // Assert
            Assert.True(result);
        }
    }
}