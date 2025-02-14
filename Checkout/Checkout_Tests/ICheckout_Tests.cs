using Checkout;
using System.ComponentModel;

namespace Checkout_Tests
{
    [TestFixture]
    internal abstract class ICheckout_Tests
    {
        //Leaving nullable for now but think about how this could maybe be cleaner
        protected ICheckout? checkoutToTest;

        //Overrides need to populate checkoutToTest - any clean way to enforce this?
        abstract public void CreateConcreteImplementationToTest(Dictionary<string, SaleItem> itemCatalogue, Dictionary<string, MultiSpecial> availableSpecials);

        //Some repeating code in tests but we want tests to be isolated and use distinct test data - duplication should be fine as long as it doesn't extend beyond distinct and readable test data
        //Similarly the repeated calls could be looped but I'd consider that overkill in a test

        [Test]
        public void ScanInvalidItem()
        {
            #region Test Data

            Dictionary<string, SaleItem> itemCatalogue = new Dictionary<string, SaleItem>();

            Dictionary<string, MultiSpecial> availableSpecials = new Dictionary<string, MultiSpecial>();

            CreateConcreteImplementationToTest(itemCatalogue, availableSpecials);

            #endregion

            //There are no items defined so any attempt at scanning should fail in some way

            Assert.Throws<WarningException>(() => checkoutToTest.Scan("A"));
        }

        [Test]
        public void ScanNewValidItem()
        {
            #region Test Data

            Dictionary<string, SaleItem> itemCatalogue = new Dictionary<string, SaleItem>()
            {
                { "A", new SaleItem("A", 1) }
            };

            Dictionary<string, MultiSpecial> availableSpecials = new Dictionary<string, MultiSpecial>();

            CreateConcreteImplementationToTest(itemCatalogue, availableSpecials);

            #endregion

            //Would be better to check that the scanned item has actually populated the basket but that would either overlap with testing the actual checkout logic or involve exposing more of the class
            //Settle for this for now

            Assert.DoesNotThrow(() => checkoutToTest.Scan("A"));
        }

        [Test]
        public void ScanExtraValidItem()
        {
            #region Test Data

            Dictionary<string, SaleItem> itemCatalogue = new Dictionary<string, SaleItem>()
            {
                { "A", new SaleItem("A", 1) }
            };

            Dictionary<string, MultiSpecial> availableSpecials = new Dictionary<string, MultiSpecial>();

            CreateConcreteImplementationToTest(itemCatalogue, availableSpecials);

            #endregion

            //The initial scan is covered by the previous test case so we technically only care about asserting the subsequent scan
            //This case was added with the idea that we want to ensure that repeatedly scanned items stack up correctly within the basket but we have the same issue as ScanNewValidItem(), just check nothing is thrown for now

            checkoutToTest.Scan("A");

            Assert.DoesNotThrow(() => checkoutToTest.Scan("A"));
        }

        [Test]
        public void CheckoutEmptyBasket()
        {
            #region Test Data

            Dictionary<string, SaleItem> itemCatalogue = new Dictionary<string, SaleItem>();

            Dictionary<string, MultiSpecial> availableSpecials = new Dictionary<string, MultiSpecial>();

            CreateConcreteImplementationToTest(itemCatalogue, availableSpecials);

            #endregion

            //Nunit now recommends a new format for equal assertions, leave for now and update later

            Assert.AreEqual(0, checkoutToTest.GetTotalPrice());
        }

        [Test]
        public void CheckoutSingleItem()
        {
            #region Test Data

            Dictionary<string, SaleItem> itemCatalogue = new Dictionary<string, SaleItem>()
            {
                { "A", new SaleItem("A", 1) }
            };

            Dictionary<string, MultiSpecial> availableSpecials = new Dictionary<string, MultiSpecial>();

            CreateConcreteImplementationToTest(itemCatalogue, availableSpecials);

            #endregion

            checkoutToTest.Scan("A");

            Assert.AreEqual(1, checkoutToTest.GetTotalPrice());
        }

        [Test]
        public void CheckoutDistinctItems()
        {
            #region Test Data

            Dictionary<string, SaleItem> itemCatalogue = new Dictionary<string, SaleItem>()
            {
                { "A", new SaleItem("A", 1) },
                { "B", new SaleItem("B", 2) },
                { "C", new SaleItem("C", 3) }
            };

            Dictionary<string, MultiSpecial> availableSpecials = new Dictionary<string, MultiSpecial>();

            CreateConcreteImplementationToTest(itemCatalogue, availableSpecials);

            #endregion

            checkoutToTest.Scan("A");
            checkoutToTest.Scan("B");
            checkoutToTest.Scan("C");

            Assert.AreEqual(6, checkoutToTest.GetTotalPrice());
        }

