namespace Checkout
{
    /// <summary>
    /// Expanded checkout implementation that seeks to support special deals in a more generic way that supports easier extensibility
    /// </summary>
    public class ExpandedCheckout : BaseCheckout, ICheckout
    {
        /// <inheritdoc />
        public ExpandedCheckout(Dictionary<string, SaleItem> itemCatalogue, Dictionary<string, MultiSpecial> availableSpecials) : base(itemCatalogue, availableSpecials) { }

        /// <inheritdoc />
        public int GetTotalPrice()
        {
            int runningTotal = 0;

            //Take a shallow clone of the basket so that it can be consumed without affecting the original
            Dictionary<string, int> tempBasket = itemBasket.ToDictionary(entry => entry.Key, entry => entry.Value);

            //Attempt to match and apply all known specials
            //As a greater variety of specials are added this process should also involve some kind of priority to determine which applies to given items in the event of overlap
            foreach(KeyValuePair<string, MultiSpecial> availableSpecialEntry in AvailableSpecials)
            {
                runningTotal += availableSpecialEntry.Value.ApplyToBasket(tempBasket);
            }

            //Total up the normal prices for the remaining loose items
            foreach (KeyValuePair<string, int> tempBasketEntry in tempBasket)
            {
                runningTotal += tempBasketEntry.Value * ItemCatalogue[tempBasketEntry.Key].Price;
            }

            return runningTotal;
        }
    }
}
