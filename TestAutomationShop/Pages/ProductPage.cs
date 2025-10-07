using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace TestAutomationShop.Pages
{
    public class ProductPage : BasePage
    {
        private By SizeSelectPrimary => By.CssSelector("select#group_1");
        private By SizeSelectByName => By.CssSelector("select[name='group_1']");
        private By AddToCartBtnContainer => By.Id("add_to_cart");
        private By AddToCartBtn => By.CssSelector("#add_to_cart button");
        private By LayerCartModal => By.Id("layer_cart");
        private By ProceedToCheckout => By.CssSelector("#layer_cart a[title='Proceed to checkout']");
        private By ProductTitle => By.CssSelector("h1");

        
        private By ColorList => By.Id("color_to_pick_list"); // color 'Blue' 

        public ProductPage(IWebDriver driver) : base(driver) { }

        public string Title() => WaitVisible(ProductTitle).Text.Trim();

        public ProductPage SelectSize(string visibleText)
        {
            var select = Driver.FindElements(SizeSelectPrimary).FirstOrDefault();
            if (select != null)
            {
                var sel = new SelectElement(select);
                sel.SelectByText(visibleText);
            }
            else
            {
                var select2 = Driver.FindElements(SizeSelectByName).FirstOrDefault();
                var sel = new SelectElement(select2);
                sel.SelectByText(visibleText);
            }
            return this;
        }

        public ProductPage SelectColor(string colorVisibleTitle)
        {
            var color = WaitVisible(ColorList);
            var colorLink = color.FindElement(By.CssSelector($"a[title='{colorVisibleTitle}']"));
            colorLink.Click();
            return this;
        }

        public ProductPage WaitAddToCartVisibleAndEnabled()
        {
            Wait.Until(ExpectedConditions.ElementIsVisible(AddToCartBtnContainer));
            var btn = Wait.Until(ExpectedConditions.ElementToBeClickable(AddToCartBtn));
            return this;
        }

        public ProductPage AddToCart()
        {
            WaitAddToCartVisibleAndEnabled();
            Click(AddToCartBtn);
            Wait.Until(ExpectedConditions.ElementIsVisible(LayerCartModal));
            return this;
        }

        public CartPage ProceedFromModalToCart()
        {
            Click(ProceedToCheckout);
            return new CartPage(Driver);
        }
    }
}