        [Test]
        public void CheckoutMultipleItems_LessThanDeal()
        {
            #region Test Data

            Dictionary<string, SaleItem> itemCatalogue = new Dictionary<string, SaleItem>()
            {
                { "A", new SaleItem("A", 2) }
            };

            Dictionary<string, MultiSpecial> availableSpecials = new Dictionary<string, MultiSpecial>()
            {
                { "A", new MultiSpecial("A", 3, 5)}
            };

            CreateConcreteImplementationToTest(itemCatalogue, availableSpecials);

            #endregion

            checkoutToTest.Scan("A");
            checkoutToTest.Scan("A");

            Assert.AreEqual(4, checkoutToTest.GetTotalPrice());
        }

        [Test]
        public void CheckoutMultipleItems_EqualToDeal()
        {
            #region Test Data

            Dictionary<string, SaleItem> itemCatalogue = new Dictionary<string, SaleItem>()
            {
                { "A", new SaleItem("A", 2) }
            };

            Dictionary<string, MultiSpecial> availableSpecials = new Dictionary<string, MultiSpecial>()
            {
                { "A", new MultiSpecial("A", 3, 5)}
            };

            CreateConcreteImplementationToTest(itemCatalogue, availableSpecials);

            #endregion

            checkoutToTest.Scan("A");
            checkoutToTest.Scan("A");
            checkoutToTest.Scan("A");

            Assert.AreEqual(5, checkoutToTest.GetTotalPrice());
        }

        [Test]
        public void CheckoutMultipleItems_MoreThanDeal_SingleDeal()
        {
            #region Test Data

            Dictionary<string, SaleItem> itemCatalogue = new Dictionary<string, SaleItem>()
            {
                { "A", new SaleItem("A", 2) }
            };

            Dictionary<string, MultiSpecial> availableSpecials = new Dictionary<string, MultiSpecial>()
            {
                { "A", new MultiSpecial("A", 3, 5)}
            };

            CreateConcreteImplementationToTest(itemCatalogue, availableSpecials);

            #endregion

            checkoutToTest.Scan("A");
            checkoutToTest.Scan("A");
            checkoutToTest.Scan("A");
            checkoutToTest.Scan("A");

            Assert.AreEqual(7, checkoutToTest.GetTotalPrice());
        }

        [Test]
        public void CheckoutMultipleItems_MoreThanDeal_MultipleDeals()
        {
            #region Test Data

            Dictionary<string, SaleItem> itemCatalogue = new Dictionary<string, SaleItem>()
            {
                { "A", new SaleItem("A", 2) }
            };

            Dictionary<string, MultiSpecial> availableSpecials = new Dictionary<string, MultiSpecial>()
            {
                { "A", new MultiSpecial("A", 3, 5)}
            };

            CreateConcreteImplementationToTest(itemCatalogue, availableSpecials);

            #endregion

            checkoutToTest.Scan("A");
            checkoutToTest.Scan("A");
            checkoutToTest.Scan("A");
            checkoutToTest.Scan("A");
            checkoutToTest.Scan("A");
            checkoutToTest.Scan("A");

            Assert.AreEqual(10, checkoutToTest.GetTotalPrice());
        }

        [Test]
        public void CheckoutDistinctItemsAndDeals()
        {
            //Using the data defined in the exercise for this one

            #region Test Data

            Dictionary<string, SaleItem> itemCatalogue = new Dictionary<string, SaleItem>()
            {
                { "A", new SaleItem("A", 50) },
                { "B", new SaleItem("B", 30) },
                { "C", new SaleItem("C", 20) },
                { "D", new SaleItem("D", 15) }
            };

            Dictionary<string, MultiSpecial> availableSpecials = new Dictionary<string, MultiSpecial>()
            {
                { "A", new MultiSpecial("A", 3, 130)},
                { "B", new MultiSpecial("B", 2, 45)}
            };

            CreateConcreteImplementationToTest(itemCatalogue, availableSpecials);

            #endregion

            checkoutToTest.Scan("A");
            checkoutToTest.Scan("A");
            checkoutToTest.Scan("A");
            checkoutToTest.Scan("A");
            checkoutToTest.Scan("A");

            checkoutToTest.Scan("B");
            checkoutToTest.Scan("B");
            checkoutToTest.Scan("B");
            checkoutToTest.Scan("B");

            checkoutToTest.Scan("C");
            checkoutToTest.Scan("C");

            checkoutToTest.Scan("D");
            checkoutToTest.Scan("D");
            checkoutToTest.Scan("D");

            //5x A should cost: 230
            //4x B should cost: 90
            //2x C should cost: 40
            //3x D should cost: 45
            Assert.AreEqual(405, checkoutToTest.GetTotalPrice());
        }

        //Might want to explicitly test more permutations but this should be good coverage to start
    }
}