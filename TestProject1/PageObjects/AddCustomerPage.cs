using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject1.PageObjects
{
    public class AddCustomerPage
    {
        IWebDriver driver;
        public AddCustomerPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        public IWebElement addButton => driver.FindElement(By.XPath("//button[@type='submit']"));

    }
}
