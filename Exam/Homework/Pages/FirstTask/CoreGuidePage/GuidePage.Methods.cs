using System;
using System.Collections.Generic;
using System.Text;
using Homework.Pages.SecondTask;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Homework.Pages.CoreGuidePage
{
    public partial class GuidePage : BasePage
    {
        public GuidePage(IWebDriver driver) : base(driver)
        {
        }

        public void NavigateToArticle(IWebElement tab)
        {
            this.ScrollTo(tab);
            tab.Click();
        }

        public void NavigateToSubArticle(IWebElement subTab)
        {
            this.ScrollTo(subTab);
            subTab.Click();
        }

        public void MoveTo(int x, int y)
        {
            var action = new Actions(Driver);
            action.MoveByOffset(x,y).Perform();
        }

        public void MoveToElement(IWebElement element)
        {
            var action = new Actions(Driver);
            action.MoveToElement(element).Perform();
        }

        public void ScrollTo(IWebElement element)
        {
            ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);

        }
        public void ScrollBelowNavigation()
        {
            ((IJavaScriptExecutor)Driver).ExecuteScript("window.scrollBy(0, -100)");
        }

        public void ScrollToTop()
        {
            ((IJavaScriptExecutor)Driver).ExecuteScript("window.scrollTo(0, 0)");
        }

        public double GetPosition
        {
            get
            {
                IJavaScriptExecutor executor = (IJavaScriptExecutor)Driver;
                var value = Convert.ToDouble(executor.ExecuteScript("return window.pageYOffset;"));
                return value;
            }
        }
    }
}
