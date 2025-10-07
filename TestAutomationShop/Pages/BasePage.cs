using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace TestAutomationShop.Pages
{
    public abstract class BasePage
    {
        protected readonly IWebDriver Driver;
        protected readonly WebDriverWait Wait;

        protected BasePage(IWebDriver driver)
        {
            Driver = driver;
            Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
        }

        protected IWebElement WaitVisible(By by) => Wait.Until(ExpectedConditions.ElementIsVisible(by));
        protected IWebElement WaitClickable(By by) => Wait.Until(ExpectedConditions.ElementToBeClickable(by));
        protected void Click(By by) => WaitClickable(by).Click();
        protected void Type(By by, string text)
        {
            var el = WaitVisible(by);
            el.Clear();
            el.SendKeys(text);
        }
    }
}
