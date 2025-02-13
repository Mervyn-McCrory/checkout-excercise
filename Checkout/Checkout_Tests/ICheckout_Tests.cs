using Checkout;

namespace Checkout_Tests
{
    [TestFixture]
    internal abstract class ICheckout_Tests
    {
        //Leaving nullable for now but think about how this could maybe be cleaner
        protected ICheckout? checkoutToTest;

        //Overrides need to populate checkoutToTest - any clean way to enforce this?
        abstract public void CreateConcreteImplementationToTest();

        [SetUp]
        public void Setup()
        {
            CreateConcreteImplementationToTest();
        }

        [Test]
        public void ScanInvalidItem()
        {
            Assert.Fail();
        }

        [Test]
        public void ScanNewValidItem()
        {
            Assert.Fail();
        }

        [Test]
        public void ScanExtraValidItem()
        {
            Assert.Fail();
        }

        [Test]
        public void CheckoutEmptyBasket()
        {
            Assert.Fail();
        }

        [Test]
        public void CheckoutSingleItem()
        {
            Assert.Fail();
        }

        [Test]
        public void CheckoutDistinctItems()
        {
            Assert.Fail();
        }

        [Test]
        public void CheckoutMultipleItems_LessThanDeal()
        {
            Assert.Fail();
        }

        [Test]
        public void CheckoutMultipleItems_EqualToDeal()
        {
            Assert.Fail();
        }

        [Test]
        public void CheckoutMultipleItems_MoreThanDeal_SingleDeal()
        {
            Assert.Fail();
        }

        [Test]
        public void CheckoutMultipleItems_MoreThanDeal_MultipleDeals()
        {
            Assert.Fail();
        }

        [Test]
        public void CheckoutDistinctItemsAndDeals()
        {
            Assert.Fail();
        }

        //Might want to explicitly test more permutations but this should be good coverage to start
    }
}