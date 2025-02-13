using Checkout;

namespace Checkout_Tests
{
    [TestFixture]
    internal class SimpleCheckout_Tests : ICheckout_Tests
    {
        public override void CreateConcreteImplementationToTest()
        {
            checkoutToTest = new SimpleCheckout();
        }
    }
}
