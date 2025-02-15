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
            if (String.IsNullOrEmpty(sku))
            {
                throw new InvalidDataException("Null or Empty SKU for loaded special!");
            }

            if (requiredQuantity < 2)
            {
                throw new InvalidDataException("Singular, zero or negative quantity for loaded special!");
            }

            if (specialPrice < 1)
            {
                throw new InvalidDataException("Zero or negative price for loaded special!");
            }

            SKU = sku;
            RequiredQuantity = requiredQuantity;
            SpecialPrice = specialPrice;
        }
    }
}
