using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace Homework.Pages.CoreGuidePage
{
    public partial class GuidePage
    {
        public IWebElement Tab => Driver.FindElement(By.XPath("//*[@id='affixed-left-container']/ul/li[17]/span"));
        public IWebElement SubTab => Driver.FindElement(By.XPath("//*[@id='affixed-left-container']/ul/li[17]/ul/li[4]/a"));

        public IWebElement VoteSection => Driver.FindElements(By.TagName("h3"))
                        .FirstOrDefault(t => t.Text == "Is this page helpful?")
                        .FindElement(By.XPath("//*[@class='icon docon docon-like']"))
                        .FindElement(By.XPath("./.."));

        public IWebElement VotePositiveButton => Driver.FindElement(By.XPath("//*[@id='affixed-right-container']/div/div[1]/div/div/button[1]"));

        public IWebElement FeedBackInput => Wait.Until(d=>d.FindElement(By.XPath("//*[@id='rating-feedback-mobile']")));
        public IWebElement FeedbackSubmit => Driver.FindElement(By.XPath("//*[@id='affixed-right-container']/div/div[1]/form/div[2]/button[2]"));
        public IWebElement FeedbackSkip => Driver.FindElement(By.XPath("//*[@id='affixed-right-container']/div/div[1]/form/div[2]/button[1]"));
        public IWebElement FeedbackMessage => Wait.Until(d => d.FindElement(By.XPath("//*[@class='thankyou-rating']/p")));

        public IWebElement Sublinks => Driver.FindElement(By.Id("side-doc-outline"));

        public List<IWebElement> headers => Driver.FindElements(By.TagName("h2")).ToList();

    }
}
