using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace Homework.Pages.AccordionPage
{
    public partial class AccordionPage
    {
        public IWebElement AccordionSection1Arrow => Wait.Until(d => d.FindElement(By.XPath(@"//*[@id='ui-id-1']/span")));
        public IWebElement AccordionSection2Arrow => Wait.Until(d => d.FindElement(By.XPath(@"//*[@id='ui-id-3']/span")));
        public IWebElement AccordionSection3Arrow => Wait.Until(d => d.FindElement(By.XPath(@"//*[@id='ui-id-5']/span")));
        public IWebElement AccordionSection4Arrow => Wait.Until(d => d.FindElement(By.XPath(@"//*[@id='ui-id-7']/span")));

        public List<IWebElement> Arrows => Driver.FindElements(By.TagName("h3"))
                                .Where(el=>el.GetAttribute("role") == "tab").ToList();
        public string AccordionSection1AreaExpandedAttr => Wait.Until(d => d.FindElement(By.XPath(@"//*[@id=""ui-id-1""]")).GetAttribute("aria-expanded"));
        public string AccordionSection2AreaExpandedAttr => Wait.Until(d => d.FindElement(By.XPath(@"//*[@id=""ui-id-3""]")).GetAttribute("aria-expanded"));
        public string AccordionSection3AreaExpandedAttr => Wait.Until(d => d.FindElement(By.XPath(@"//*[@id=""ui-id-5""]")).GetAttribute("aria-expanded"));
        public string AccordionSection4AreaExpandedAttr => Wait.Until(d => d.FindElement(By.XPath(@"//*[@id=""ui-id-7""]")).GetAttribute("aria-expanded"));
    }
}
