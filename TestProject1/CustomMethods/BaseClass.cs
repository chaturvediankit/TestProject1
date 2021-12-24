using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace TestProject1.CustomMethods
{
    public class BaseClass
    {
        // Tears down test and throws exception
        public static void CloseTest(IWebDriver driver)
        {
            try
            {
                driver.Quit();
                Process[] chromeDriverProcesses = Process.GetProcessesByName("chromedriver");

                foreach (var chromeDriverProcess in chromeDriverProcesses)
                {
                    chromeDriverProcess.Kill();
                }
                Console.WriteLine("Test Completes successfully");
            }
            catch (WebDriverException testClosingException)
            {
                Console.WriteLine("Driver Failed to close the browser: {0}", testClosingException.Message);
            }

        }

        // custom method for entering a text in to a field
        public static void EnterText(IWebElement element, string value)
        {
            element.Click();
            element.Clear();
            element.SendKeys(value);
        }
        // Custom Method for Selecting from a dropdown
        public void SelectFromDropDownByText(IWebElement element, string inputText)
        {
            SelectElement se = new SelectElement(element);
            se.SelectByText(inputText);
        }
        // Custom Method for Selecting from a dropdown using value
        public static void SelectFromDropDownByValue(IWebElement element, string inputValue)
        {
            SelectElement se = new SelectElement(element);
            se.SelectByValue(inputValue);
        }
        // Custom Method for Selecting from a dropdown using Index
        public static void SelectFromDropDownByIndex(IWebElement element, int index)
        {
            SelectElement se = new SelectElement(element);
            se.SelectByIndex(index);
        }
        // Custom Method for Drag and drop. we need to specify the origin element and destination elements
        public static void DragAndDropItem(IWebDriver driver,IWebElement sourceElement, IWebElement destinationElement)
        {
            Actions action = new Actions(driver);
            action.ClickAndHold(sourceElement).MoveToElement(destinationElement).Release().Build().Perform();
        }

        public static void ActionClick(IWebDriver driver, IWebElement Element)
        {
            Actions action = new Actions(driver);
            action.MoveToElement(Element).Build().Perform();
        }
        public void ActionHoverAndClick(IWebDriver driver,IWebElement ElementHover, IWebElement ElementClick)
        {
            Actions action = new Actions(driver);
            action.MoveToElement(ElementHover);
            action.MoveToElement(ElementClick);
            action.Click().Build().Perform();
            
        }

        public static void ScrollintoView(IWebDriver driver,IWebElement Element)
        {
            IJavaScriptExecutor js = driver as IJavaScriptExecutor;
            // Run the javascript command 'scrollintoview on the element
            js.ExecuteScript("arguments[0].scrollIntoView(true);", Element);
        }
        public static void Thinktime(int Time)
        {
            System.Threading.Thread.Sleep(Time * 1000);
        }



    }
}
