using System;

namespace TDD_Assignment_Abbe.Classes
{
    public static class Calculator
    {
        // Adds two numbers and returns the result
        public static float Add(float a, float b)
        {
            return a + b;
        }

        // Subtracts the second number from the first and returns the result
        public static float Subtract(float a, float b)
        {
            return a - b;
        }

        // Multiplies two numbers and returns the result
        public static float Multiply(float a, float b)
        {
            return a * b;
        }

        // Divides the first number by the second and returns the result
        // Throws a DivideByZeroException if the second number is zero
        public static float Divide(float a, float b)
        {
            if (b == 0)
            {
                throw new DivideByZeroException("Division by zero is not allowed.");
            }
            return a / b;
        }
    }
}

