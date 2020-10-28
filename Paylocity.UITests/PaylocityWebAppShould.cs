using System;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Paylocity.UITests
{
    public class PaylocityWebAppShould
    {
        private const string LoginUrl = "https://wmxrwq14uc.execute-api.us-east-1.amazonaws.com/Prod/Account/Login";
        private const string TestUserName = "TestUser34";
        private const string TestPassword = "|q$Wl9|&Xk_)";

        [Fact]
        [Trait("Category", "Smoke")]
        public void LoadLoginPage()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                const string loginTitle = "Log In - Paylocity Benefits Dashboard";

                driver.Navigate().GoToUrl(LoginUrl);

                Assert.Equal(LoginUrl, driver.Url);
                Assert.Equal(loginTitle, driver.Title);
            }
        }
    }
}
