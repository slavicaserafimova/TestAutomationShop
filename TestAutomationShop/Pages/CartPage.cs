using OpenQA.Selenium;

namespace TestAutomationShop.Pages
{
    public class CartPage : BasePage
    {
        private By SummaryTable => By.Id("cart_summary");
        private By Rows => By.CssSelector("#cart_summary tbody tr");
        private By QuantityInputFirstRow => By.CssSelector("#cart_summary tbody tr:first-child input.cart_quantity_input");
        private By TotalProducts => By.Id("total_product");

        public CartPage(IWebDriver driver) : base(driver) { }

        public bool IsLoaded() => Driver.FindElements(SummaryTable).Count > 0;

        public int ItemCount()
        {
            return Driver.FindElements(Rows).Count;
        }

        public string TotalProductsText() => WaitVisible(TotalProducts).Text.Trim();
    }
}
