using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject1.CustomMethods
{
    public class AssertClass
    {
        // Makes sure that the test case will not fail unless its absolutely necessary.Returns a true or false to AssertElement is Presesent Method
        public static bool IsElementPresent(IWebDriver driver,IWebElement element)
        {
            bool Present = false;
            try
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
                if (element.Displayed)
                {
                    Present = true;
                    Console.WriteLine("Element Is Seen");
                }

                else
                {
                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
                    if (element.Displayed)
                    {
                        Present = true;
                    }
                }
                return Present;
            }
            catch (NoSuchElementException ex)
            {
                Console.WriteLine("No Such Element : {0}", ex.Message);
                Assert.Fail("No Such Element");
                return false;
            }
        }

        // Checks for Text and confirms its a match
        public static void ContainsText(IWebElement element, string neededText)
        {
            string actualText = element.Text;
            try
            {
                if (actualText.Contains(neededText))
                {
                    Console.WriteLine("Text Matched");
                }
                else
                    Assert.Fail("Text mismatch");
            }
            catch (Exception e)
            {
                Console.WriteLine("Text Mismatched : {0}", e.Message);
                throw e;
            }
        }
    }
}
