using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAutomationShop.Pages
{
    public class MyAccountPage : BasePage
    {
        private By PageHeading => By.CssSelector("h1");
        private By AccountName => By.CssSelector("a.account span");

        public MyAccountPage(IWebDriver driver) : base(driver) { }

        public bool IsLoaded()
        {
            var heading = Wait.Until(ExpectedConditions.ElementIsVisible(PageHeading)).Text.Trim().ToUpperInvariant();
            return heading.Contains("MY ACCOUNT");
        }

        public string GetAccountName()
        {
            return WaitVisible(AccountName).Text.Trim();
        }
    }
}
