namespace Checkout
{
    /// <summary>
    /// Represents a special price for purchasing multiples of a given item
    /// </summary>
    public class MultiSpecial
    {
        /// <summary>
        /// Unique string identifier for the applicable item
        /// </summary>
        public string SKU { get; }

        /// <summary>
        /// Quantity of the given item required to qualify for the special price
        /// </summary>
        public int RequiredQuantity { get; }

        /// <summary>
        /// Special discounted price to apply to the qualified items
        /// </summary>
        public int SpecialPrice { get; }

        /// <summary>
        /// Standard constructor, sets all fields
        /// </summary>
        /// <param name="sku">Unique string identifier for the applicable item</param>
        /// <param name="requiredQuantity">Quantity of the given item required to qualify for the special price</param>
        /// <param name="specialPrice">Special discounted price to apply to the qualified items</param>
        public MultiSpecial(string sku, int requiredQuantity, int specialPrice)
        {
            SKU = sku;
            RequiredQuantity = requiredQuantity;
            SpecialPrice = specialPrice;
        }
    }
}
