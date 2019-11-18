using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Homework.Pages.SecondTask
{
    public partial class IndexPage : BasePage
    {
        //public string Url => "http://demoqa.com/";

        public IWebElement AccordionButton => Wait.Until(d => d.FindElements(By.XPath("//*[@id='sidebar']//ul/li/a"))
                .FirstOrDefault(a => a.Text == "Accordion"));

        
    }
}
