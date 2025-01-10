using System.Text.RegularExpressions;

public static class StringProcessor
{
    public static string ToLowerCase(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            throw new ArgumentNullException(nameof(input), "Input cannot be null or whitespace.");
        }

        return input.ToLower();
    }

    public static string Sanitize(string input)
    {
        if (input == null)
        {
            throw new ArgumentNullException(nameof(input), "Input cannot be null.");
        }

        // If the input is empty, return it as-is
        if (input == string.Empty)
        {
            return input;
        }

        return Regex.Replace(input, "[^a-zA-Z0-9]", string.Empty);
    }

    public static bool AreEqual(string input1, string input2)
    {
        // Handle cases where both inputs are null
        if (input1 == null && input2 == null)
        {
            return true;
        }

        // If only one of the inputs is null, they are not equal
        if (input1 == null || input2 == null)
        {
            return false;
        }

        // Sanitize and compare the lowercased strings
        string sanitized1 = Sanitize(input1).ToLower();
        string sanitized2 = Sanitize(input2).ToLower();

        return sanitized1 == sanitized2;
    }
}

