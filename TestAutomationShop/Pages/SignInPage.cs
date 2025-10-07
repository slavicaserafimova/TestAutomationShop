using OpenQA.Selenium;

namespace TestAutomationShop.Pages
{
    public class SignInPage : BasePage
    {
        private By EmailInput => By.Id("email");
        private By PasswordInput => By.Id("passwd");
        private By SubmitLoginBtn => By.Id("SubmitLogin");
        private By AlertDanger => By.CssSelector(".alert.alert-danger");
        private By AlertDangerItems => By.CssSelector(".alert.alert-danger li");

        public SignInPage(IWebDriver driver) : base(driver) { }

        public MyAccountPage Login(string email, string password)
        {
            Type(EmailInput, email);
            Type(PasswordInput, password);
            Click(SubmitLoginBtn);
            return new MyAccountPage(Driver);
        }

        public void AttemptLoginExpectingError(string email, string password)
        {
            Type(EmailInput, email);
            Type(PasswordInput, password);
            Click(SubmitLoginBtn);
            // Wait for possible error
            WaitVisible(AlertDanger);
        }

        public bool IsErrorVisible() => Driver.FindElements(AlertDanger).Count > 0;

        public List<string> GetErrorMessages()
        {
            return Driver.FindElements(AlertDangerItems).Select(e => e.Text.Trim()).Where(t => !string.IsNullOrWhiteSpace(t)).ToList();
        }
    }
}
