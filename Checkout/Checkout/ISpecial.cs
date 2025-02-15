namespace Checkout
{
    public interface ISpecial
    {
        //Could wrap the basket as its own type now that its use is spreading but it's still just a dictionary ATM

        //Might be able to just type the basket as an enumerable?

        /// <summary>
        /// Applies this special offer to the given basket collection, consuming any applicable items and returning the total price of those items
        /// </summary>
        /// <param name="basket">Collection of basket items to check</param>
        /// <returns>Total price of any applicable items found</returns>
        int ApplyToBasket(Dictionary<string, int> basket);
    }
}
