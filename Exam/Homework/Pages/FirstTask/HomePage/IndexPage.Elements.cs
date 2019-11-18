using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Homework.Pages.SecondTask
{
    public partial class NetPage : BasePage
    {

        //*[@id="dotnetguides"]/li[2]/div/div/div/div[2]/h3/a
        public IWebElement CoreGuide => Driver.FindElement(By.XPath("//*[@id='dotnetguides']/li[2]/div/div/div/div[2]/h3/a"));
    }
}
