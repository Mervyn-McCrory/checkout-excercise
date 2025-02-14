namespace Checkout
{
    //This could probably be a struct but leave as a class for now

    /// <summary>
    /// Represents an item for sale
    /// </summary>
    public class SaleItem
    {
        public string SKU { get; }

        public int Price { get; }

        /// <summary>
        /// Standard constructor, sets all fields
        /// </summary>
        /// <param name="sku">Unique string identifier for the item</param>
        /// <param name="price">Price to charge for each instance of the item</param>
        public SaleItem(string sku, int price)
        {
            SKU = sku;
            Price = price;
        }
    }
}
