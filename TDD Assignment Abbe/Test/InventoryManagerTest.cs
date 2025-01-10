using System;
using System.Collections.Generic;
using Xunit;
using TDD_Assignment_Abbe.Classes;

namespace TDD_Assignment_Abbe.Test
{

    public class InventoryManagerTests
    {
        [Fact]
        public void AddItem_IncreasesQuantityForExistingItem()
        {
            // Arrange
            var inventoryManager = new InventoryManager();
            inventoryManager.AddItem("Apple", 5);

            // Act
            inventoryManager.AddItem("Apple", 3);

            // Assert
            Assert.Equal(8, inventoryManager.GetItemQuantity("Apple"));
        }

        [Fact]
        public void AddItem_ThrowsArgumentException_WhenItemNameIsNullOrEmpty()
        {
            // Arrange
            var inventoryManager = new InventoryManager();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => inventoryManager.AddItem(null, 5));
            Assert.Throws<ArgumentException>(() => inventoryManager.AddItem("", 5));
        }

        [Fact]
        public void AddItem_ThrowsArgumentException_WhenQuantityIsZeroOrNegative()
        {
            // Arrange
            var inventoryManager = new InventoryManager();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => inventoryManager.AddItem("Apple", 0));
            Assert.Throws<ArgumentException>(() => inventoryManager.AddItem("Apple", -1));
        }

        [Fact]
        public void RemoveItem_DecreasesQuantityForExistingItem()
        {
            // Arrange
            var inventoryManager = new InventoryManager();
            inventoryManager.AddItem("Apple", 5);

            // Act
            inventoryManager.RemoveItem("Apple", 3);

            // Assert
            Assert.Equal(2, inventoryManager.GetItemQuantity("Apple"));
        }

        [Fact]
        public void RemoveItem_ThrowsInvalidOperationException_WhenQuantityExceedsStock()
        {
            // Arrange
            var inventoryManager = new InventoryManager();
            inventoryManager.AddItem("Widget", 5);

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => inventoryManager.RemoveItem("Widget", 10));
        }


        [Fact]
        public void RemoveItem_ThrowsArgumentException_WhenItemNameIsNullOrEmpty()
        {
            // Arrange
            var inventoryManager = new InventoryManager();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => inventoryManager.RemoveItem(null, 5));
            Assert.Throws<ArgumentException>(() => inventoryManager.RemoveItem("", 5));
        }


        [Fact]
        public void RemoveItem_ThrowsArgumentException_WhenQuantityIsNegative()
        {
            // Arrange
            var inventoryManager = new InventoryManager();

            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() =>
                inventoryManager.RemoveItem("Widget", -5));

            Assert.Equal("Quantity must be greater than zero.", ex.Message);
        }


        [Fact]
        public void GetOutOfStockItems_ReturnsCorrectList()
        {
            // Arrange
            var inventoryManager = new InventoryManager();
            inventoryManager.AddItem("Widget", 10);
            inventoryManager.AddItem("Gadget", 5);

            inventoryManager.RemoveItem("Widget", 10); // Make "Widget" out of stock

            // Act
            var outOfStockItems = inventoryManager.GetOutOfStockItems();

            // Assert
            Assert.Contains("Widget", outOfStockItems); // "Widget" should be in the list
            Assert.DoesNotContain("Gadget", outOfStockItems); // "Gadget" should not be in the list
        }




        [Fact]
        public void GetOutOfStockItems_ReturnsEmptyList_WhenNoItemsAreOutOfStock()
        {
            // Arrange
            var inventoryManager = new InventoryManager();
            inventoryManager.AddItem("Apple", 5);
            inventoryManager.AddItem("Banana", 3);

            // Act
            var outOfStockItems = inventoryManager.GetOutOfStockItems();

            // Assert
            Assert.Empty(outOfStockItems);
        }

        [Fact]
        public void GetOutOfStockItems_ReturnsEmptyList_WhenInventoryIsEmpty()
        {
            // Arrange
            var inventoryManager = new InventoryManager();

            // Act
            var outOfStockItems = inventoryManager.GetOutOfStockItems();

            // Assert
            Assert.Empty(outOfStockItems);
        }
    }
}