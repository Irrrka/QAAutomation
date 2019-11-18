using System;
using System.Collections.Generic;
using System.Text;
using Homework.Pages.SecondTask;
using OpenQA.Selenium;

namespace Homework.Pages.AccordionPage
{
    public partial class AccordionPage : BasePage
    {
        public AccordionPage(IWebDriver driver) : base(driver)
        {
        }

        public void NavigateToAccordionPage(IndexPage indexPage)
        {
            indexPage.Navigate("http://demoqa.com/");
            indexPage.AccordionButton.Click();
        }
    }
}
