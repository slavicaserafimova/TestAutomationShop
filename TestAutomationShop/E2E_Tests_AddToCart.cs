using TestAutomationShop.Pages;

namespace TestAutomationShop
{

    [TestFixture]
    public class E2E_Tests_AddToCart : TestBase
    {
        [Test]
        [Description("Add to cart: open product id=5, select Size=L and Color=Blue, then add to cart")]
        public void AddToCart_Product5_SizeL_ColorBlue()
        {
            var url = BaseUrl + "?id_product=5&controller=product";
            Driver.Navigate().GoToUrl(url);

            var product = new ProductPage(Driver);
            var name = product.Title();
            Assert.That(!string.IsNullOrWhiteSpace(name), "Product title should be visible.");

            // Ensure explicit selection (even if URL hash preselects it)
            product
                .SelectSize("L")
                .SelectColor("Blue")
                .WaitAddToCartVisibleAndEnabled()
                .AddToCart();

            var cart = product.ProceedFromModalToCart();

            Assert.That(cart.IsLoaded(), "Cart summary page did not load.");
            Assert.That(cart.ItemCount(), Is.GreaterThanOrEqualTo(1), "Cart should have at least one line item.");
            TestContext.WriteLine($"Added to cart: {name}. Total products: {cart.TotalProductsText()}");
        }
    }
}

