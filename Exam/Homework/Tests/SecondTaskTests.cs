using NUnit.Framework;
using OpenQA.Selenium;


namespace Homework.Tests
{
    [TestFixture]
    public class SecondTaskTests : BaseTest
    {
        [Test]
        public void SectionsHaveAnArrowTests()
        {
            AccordionPage.NavigateToAccordionPage(IndexPage);

            foreach (var  arrow in AccordionPage.Arrows)
            {
                Assert.IsNotNull(arrow);
            }
        }

        [Test]
        [TestCase("Section1")]
        [TestCase("Section2")]
        [TestCase("Section3")]
        [TestCase("Section4")]
        public void OpenSectionsTests(string testCase)
        {
            AccordionPage.NavigateToAccordionPage(IndexPage);

            //TODO Bonus
            //TODO Navigate Only once

            switch (testCase)
            {
                case "Section1":
                    //AccordionPage.AccordionSection1Arrow.Click();
                    Assert.AreEqual("true", AccordionPage.AccordionSection1AreaExpandedAttr);
                    Assert.AreEqual("false", AccordionPage.AccordionSection2AreaExpandedAttr);
                    Assert.AreEqual("false", AccordionPage.AccordionSection3AreaExpandedAttr);
                    Assert.AreEqual("false", AccordionPage.AccordionSection4AreaExpandedAttr);
                    break;
                case "Section2":
                    AccordionPage.AccordionSection2Arrow.Click();
                    Assert.AreEqual("false", AccordionPage.AccordionSection1AreaExpandedAttr);
                    Assert.AreEqual("true", AccordionPage.AccordionSection2AreaExpandedAttr);
                    Assert.AreEqual("false", AccordionPage.AccordionSection3AreaExpandedAttr);
                    Assert.AreEqual("false", AccordionPage.AccordionSection4AreaExpandedAttr);
                    break;
                case "Section3":
                    AccordionPage.AccordionSection3Arrow.Click();
                    Assert.AreEqual("false", AccordionPage.AccordionSection1AreaExpandedAttr);
                    Assert.AreEqual("false", AccordionPage.AccordionSection2AreaExpandedAttr);
                    Assert.AreEqual("true", AccordionPage.AccordionSection3AreaExpandedAttr);
                    Assert.AreEqual("false", AccordionPage.AccordionSection4AreaExpandedAttr);
                    break;
                case "Section4":
                    AccordionPage.AccordionSection4Arrow.Click();
                    Assert.AreEqual("false", AccordionPage.AccordionSection1AreaExpandedAttr);
                    Assert.AreEqual("false", AccordionPage.AccordionSection2AreaExpandedAttr);
                    Assert.AreEqual("false", AccordionPage.AccordionSection3AreaExpandedAttr);
                    Assert.AreEqual("true", AccordionPage.AccordionSection4AreaExpandedAttr);
                    break;
                default:
                    break;
            }





        }
    }
}
