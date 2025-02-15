using Checkout;

namespace Checkout_Tests;

public class MultiSpecialTests
{
    //Similar thoughts as SaleItem_Tests

    [Test]
    public void CreateWithSKUAndPositiveQuantityAndPrice()
    {
        MultiSpecial testMultispecial;

        Assert.DoesNotThrow(() => testMultispecial = new MultiSpecial("ABC", 1, 99));
    }

    [Test]
    public void CreateWithEmptySKU()
    {
        MultiSpecial testMultispecial;

        Assert.Throws<InvalidDataException>(() => testMultispecial = new MultiSpecial("", 1, 99));
    }

    [Test]
    public void CreateWithZeroOrNegativeQuantity()
    {
        MultiSpecial testMultispecial;

        Assert.Throws<InvalidDataException>(() => testMultispecial = new MultiSpecial("ABC", 0, 99));
        Assert.Throws<InvalidDataException>(() => testMultispecial = new MultiSpecial("ABC", -1, 99));
    }

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
