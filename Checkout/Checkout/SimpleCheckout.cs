namespace Checkout
{
    /// <summary>
    /// Very basic implementation of the Checkout interface, aims to do the bare minimum to satisfy requirements
    /// </summary>
    public class SimpleCheckout : ICheckout
    {
        //Want a dictionary to index later but might be overkill on first pass
        //Could store the itemdata directly OR just cross reference later via the identifier
        private Dictionary<string, int> itemBasket;

        internal Dictionary<string, SaleItem> ItemCatalogue { get; }

        //Will probably use a basic list and iterate through it if doing more complex specials later
        //Another dictionary makes sense for now for indexing
        internal Dictionary<string, MultiSpecial> AvailableSpecials { get; }

        /// <summary>
        /// Standard constructor, sets all fields
        /// </summary>
        /// <param name="itemCatalogue">Pricing data for all purchasable items</param>
        /// <param name="availableSpecials">Details of all special deals available</param>
        public SimpleCheckout(Dictionary<string, SaleItem> itemCatalogue, Dictionary<string, MultiSpecial> availableSpecials)
        {
            ItemCatalogue = itemCatalogue;
            AvailableSpecials = availableSpecials;

            itemBasket = new Dictionary<string, int>();
        }

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
