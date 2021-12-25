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
    public class LoginTests:ExtentReportClass
    {
        
        public TestContext TestContext { get; set; }
        
        [Test]
        public void VerifyValidLoginToApplication()
        {
            LoginPage loginPage = new LoginPage(driver);
            string username = TestContext.Parameters.Get("username");
            string password = TestContext.Parameters.Get("password");
            loginPage.LoginApplication(username,password);
            Assert.IsTrue(AssertClass.IsElementPresent(driver, loginPage.logoutButton), "User not on home page");
                  
        }
        [Test]
        public void VerifyInValidLoginToApplication()
        {
            LoginPage loginPage = new LoginPage(driver);
            loginPage.LoginApplication(TestContext.Parameters.Get("username"), TestContext.Parameters.Get("wrongPassword"));
            System.Threading.Thread.Sleep(10000);
            Assert.IsTrue(AssertClass.IsElementPresent(driver, loginPage.invalidError), "No Error Found");

        }
        [Test]
        public void VerifyLogOutToApplication()
        {
            LoginPage loginPage = new LoginPage(driver);
            loginPage.LoginApplication(TestContext.Parameters.Get("username"), TestContext.Parameters.Get("password"));
            loginPage.logoutButton.Click();
            Assert.IsTrue(AssertClass.IsElementPresent(driver, loginPage.loginButton), "User not redirected to Login page");

        }
        

    }
}
