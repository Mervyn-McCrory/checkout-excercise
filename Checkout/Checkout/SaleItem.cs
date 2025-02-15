namespace Checkout
{
    //This could probably be a struct but leave as a class for now

    /// <summary>
    /// Represents an item for sale
    /// </summary>
    public class SaleItem
    {
        /// <summary>
        /// Unique string identifier for the item
        /// </summary>
        public string SKU { get; }

        /// <summary>
        /// Price to charge for each instance of the item
        /// </summary>
        public int Price { get; }

        /// <summary>
        /// Standard constructor, sets all fields
        /// </summary>
        /// <param name="sku">Unique string identifier for the item</param>
        /// <param name="price">Price to charge for each instance of the item</param>
        public SaleItem(string sku, int price)
        {
            if (String.IsNullOrEmpty(sku))
            {
                throw new InvalidDataException("Null or Empty SKU for loaded item!");
            }

            if (price < 1)
            {
                throw new InvalidDataException("Zero or negative price for loaded item!");
            }

            SKU = sku;
            Price = price;
        }
    }
}
