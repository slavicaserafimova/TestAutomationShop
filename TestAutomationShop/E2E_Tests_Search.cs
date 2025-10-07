using TestAutomationShop.Pages;

namespace TestAutomationShop
{
    [TestFixture]
    public class E2E_Tests_Search : TestBase
    {
        [Test]
        [Description("2) Search: Searching for a keyword returns results and first result opens")]

        [Order(1)]
        public void Search_ForDress_ReturnsResults_AndOpenFirst()
        {
            var home = new HomePage(Driver).GoTo();
            var results = home.Search("dress", pressEnter: true);

            Assert.That(results.HasResults(), "Expected at least one search result for 'dress'.");

            var product = results.OpenFirstResult();
            var title = product.Title();
            Assert.That(!string.IsNullOrWhiteSpace(title), "Product page title should not be empty.");
        }

        [Test]
        [Description("Search: query returns zero results and shows 'No results' message")]
        [Order(2)]
        public void Search_InvalidKeyword_ShowsNoResultsMessage()
        {
            var home = new HomePage(Driver).GoTo();

            // Use a nonsense keyword that will never match any product
            var results = home.Search("asdfqwer");

            Assert.That(!results.HasResults(), "Expected zero search results.");
            Assert.That(results.HasNoResultsMessage(), "Expected a 'No results' message on the page.");

            var message = results.GetNoResultsText();
            TestContext.WriteLine($"Displayed message: {message}");
            Assert.That(message.ToLower(), Does.Contain("no results"), "Expected 'No results' in the alert text.");
        }
    }
}
