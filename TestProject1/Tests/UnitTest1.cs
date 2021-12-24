using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using TestProject1.CustomMethods;
using TestProject1.PageObjects;

namespace TestProject1.Tests
{
    public class Tests1:ExtentReportClass

    {
        public TestContext TestContext { get; set; }
        public IWebDriver driver;

        

        [Test]
        public void Test1()
        {
            driver = GetDriver();
            //driver = new ChromeDriver();
            //driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://github.com/");
            //string str=TestContext.Parameters.Get("username");
            //ScreenShotsClass.FailedTestCaptureScreenShot(driver,"Login");
            //driver.Quite(0);
            Assert.Fail("Tes");

        }
        
    }
}