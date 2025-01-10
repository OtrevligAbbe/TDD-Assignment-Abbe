using System;
using System.Collections.Generic;
using Xunit;

namespace TDD_Assignment_Abbe.Test
{
    public class ObjectValidatorTests
    {
        private readonly ObjectValidator _validator = new ObjectValidator();

        [Fact]
        public void IsNull_ReturnsTrue_WhenObjectIsNull()
        {
            // Arrange
            object obj = null;

            // Act
            bool result = _validator.IsNull(obj);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void IsNull_ReturnsFalse_WhenObjectIsNotNull()
        {
            // Arrange
            object obj = new object();

            // Act
            bool result = _validator.IsNull(obj);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void GetNullProperties_ReturnsEmptyList_WhenNoPropertiesAreNull()
        {
            // Arrange
            var testObject = new { Name = "John", Age = 30 };

            // Act
            List<string> result = _validator.GetNullProperties(testObject);

            // Assert
            Assert.Empty(result);
        }

        [Fact]
        public void GetNullProperties_ReturnsListOfNullProperties_WhenSomePropertiesAreNull()
        {
            // Arrange
            var testObject = new { Name = (string)null, Age = 30 };

            // Act
            List<string> result = _validator.GetNullProperties(testObject);

            // Assert
            Assert.Contains("Name", result);
            Assert.DoesNotContain("Age", result);
        }

        [Fact]
        public void GetNullProperties_ThrowsArgumentNullException_WhenObjectIsNull()
        {
            // Arrange
            object obj = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => _validator.GetNullProperties(obj));
        }
    }
}
