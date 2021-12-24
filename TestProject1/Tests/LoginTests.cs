using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Text;
using TestProject1.CustomMethods;
using TestProject1.PageObjects;

namespace TestProject1.Tests
{
    public class LoginTests
    {
        IWebDriver driver;
        public TestContext TestContext { get; set; }
        [SetUp]
        public void setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(TestContext.Parameters.Get("url"));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);

        }
        [Test]
        public void VerifyValidLoginToApplication()
        {
            LoginPage loginPage = new LoginPage(driver);
            loginPage.LoginApplication(TestContext.Parameters.Get("username"), TestContext.Parameters.Get("password"));
            Assert.IsTrue(AssertClass.IsElementPresent(driver, loginPage.logoutButton), "User not on home page");
            
        }
        [Test]
        public void VerifyInValidLoginToApplication()
        {
            LoginPage loginPage = new LoginPage(driver);
            loginPage.LoginApplication(TestContext.Parameters.Get("username"), TestContext.Parameters.Get("wrongPassword"));
            Assert.IsTrue(AssertClass.IsElementPresent(driver, loginPage.invalidError), "No Error Found");

        }
        [Test]
        public void VerifyLogOutToApplication()
        {
            LoginPage loginPage = new LoginPage(driver);
            loginPage.LoginApplication(TestContext.Parameters.Get("username"), TestContext.Parameters.Get("password"));
            System.Threading.Thread.Sleep(1000);
            //IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            //executor.ExecuteScript("document.body.style.zoom = '0.8'");
            loginPage.logoutButton.Click();
            Assert.IsTrue(AssertClass.IsElementPresent(driver, loginPage.loginButton), "User not redirected to Login page");

        }
        [TearDown]
        public void CloseBrowser()
        {
            driver.Quit();
        }

    }
}
