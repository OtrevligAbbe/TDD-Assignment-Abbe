using System;
using System.Collections.Generic;
using System.Reflection;

public class ObjectValidator
{
    // Method to check if an object is null
    public bool IsNull(object obj)
    {
        return obj == null;
    }

    // Method to get a list of property names that are null in the given object
    public List<string> GetNullProperties(object obj)
    {
        if (obj == null)
        {
            throw new ArgumentNullException(nameof(obj), "The object cannot be null.");
        }

        List<string> nullProperties = new List<string>();

        // Loop through all public properties of the object
        foreach (PropertyInfo property in obj.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
        {
            // Check if the property value is null
            if (property.GetValue(obj) == null)
            {
                nullProperties.Add(property.Name);
            }
        }

        return nullProperties;
    }
}
