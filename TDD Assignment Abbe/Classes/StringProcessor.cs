using System.Text.RegularExpressions;

public static class StringProcessor
{
    // Converts the input string to lowercase
    public static string ToLowerCase(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            throw new ArgumentNullException(nameof(input), "Input cannot be null or whitespace.");
        }

        return input.ToLower();
    }

    // Removes all non-alphanumeric characters from the input string
    public static string Sanitize(string input)
    {
        if (input == null)
        {
            throw new ArgumentNullException(nameof(input), "Input cannot be null.");
        }

        // Return the input as-is if it's an empty string
        if (input == string.Empty)
        {
            return input;
        }

        return Regex.Replace(input, "[^a-zA-Z0-9]", string.Empty);
    }

    // Compares two strings for equality after sanitizing and converting to lowercase
    public static bool AreEqual(string input1, string input2)
    {
        // Return true if both inputs are null
        if (input1 == null && input2 == null)
        {
            return true;
        }

        // Return false if only one input is null
        if (input1 == null || input2 == null)
        {
            return false;
        }

        // Sanitize and compare the lowercased versions of the strings
        string sanitized1 = Sanitize(input1).ToLower();
        string sanitized2 = Sanitize(input2).ToLower();

        return sanitized1 == sanitized2;
    }
}


