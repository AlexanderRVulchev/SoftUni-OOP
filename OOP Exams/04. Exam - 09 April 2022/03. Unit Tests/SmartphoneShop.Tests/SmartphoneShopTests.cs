using NUnit.Framework;
using System;


namespace SmartphoneShop.Tests
{
    [TestFixture]
    public class SmartphoneShopTests
    {
        private const string DEF_PHONE_MODEL = "Test model";
        private const int DEF_PHONE_MAX_CHARGE = 100;
        private const int DEF_SHOP_CAPACITY = 2;

        private Smartphone phone;
        private Shop shop;

        [SetUp]
        public void Setup()
        {
            phone = new Smartphone(DEF_PHONE_MODEL, DEF_PHONE_MAX_CHARGE);
            shop = new Shop(DEF_SHOP_CAPACITY);
        }

        [Test]
        public void Phone_Constructor_CreatesObjectProperly()
        {
            int expectedCurrentCharge = DEF_PHONE_MAX_CHARGE;
            Assert.True(phone.ModelName == DEF_PHONE_MODEL &&
                        phone.MaximumBatteryCharge == DEF_PHONE_MAX_CHARGE &&
                        phone.CurrentBateryCharge == expectedCurrentCharge);
        }

        [Test]
        public void Shop_Constructor_CreatesObjectProperly()
        {
            Assert.True(shop.Capacity == DEF_SHOP_CAPACITY);
        }

        [Test]
        public void Shop_PropertyCapacity_ThrowsForNegativeValue()
        {
            Assert.Throws<ArgumentException>(() => shop = new Shop(-1));
        }

        [Test]
        public void Shop_Add_IncreasesCount()
        {
            shop.Add(phone);
            Assert.AreEqual(shop.Count, 1);
        }

        [Test]
        public void Shop_Add_ThrowsForExistingPhone()
        {
            shop.Add(phone);
            Assert.Throws<InvalidOperationException>(() => shop.Add(new Smartphone(DEF_PHONE_MODEL, 0)));
        }

        [Test]
        public void Shop_Add_ThrowsForFullCapacity()
        {
            Smartphone phone2 = new Smartphone("Token phone 1", DEF_PHONE_MAX_CHARGE);
            Smartphone phone3 = new Smartphone("Token phone 2", DEF_PHONE_MAX_CHARGE);
            shop.Add(phone);
            shop.Add(phone2);
            Assert.Throws<InvalidOperationException>(() => shop.Add(phone3));
        }

        [Test]
        public void Shop_Remove_DecreasesCount()
        {
            shop.Add(phone);
            shop.Remove(phone.ModelName);
            Assert.AreEqual(shop.Count, 0);            
        }

        [Test]
        public void Shop_Remove_ThrowsForNonExistentPhone()
        {
            Assert.Throws<InvalidOperationException>(() => shop.Remove("Fake phone model"));
        }

        [Test]
        public void Shop_TestPhone_DecreasesBatteryChargeProperly()
        {
            int testUsage = 40;
            int expectedCharge = DEF_PHONE_MAX_CHARGE - testUsage;
            shop.Add(phone);
            shop.TestPhone(DEF_PHONE_MODEL, testUsage);
            Assert.AreEqual(phone.CurrentBateryCharge, expectedCharge);
        }

        [Test]
        public void Shop_TestPhone_ThrowsForNonExistentModel()
        {
            shop.Add(phone);
            Assert.Throws<InvalidOperationException>(() => shop.TestPhone("Missing model", 40));
        }

        [Test]
        public void Shop_TestPhone_ThrowsForLowBattery()
        {
            shop.Add(phone);
            int testUsage = DEF_PHONE_MAX_CHARGE + 10;
            Assert.Throws<InvalidOperationException>(() => shop.TestPhone(DEF_PHONE_MODEL, testUsage));
        }

        [Test]
        public void Shop_ChargePhone_RefillsBatteryChargeToMaximum()
        {
            int testUsage = 20;
            shop.Add(phone);
            shop.TestPhone(DEF_PHONE_MODEL, testUsage);
            shop.ChargePhone(DEF_PHONE_MODEL);
            Assert.AreEqual(phone.CurrentBateryCharge, DEF_PHONE_MAX_CHARGE);
        }

        [Test]
        public void Shop_ChargePhone_ThrowsForNonExistentModel()
        {
            Assert.Throws<InvalidOperationException>(() => shop.ChargePhone("Missing model"));
        }

    }
}