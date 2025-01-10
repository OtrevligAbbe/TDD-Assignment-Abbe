using System;
using System.Collections.Generic;
using System.Reflection;

public class ObjectValidator
{
    // Checks if the given object is null
    public bool IsNull(object obj)
    {
        return obj == null;
    }

    // Returns a list of property names that are null in the specified object
    public List<string> GetNullProperties(object obj)
    {
        if (obj == null)
        {
            throw new ArgumentNullException(nameof(obj), "The object cannot be null.");
        }

        List<string> nullProperties = new List<string>();

        // Iterate through all public instance properties of the object
        foreach (PropertyInfo property in obj.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
        {
            // Add property name to the list if its value is null
            if (property.GetValue(obj) == null)
            {
                nullProperties.Add(property.Name);
            }
        }

        return nullProperties;
    }
}

