using NUnit.Framework;
using System;

namespace BankSafe.Tests
{
    [TestFixture]
    public class BankVaultTests
    {
        private const string DEF_ITEM_OWNER = "Owner";
        private const string DEF_ITEM_ID = "Item Id";
        private const string DEF_CELL_ID = "A1";

        private Item item;
        private BankVault bankVault;
        private string addItemString;

        [SetUp]
        public void Setup()
        {
            item = new Item(DEF_ITEM_OWNER, DEF_ITEM_ID);
            bankVault = new BankVault();
            addItemString = bankVault.AddItem(DEF_CELL_ID, item);
        }

        [Test]
        public void AddItem_AddsItemToTheDict()
        {
            string expectedString = $"Item:{item.ItemId} saved successfully!";
            Assert.AreSame(bankVault.VaultCells[DEF_CELL_ID], item);
            Assert.AreEqual(expectedString, addItemString);
        }

        [Test]
        public void AddItem_ThrowsForNonExistingCell()
        {
            Assert.Throws<ArgumentException>(() => bankVault.AddItem("Q15", new Item("Token owner", "token Id")));
        }

        [Test]
        public void AddItem_ThrowsIfCellIsAlreadyTaken()
        {
            Assert.Throws<ArgumentException>(() => bankVault.AddItem(DEF_CELL_ID, new Item("Token owner", "token Id")));
        }

        [Test]
        public void AddItem_ThrowsIfItemIsAlreadyInACell()
        {
            Assert.Throws<InvalidOperationException>(() => bankVault.AddItem("A2", item));
        }
        
        [Test]
        public void RemoveItem_RemovesTheItemFromTheDict()
        {
            string expectedString = $"Remove item:{item.ItemId} successfully!";
            string actualString = bankVault.RemoveItem(DEF_CELL_ID, item);
            Assert.AreEqual(expectedString, actualString);
            Assert.AreEqual(bankVault.VaultCells[DEF_CELL_ID], null);
        }

        [Test]
        public void RemoveItem_ThrowsForNonExistentCell()
        {
            Assert.Throws<ArgumentException>(() => bankVault.RemoveItem("Q15", item));
        }

        [Test]
        public void RemoveItem_ThrowsForMissingItemInThatCell()
        {
            Assert.Throws<ArgumentException>(() => bankVault.RemoveItem(DEF_CELL_ID, new Item("Token owner", "token Id")));
        }
    }
}