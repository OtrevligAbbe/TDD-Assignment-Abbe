﻿using System;
using TDD_Assignment_Abbe.Classes;
using Xunit;

namespace TDD_Assignment_Abbe.Test
{

    public class CalculatorTests
    {
        [Fact]
        public void Add_ReturnsCorrectSum()
        {
            // Arrange
            float a = 5.5f;
            float b = 4.5f;

            // Act
            float result = Calculator.Add(a, b);

            // Assert
            Assert.Equal(10.0f, result);
        }

        [Fact]
        public void Subtract_ReturnsCorrectDifference()
        {
            // Arrange
            float a = 10.0f;
            float b = 4.5f;

            // Act
            float result = Calculator.Subtract(a, b);

            // Assert
            Assert.Equal(5.5f, result);
        }

        [Fact]
        public void Multiply_ReturnsCorrectProduct()
        {
            // Arrange
            float a = 2.5f;
            float b = 4.0f;

            // Act
            float result = Calculator.Multiply(a, b);

            // Assert
            Assert.Equal(10.0f, result);
        }

        [Fact]
        public void Divide_ReturnsCorrectQuotient()
        {
            // Arrange
            float a = 9.0f;
            float b = 3.0f;

            // Act
            float result = Calculator.Divide(a, b);

            // Assert
            Assert.Equal(3.0f, result);
        }

        [Fact]
        public void Divide_ThrowsDivideByZeroException_WhenDividingByZero()
        {
            // Arrange
            float a = 10.0f;
            float b = 0.0f;

            // Act & Assert
            Assert.Throws<DivideByZeroException>(() => Calculator.Divide(a, b));
        }

        [Fact]
        public void Add_HandlesNegativeNumbersCorrectly()
        {
            // Arrange
            float a = -5.0f;
            float b = -3.0f;

            // Act
            float result = Calculator.Add(a, b);

            // Assert
            Assert.Equal(-8.0f, result);
        }

        [Fact]
        public void Multiply_HandlesLargeNumbersCorrectly()
        {
            // Arrange
            float a = 1_000_000.0f;
            float b = 2.0f;

            // Act
            float result = Calculator.Multiply(a, b);

            // Assert
            Assert.Equal(2_000_000.0f, result);
        }

        [Fact]
        public void Divide_HandlesDecimalValuesCorrectly()
        {
            // Arrange
            float a = 5.5f;
            float b = 2.0f;

            // Act
            float result = Calculator.Divide(a, b);

            // Assert
            Assert.Equal(2.75f, result, 2); // Tillåt två decimaler i precision
        }
    }
}