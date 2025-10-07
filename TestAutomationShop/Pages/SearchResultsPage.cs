using OpenQA.Selenium;

namespace TestAutomationShop.Pages
{
    public class SearchResultsPage : BasePage
    {
        private By ResultsGrid => By.CssSelector(".product_list.grid");
        private By ResultItems => By.CssSelector(".product_list .product-container");
        private By FirstProductLink => By.CssSelector(".product_list .product-container .product-name");
        private By NoResultsAlert => By.CssSelector(".alert.alert-warning");

        public SearchResultsPage(IWebDriver driver) : base(driver) { }

        public bool HasResults()
        {
            var results = Driver.FindElements(ResultItems);
            return results.Count > 0;
        }

        public bool HasNoResultsMessage()
        {
            var alerts = Driver.FindElements(NoResultsAlert);
            return alerts.Count > 0;
        }

        public string GetNoResultsText()
        {
            var alert = Driver.FindElements(NoResultsAlert);
            return alert.Count > 0 ? alert[0].Text.Trim() : string.Empty;
        }

        public ProductPage OpenFirstResult()
        {
            Click(FirstProductLink);
            return new ProductPage(Driver);
        }
    }
}
