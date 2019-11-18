using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Homework.Extensions
{
    public static class ElementExtension
    {
        public static void Type(this IWebElement element, string value)
        {
            element.Clear();
            element.SendKeys(value);
        }

        public static void Hover(this IWebElement element, IWebDriver driver)
        {
            var action = new Actions(driver);
            action.MoveToElement(element).Perform();
        }

        public static void RightClick(this IWebElement element, IWebDriver driver)
        {
            var action = new Actions(driver);
            action.ContextClick(element).Perform();
        }

        public static void DragAndDrop(this IWebElement element, IWebDriver driver, int x, int y)
        {
            var action = new Actions(driver);
            action
                .MoveToElement(element)
                .ClickAndHold()
                .MoveByOffset(x, y)
                .Release()
                .Perform();
        }
    }
}
