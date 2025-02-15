namespace Checkout
{
    /// <summary>
    /// Basic checkout interface as defined by the excercise
    /// </summary>
    public interface ICheckout
    {
        /// <summary>
        /// Adds an item to the "basket" to be checked out later
        /// </summary>
        /// <param name="itemSKU">Unique string identifier for a purchasable item</param>
        void Scan(string itemSKU);

        //Might want to expand this to apply a multiple to a scanned item?

        /// <summary>
        /// Gets the total price of the "basket", including any applicable discounts
        /// </summary>
        /// <returns>Final total price</returns>
        int GetTotalPrice();

        //While the excercise description suggests the pricing is to be represented in entire pounds, down the line it would probably make sense to consider them in pence as this can
        //represent more granular prices accurately without spending resources on floating point datatypes that are generally considered inappropriate for representing currency anyway

        //Also limits what kind of insanely huge prices can be supported, anything realistic SHOULD fit in an int

        //How might this be expanded in future?
        //Cancel a sale and empty the basket?
        //Modify quantity of item already in the basket? (including removal)
        //Apply a price override to an item in the basket?
    }
}
