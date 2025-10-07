using TestAutomationShop.Pages;

namespace TestAutomationShop
{
    [TestFixture]
    public class E2E_Tests_Login : TestBase
    {
        // --- NEGATIVE LOGIN CASES ---

        [Test]
        [Description("Login negative: invalid email format")]
        [Order(1)]
        public void Login_InvalidEmailFormat_ShowsError()
        {
            var home = new HomePage(Driver).GoTo();
            var signIn = home.ClickSignIn();

            signIn.AttemptLoginExpectingError("not-an-email", "Whatever123!");
            Assert.That(signIn.IsErrorVisible(), "Expected an error for invalid email format.");
            TestContext.WriteLine(string.Join(" | ", signIn.GetErrorMessages()));
        }

        [Test]
        [Description("Login negative: empty credentials")]
        [Order(2)]
        public void Login_EmptyCredentials_ShowsError()
        {
            var home = new HomePage(Driver).GoTo();
            var signIn = home.ClickSignIn();

            signIn.AttemptLoginExpectingError("", "");
            Assert.That(signIn.IsErrorVisible(), "Expected an error when email/password are empty.");
            TestContext.WriteLine(string.Join(" | ", signIn.GetErrorMessages()));
        }

        [Test]
        [Description("Login negative: wrong password for existing email")]
        [Order(3)]
        public void Login_WrongPassword_ShowsAuthenticationError()
        {
            var home = new HomePage(Driver).GoTo();
            var signIn = home.ClickSignIn();

            // Use your existing known account email (env var or fallback in TestBase) but wrong pass
            signIn.AttemptLoginExpectingError(UserEmail, "DefinitelyWrong!23");
            Assert.That(signIn.IsErrorVisible(), "Expected an authentication error for wrong password.");
            var errors = signIn.GetErrorMessages();
            Assert.That(errors.Count, Is.GreaterThan(0), "Should list at least one error message.");
            TestContext.WriteLine(string.Join(" | ", errors));
        }

        [Test]
        [Description("1) Login: Given valid credentials, user lands on My Account")]
        [Order(4)]
        public void Login_WithValidCredentials_ShowsMyAccount()
        {
            // Precondition: the account exists.
            var home = new HomePage(Driver).GoTo();
            var signIn = home.ClickSignIn();
            var myAcc = signIn.Login(UserEmail, UserPass);

            Assert.That(myAcc.IsLoaded(), "My Account page did not load after login.");
            TestContext.WriteLine($"Logged in as: {myAcc.GetAccountName()}");
        }
    }
}
