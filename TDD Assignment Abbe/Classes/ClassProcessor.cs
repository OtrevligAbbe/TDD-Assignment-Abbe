using System;
using System.Text.RegularExpressions;

    public class StringProcessor
    {
        // Metod som konverterar en sträng till gemener
        public string ToLowerCase(string input)
        {
            return input.ToLower();
        }

        // Metod som tar bort icke-alfanumeriska tecken
        public string Sanitize(string input)
        {
            return Regex.Replace(input, @"[^a-zA-Z0-9]", "");
        }

        // Metod som jämför två strängar efter sanering och konvertering till gemener
        public bool AreEqual(string input1, string input2)
        {
            string sanitizedInput1 = ToLowerCase(Sanitize(input1));
            string sanitizedInput2 = ToLowerCase(Sanitize(input2));

            return sanitizedInput1 == sanitizedInput2;
        }
    }