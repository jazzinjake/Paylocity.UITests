using System;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Paylocity.UITests
{
    public class PaylocityWebAppShould
    {
        private const string LoginUrl = "https://wmxrwq14uc.execute-api.us-east-1.amazonaws.com/Prod/Account/Login";
        private const string LoginTitle = "Log In - Paylocity Benefits Dashboard";
        private const string DashboardUrl = "https://wmxrwq14uc.execute-api.us-east-1.amazonaws.com/Prod/Benefits";
        private const string DashboardTitle = "Employees - Paylocity Benefits Dashboard";

        private const string TestUserName = "TestUser34";
        private const string TestPassword = "|q$Wl9|&Xk_)";

        private void LogInSuccessfully(IWebDriver driver)
        {
            driver.Navigate().GoToUrl(LoginUrl);

            IWebElement usernameField = driver.FindElement(By.Id("Username"));
            usernameField.SendKeys(TestUserName);

            IWebElement passwordField = driver.FindElement(By.Id("Password"));
            passwordField.SendKeys(TestPassword);

            IWebElement logInButton = driver.FindElement(By.TagName("button"));
            logInButton.Click();
        }

        [Fact]
        [Trait("Category", "Add Employee")]
        public void ModifyEmployeeTableWhenEmployeeIsAdded()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                LogInSuccessfully(driver);

                const string testFirstName = "Robert";
                const string testLastName = "Harrington";
                const string testDependents = "0";

                driver.Navigate().GoToUrl(DashboardUrl);

                System.Threading.Thread.Sleep(1000);

                IWebElement initialEmployeeTable = driver.FindElement(By.TagName("tbody"));
                string initialTableText = initialEmployeeTable.Text;

                IWebElement addEmployeeButton = driver.FindElement(By.Id("add"));
                addEmployeeButton.Click();

                IWebElement firstNameField = driver.FindElement(By.Id("firstName"));
                firstNameField.SendKeys(testFirstName);

                IWebElement lastNameField = driver.FindElement(By.Id("lastName"));
                lastNameField.SendKeys(testLastName);

                IWebElement dependantsField = driver.FindElement(By.Id("dependants"));
                dependantsField.SendKeys(testDependents);

                IWebElement addButton = driver.FindElement(By.Id("addEmployee"));
                addButton.Click();

                System.Threading.Thread.Sleep(1000);

                IWebElement finalEmployeeTable = driver.FindElement(By.TagName("tbody"));
                string finalTableText = finalEmployeeTable.Text;

                Assert.NotEqual(initialTableText, finalTableText);
            }
        }
    }
}
