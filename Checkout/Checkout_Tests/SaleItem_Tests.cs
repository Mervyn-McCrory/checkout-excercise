using Checkout;

namespace Checkout_Tests;

public class SaleItem_Tests
{
    //Shared setup seems to be mostly considered an iffy practice nowadays but probably no harm in sharing the blank item - super minor either way in this case though

    //Would be good to ensure we warn or throw when a price is passed that is simply too big for an int but this isn't allowed at the compiler level so it would have to be caught at a point where pricing data is read from elsewhere

    [Test]
    public void CreateWithSKUAndPositivePrice()
    {
        SaleItem testItem;

        Assert.DoesNotThrow(() => testItem = new SaleItem("ABC", 99));
    }

    [Test]
    public void CreateWithEmptySKU()
    {
        SaleItem testItem;

        Assert.Throws<InvalidDataException>(() => testItem = new SaleItem("", 99));
    }

    //Assuming for now that we don't consider free a valid price - keeping as a separate case as we might want to just warn instead
    [Test]
    public void CreateWithZeroPrice()
    {
        SaleItem testItem;

        Assert.Throws<InvalidDataException>(() => testItem = new SaleItem("ABC", 0));
    }

    [Test]
    public void CreateWithNegativePrice()
    {
        SaleItem testItem;

        Assert.Throws<InvalidDataException>(() => testItem = new SaleItem("ABC", -1));
    }
}
