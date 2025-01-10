using System;
using System.Collections.Generic;
using System.Linq;

public class InventoryManager
{
    private readonly Dictionary<string, int> _inventory = new Dictionary<string, int>();

    public void AddItem(string itemName, int quantity)
    {
        if (string.IsNullOrWhiteSpace(itemName))
        {
            throw new ArgumentException("Item name cannot be null or empty.");
        }

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

    public void RemoveItem(string itemName, int quantity)
    {
        if (string.IsNullOrWhiteSpace(itemName))
        {
            throw new ArgumentException("Item name cannot be null or empty.");
        }

        if (quantity <= 0)
        {
            throw new ArgumentException("Quantity must be greater than zero.");
        }

        if (!_inventory.ContainsKey(itemName))
        {
            throw new InvalidOperationException("Item does not exist in inventory.");
        }

        if (_inventory[itemName] < quantity)
        {
            throw new InvalidOperationException("Not enough items in inventory.");
        }

        // Reduce the quantity but leave the item in the inventory if it reaches 0
        _inventory[itemName] -= quantity;
    }



    public List<string> GetOutOfStockItems()
    {
        // Returnera endast objekt som inte finns i lager (där Value == 0)
        return _inventory.Where(item => item.Value == 0)
                         .Select(item => item.Key)
                         .ToList();
    }



    public int GetItemQuantity(string itemName)
    {
        if (string.IsNullOrWhiteSpace(itemName))
        {
            throw new ArgumentException("Item name cannot be null or empty.");
        }

        return _inventory.ContainsKey(itemName) ? _inventory[itemName] : 0;
    }
}



