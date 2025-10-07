using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAutomationShop.Pages
{
    public class RegistrationPage : BasePage
    {
        // Personal info
        private By GenderMrRadio => By.Id("id_gender1");
        private By FirstName => By.Id("customer_firstname");
        private By LastName => By.Id("customer_lastname");
        private By Password => By.Id("passwd");

        // Address info
        private By Address1 => By.Id("address1");
        private By City => By.Id("city");
        private By StateSelect => By.Id("id_state");
        private By Postcode => By.Id("postcode");
        private By CountrySelect => By.Id("id_country");
        private By MobilePhone => By.Id("phone_mobile");
        private By AddressAlias => By.Id("alias");

        private By RegisterBtn => By.Id("submitAccount");

       
        private By AccountForm => By.Id("account-creation_form");

        public RegistrationPage(IWebDriver driver) : base(driver) { }

        public RegistrationPage WaitForForm()
        {
            Wait.Until(ExpectedConditions.ElementIsVisible(AccountForm));
            return this;
        }

        public MyAccountPage RegisterMinimal(
            string firstName,
            string lastName,
            string password,
            string address,
            string city,
            string stateVisibleText,
            string postcode,
            string mobile,
            string alias = "My Address")
        {
            
            var gender = Driver.FindElements(GenderMrRadio);
            if (gender.Count > 0) gender[0].Click();

            Type(FirstName, firstName);
            Type(LastName, lastName);
            Type(Password, password);

            Type(Address1, address);
            Type(City, city);

            var state = new SelectElement(WaitVisible(StateSelect));
            state.SelectByText(stateVisibleText); 

            Type(Postcode, postcode);

            var country = new SelectElement(WaitVisible(CountrySelect));
            country.SelectByText("United States"); 

            Type(MobilePhone, mobile);

           
            Type(AddressAlias, alias);

            Click(RegisterBtn);
            return new MyAccountPage(Driver);
        }
    }
}
