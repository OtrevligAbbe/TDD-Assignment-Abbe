using System;
using System.Collections.Generic;
using System.Linq;

public class InventoryManager
{
    // Dictionary för att hålla reda på lagerstatus
    private readonly Dictionary<string, int> _inventory = new Dictionary<string, int>();

    // Lägg till ett objekt till lagret
    public void AddItem(string itemName, int quantity)
    {
        if (quantity <= 0)
        {
            throw new ArgumentException("Quantity must be greater than zero.");
        }

        if (_inventory.ContainsKey(itemName))
        {
            _inventory[itemName] += quantity;
        }
        else
        {
            _inventory[itemName] = quantity;
        }
    }

    // Ta bort ett objekt från lagret
    public void RemoveItem(string itemName, int quantity)
    {
        if (!_inventory.ContainsKey(itemName))
        {
            throw new KeyNotFoundException($"Item '{itemName}' not found in inventory.");
        }

        if (quantity <= 0)
        {
            throw new ArgumentException("Quantity must be greater than zero.");
        }

        if (_inventory[itemName] < quantity)
        {
            throw new InvalidOperationException($"Not enough '{itemName}' in stock to remove {quantity}.");
        }

        _inventory[itemName] -= quantity;

        // Ta bort objektet från inventeringen om kvantiteten blir 0
        if (_inventory[itemName] == 0)
        {
            _inventory.Remove(itemName);
        }
    }
}
    // Hämta en lista på varor som inte finns på lager (quantity = 0)


