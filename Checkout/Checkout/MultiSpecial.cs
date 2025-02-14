namespace Checkout
{
    /// <summary>
    /// Represents a special price for purchasing multiples of a given item
    /// </summary>
    public class MultiSpecial
    {
        public string SKU { get; }

        public int RequiredMultiple { get; }

        public int SpecialPrice { get; }

        /// <summary>
        /// Standard constructor, sets all fields
        /// </summary>
        /// <param name="sku">Unique string identifier for the applicable item</param>
        /// <param name="requiredMultiple">Multiple of the given item required to qualify for the special price</param>
        /// <param name="specialPrice">Special discounted price to apply</param>
        public MultiSpecial(string sku, int requiredMultiple, int specialPrice)
        {
            SKU = sku;
            RequiredMultiple = requiredMultiple;
            SpecialPrice = specialPrice;
        }
    }
}
