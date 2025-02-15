using System.ComponentModel;

namespace Checkout
{
    /// <summary>
    /// Very basic implementation of the Checkout interface, aims to do the bare minimum to satisfy requirements
    /// </summary>
    public class SimpleCheckout : ICheckout
    {
        //Want a dictionary to easily index later
        //Could store the itemdata directly OR just cross reference later via the identifier
        private Dictionary<string, int> itemBasket;

        internal Dictionary<string, SaleItem> ItemCatalogue { get; }

        //Another dictionary makes sense right now for indexing on the basic approach but will probably be replaced later
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
            //If the item can be found in the catalogue then we know it's valid and we have data for it
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

        /// <inheritdoc />
        public int GetTotalPrice()
        {
            //Really basic approach should work for the specified functionality but will be really rigid and need rewritten if we want to support more complex special rules

            int runningTotal = 0;

            foreach (KeyValuePair<string, int> item in itemBasket)
            {
                //Check if there is an applicable special deal
                if (AvailableSpecials.ContainsKey(item.Key))
                {
                    //Check how many times to apply the special price
                    runningTotal += (item.Value / AvailableSpecials[item.Key].RequiredQuantity) * AvailableSpecials[item.Key].SpecialPrice;

                    //Apply the normal price to the remainder
                    runningTotal += (item.Value % AvailableSpecials[item.Key].RequiredQuantity) * ItemCatalogue[item.Key].Price;
                }
                else
                {
                    //No applicable special so simply apply the normal price to each
                    runningTotal += item.Value * ItemCatalogue[item.Key].Price;
                }
            }

            return runningTotal;
        }
    }
}
