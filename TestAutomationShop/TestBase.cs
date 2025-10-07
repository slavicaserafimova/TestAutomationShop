using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace TestAutomationShop
{
    public class TestBase
    {
        protected IWebDriver Driver;
        protected const string BaseUrl = "http://www.automationpractice.pl/index.php";

        
        protected string UserEmail => Environment.GetEnvironmentVariable("DEMO_EMAIL") ?? "slavica.serafimova@gmail.com";
        protected string UserPass => Environment.GetEnvironmentVariable("DEMO_PASSWORD") ?? "P@ssw0rd";

        [SetUp]
        public void Setup()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            options.AddArgument("--disable-gpu");
            options.AddArgument("--no-sandbox");
            Driver = new ChromeDriver(options);
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0); 
        }

        [TearDown]
        public void Teardown()
        {
            if (Driver != null)
            {
                Driver.Dispose(); 
            }
        }
    }
}
