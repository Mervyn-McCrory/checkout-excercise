using Checkout;

namespace Checkout_Tests
{
    [TestFixture]
    internal class ExpandedCheckout_Tests : ICheckout_Tests
    {
        /// <inheritdoc />
        public override void CreateConcreteImplementationToTest(Dictionary<string, SaleItem> itemCatalogue, Dictionary<string, MultiSpecial> availableSpecials)
        {
            checkoutToTest = new ExpandedCheckout(itemCatalogue, availableSpecials);
        }
    }
}


