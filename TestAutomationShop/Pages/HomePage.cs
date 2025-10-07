using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAutomationShop.Pages
{
    public class HomePage : BasePage
    {
        private readonly string _url = "http://www.automationpractice.pl/index.php";

        private By SignInLink => By.CssSelector("a.login");
        private By SearchInput => By.Id("search_query_top");
        private By SearchButton => By.Name("submit_search");

        public HomePage(IWebDriver driver) : base(driver) { }

        public HomePage GoTo()
        {
            Driver.Navigate().GoToUrl(_url);
            return this;
        }

        public SignInPage ClickSignIn()
        {
            Click(SignInLink);
            return new SignInPage(Driver);
        }

        public SearchResultsPage Search(string keyword, bool pressEnter = false)
        {
            Type(SearchInput, keyword);
            if (pressEnter)
            {
                Driver.FindElement(SearchInput).SendKeys(Keys.Enter);
            }
            else
            {
                Click(SearchButton);
            }
            return new SearchResultsPage(Driver);
        }
    }
}
