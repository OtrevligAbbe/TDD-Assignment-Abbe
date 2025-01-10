using System;
using System.Collections.Generic;
using System.Linq;

public class InventoryManager
{
    // Dictionary to store inventory items and their quantities
    private readonly Dictionary<string, int> _inventory = new Dictionary<string, int>();

    // Adds an item to the inventory or updates the quantity if it already exists
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

    // Removes a specified quantity of an item from the inventory
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

        // Decrease the quantity of the item; leave it in inventory if the quantity is zero
        _inventory[itemName] -= quantity;
    }

    // Returns a list of items that are out of stock (quantity == 0)
    public List<string> GetOutOfStockItems()
    {
        return _inventory.Where(item => item.Value == 0)
                         .Select(item => item.Key)
                         .ToList();
    }

    // Retrieves the quantity of a specific item, or 0 if the item does not exist
    public int GetItemQuantity(string itemName)
    {
        if (string.IsNullOrWhiteSpace(itemName))
        {
            throw new ArgumentException("Item name cannot be null or empty.");
        }

        return _inventory.ContainsKey(itemName) ? _inventory[itemName] : 0;
    }
}
