using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using TestProject1.CustomMethods;
using TestProject1.PageObjects;

namespace TestProject1.Tests
{
    public class CustomerTests
    {
        IWebDriver driver;
        [SetUp]
        public void setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(TestContext.Parameters.Get("url"));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);

        }
        [Test]
        public void AddNewCustomerTest()
        {
            LoginPage loginPage = new LoginPage(driver);
            loginPage.LoginApplication(TestContext.Parameters.Get("username"), TestContext.Parameters.Get("password"));
            //Navigate To Customer Management Page
            DashboardPage dashboardPage = new DashboardPage(driver);
            BaseClass baseClass = new BaseClass();
            baseClass.ActionHoverAndClick(driver, dashboardPage.accountsLink, dashboardPage.customersLink);
            //Click Add Customer Button
            CustomerManagementPage customerManagementPage = new CustomerManagementPage(driver);
            customerManagementPage.addButton.Click();
            //Add Customer
            AddCustomerPage addCustomerPage = new AddCustomerPage(driver);
            addCustomerPage.AddCustomer();
            //Verify Customer Created
            IWebElement verifyCustomer = driver.FindElement(By.XPath("//td[text()=" + "'" + TestContext.Parameters.Get("customerFirstName") + "']"));
            Assert.IsTrue(AssertClass.IsElementPresent(driver, verifyCustomer), "Customer not created or found on customer management page");
        }
        [Test]
        public void DeleteCustomerTest()
        {
            LoginPage loginPage = new LoginPage(driver);
            loginPage.LoginApplication(TestContext.Parameters.Get("username"), TestContext.Parameters.Get("password"));
            //Navigate To Customer Management Page
            DashboardPage dashboardPage = new DashboardPage(driver);
            BaseClass baseClass = new BaseClass();
            baseClass.ActionHoverAndClick(driver, dashboardPage.accountsLink, dashboardPage.customersLink);
            //Delete Customer
            CustomerManagementPage customerManagementPage = new CustomerManagementPage(driver);
            customerManagementPage.specificCustomerCheckbox.Click();
            customerManagementPage.deleteCustomerButton.Click();
            Assert.IsFalse(AssertClass.IsElementPresent(driver, customerManagementPage.specificCustomerCheckbox), "Customer present page");
        }

    }
}
