using System.ComponentModel;

namespace Checkout
{
    /// <summary>
    /// Very basic implementation of the Checkout interface, aims to do the bare minimum to satisfy requirements - should become deprecated as newer versions are developed
    /// </summary>
    public class SimpleCheckout : BaseCheckout, ICheckout
    {
        /// <inheritdoc />
        public SimpleCheckout(Dictionary<string, SaleItem> itemCatalogue, Dictionary<string, MultiSpecial> availableSpecials) : base(itemCatalogue, availableSpecials) { }

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
