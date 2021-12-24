using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TestProject1.CustomMethods;

namespace TestProject1.PageObjects
{
    public class AddCustomerPage
    {
        IWebDriver driver;
        public TestContext TestContext { get; set; }
        public AddCustomerPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        public IWebElement firstNameTxtField => driver.FindElement(By.Name("fname"));
        public IWebElement lastNameTxtField => driver.FindElement(By.Name("lname"));
        public IWebElement emailTxtField => driver.FindElement(By.Name("email"));
        public IWebElement passwordTxtField => driver.FindElement(By.Name("password"));
        public IWebElement mobileNumTxtField => driver.FindElement(By.Name("mobile"));
        public IWebElement countryDropDown => driver.FindElement(By.XPath("//span[@class='select2-arrow']"));
        public IWebElement selectCountry => driver.FindElement(By.XPath("//div[text()='India']"));
        public IWebElement adress1TextField => driver.FindElement(By.Name("address1"));
        public IWebElement submitButton => driver.FindElement(By.XPath("//button[text()='Submit']"));
        public IWebElement currencyDropDown => driver.FindElement(By.Name("currency"));
        public IWebElement balanceTxtField => driver.FindElement(By.Name("balance"));

        public void AddCustomer()
        {
            try
            {
                firstNameTxtField.SendKeys(TestContext.Parameters.Get("customerFirstName"));
                lastNameTxtField.SendKeys(TestContext.Parameters.Get("customerLastName"));
                emailTxtField.SendKeys(TestContext.Parameters.Get("customerEmail"));
                passwordTxtField.SendKeys(TestContext.Parameters.Get("customerPassword"));
                mobileNumTxtField.SendKeys("0123456789");
                countryDropDown.Click();
                selectCountry.Click();
                adress1TextField.SendKeys("Bengaluru");
                BaseClass baseClass = new BaseClass();
                baseClass.SelectFromDropDownByText(currencyDropDown,"INR");
                balanceTxtField.SendKeys("1200");
                submitButton.Click();

            }
            catch(Exception e)
            {
                Assert.Fail("Not able to Submit Form");
                driver.Quit();

            }

        }

    }
}
