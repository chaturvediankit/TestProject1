using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject1.PageObjects
{
    public class DashboardPage
    {
        IWebDriver driver;
        public DashboardPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        public IWebElement accountsLink=> driver.FindElement(By.XPath("//*[contains(text(),'Accounts')]"));
        public IWebElement customersLink => driver.FindElement(By.XPath("//a[text()='Customers']"));
    }
}
