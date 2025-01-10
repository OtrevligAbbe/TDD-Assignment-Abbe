using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class NullControl
{
    // Metod för att kontrollera om ett objekt är null
    public bool IsNull(object obj)
    {
        return obj == null;
    }

    // Metod för att hämta en lista över properties som är null
    public List<string> GetNullProperties(object obj)
    {
        if (obj == null)
        {
            throw new ArgumentNullException(nameof(obj), "The object cannot be null.");
        }

        List<string> nullProperties = new List<string>();

        // Iterera över alla publika properties i objektet
        foreach (PropertyInfo property in obj.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
        {
            // Kontrollera om property-värdet är null
            if (property.GetValue(obj) == null)
            {
                nullProperties.Add(property.Name);
            }
        }

        return nullProperties;
    }
}
