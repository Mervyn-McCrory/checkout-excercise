using Checkout;

namespace Checkout_Tests;

public class MultiSpecialTests
{
    //Similar thoughts as SaleItem_Tests

    [Test]
    public void CreateWithSKUAndMultipleQuantityAndPrice()
    {
        MultiSpecial testMultispecial;

        Assert.DoesNotThrow(() => testMultispecial = new MultiSpecial("ABC", 2, 99));
    }

    [Test]
    public void CreateWithEmptySKU()
    {
        MultiSpecial testMultispecial;

        Assert.Throws<InvalidDataException>(() => testMultispecial = new MultiSpecial("", 1, 99));
    }

    [Test]
    public void CreateWithSingularOrZeroOrNegativeQuantity()
    {
        MultiSpecial testMultispecial;

        Assert.Throws<InvalidDataException>(() => testMultispecial = new MultiSpecial("ABC", 1, 99));
        Assert.Throws<InvalidDataException>(() => testMultispecial = new MultiSpecial("ABC", 0, 99));
        Assert.Throws<InvalidDataException>(() => testMultispecial = new MultiSpecial("ABC", -1, 99));
    }

    //Assuming for now that we don't consider free a valid price - keeping as a separate case as we might want to just warn instead
    [Test]
    public void CreateWithZeroPrice()
    {
        MultiSpecial testMultispecial;

        Assert.Throws<InvalidDataException>(() => testMultispecial = new MultiSpecial("ABC", 1, 0));
    }

    [Test]
    public void CreateWithNegativePrice()
    {
        MultiSpecial testMultispecial;

        Assert.Throws<InvalidDataException>(() => testMultispecial = new MultiSpecial("ABC", 1, -1));
    }
}
