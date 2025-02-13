namespace Checkout
{
    /// <summary>
    /// Very basic implementation of the Checkout interface, aims to do the bare minimum to satisfy requirements
    /// </summary>
    public class SimpleCheckout : ICheckout
    {
        /// <inheritdoc />
        public void Scan(string itemSKU)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public int GetTotalPrice()
        {
            throw new NotImplementedException();
        }
    }
}
