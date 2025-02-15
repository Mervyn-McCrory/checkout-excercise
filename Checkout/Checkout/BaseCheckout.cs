using System.ComponentModel;

namespace Checkout
{
    /// <summary>
    /// Shared base for ICheckout implementations - can probably all be rolled into one class when fully developed
    /// </summary>
    public abstract class BaseCheckout
    {
        //Want a dictionary to easily index later
        //Could store the itemdata directly or just cross reference later via the identifier
        protected Dictionary<string, int> itemBasket;

        protected Dictionary<string, SaleItem> ItemCatalogue { get; }

        //Another dictionary makes sense right now for indexing on the basic approach but a simple array be more efficient if SimpleCheckout is no longer supported
        protected Dictionary<string, MultiSpecial> AvailableSpecials { get; }

        //Could potentially pass an object here strategy style that retrieves rules from whatever external source

        /// <summary>
        /// Standard constructor, sets all fields
        /// </summary>
        /// <param name="itemCatalogue">Pricing data for all purchasable items</param>
        /// <param name="availableSpecials">Details of all special deals available</param>
        public BaseCheckout(Dictionary<string, SaleItem> itemCatalogue, Dictionary<string, MultiSpecial> availableSpecials)
        {
            ItemCatalogue = itemCatalogue;
            AvailableSpecials = availableSpecials;

            itemBasket = new Dictionary<string, int>();
        }

        /// <inheritdoc />
        public void Scan(string itemSKU)
        {
            if (ItemCatalogue.ContainsKey(itemSKU))
            {
                //Check if we already have an entry for this item and increment the qualtity if so
                if (itemBasket.ContainsKey(itemSKU))
                {
                    itemBasket[itemSKU]++;
                }
                else
                {
                    itemBasket.Add(itemSKU, 1);
                }
            }
            else
            {
                throw new WarningException(string.Format("Item with SKU '{0}' could not be found in the catalogue!", itemSKU));
            }
        }
    }
}
