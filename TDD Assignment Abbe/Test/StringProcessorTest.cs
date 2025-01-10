using System;
using Xunit;
using TDD_Assignment_Abbe.Classes;

namespace TDD_Assignment_Abbe
{
    public class StringProcessorTest
    {
        // Tests that ToLowerCase converts a string to lowercase
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

        // Tests that ToLowerCase throws an exception when the input is null
        [Fact]
        public void ToLowerCase_ThrowsArgumentNullException_WhenInputIsNull()
        {
            // Arrange
            string input = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => StringProcessor.ToLowerCase(input));
        }

        // Tests that Sanitize removes special characters from a string
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

        // Tests that Sanitize returns an empty string when the input is empty
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

        // Tests that Sanitize throws an exception when the input is null
        [Fact]
        public void Sanitize_ThrowsArgumentNullException_WhenInputIsNull()
        {
            // Arrange
            string input = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => StringProcessor.Sanitize(input));
        }

        // Tests that AreEqual returns true when both strings are null
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

        // Tests that AreEqual returns true when both strings are empty
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

        // Tests that AreEqual returns false when one string is null
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

        // Tests that AreEqual returns false when the strings do not match
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

        // Tests that AreEqual returns true when the strings match after sanitization and conversion to lowercase
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
