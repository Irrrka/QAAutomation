using Homework.Extensions;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Threading;

namespace Homework.Tests
{
    [TestFixture]
    public class FirstTastTests : BaseTest
    {
        [Test]
        public void NUnitArticleHaveSublinksTests()
        {
            NetPage.Navigate("https://docs.microsoft.com/en-us/dotnet/");
            NetPage.CoreGuide.Click();

            GuidePage.NavigateToArticle(GuidePage.Tab);
            GuidePage.NavigateToSubArticle(GuidePage.SubTab);

            var sublinks = GuidePage.Sublinks.FindElements(By.TagName("li"));
            Assert.AreEqual(sublinks.Count, 5);

            //Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

            for (int i = 0; i < sublinks.Count; i++)
            {
                var positionBefore = GuidePage.GetPosition;

                var link = sublinks[i].FindElement(By.TagName("a"));
                link.Click();

                var positionAfter = GuidePage.GetPosition;

                Assert.IsTrue(positionAfter>positionBefore);

                GuidePage.ScrollToTop();
            }

            //TODO Bonus
            //TODO Navigate Only once
        }

        [Test]
        public void NUnitPositiveVoteForSectionTests()
        {
            NetPage.Navigate("https://docs.microsoft.com/en-us/dotnet/");
            NetPage.CoreGuide.Click();

            GuidePage.NavigateToArticle(GuidePage.Tab);
            GuidePage.NavigateToSubArticle(GuidePage.SubTab);

            GuidePage.VotePositiveButton.Click();
            //GuidePage.FeedBackInput.Click();
            //GuidePage.FeedBackInput.Type("QAAutomationExam");
            GuidePage.FeedbackSkip.Click();


            var expectedText = "Thank you.";
            var actualText = GuidePage.FeedbackMessage.Text;
            Assert.AreEqual(expectedText, actualText);
        }
    }
}
