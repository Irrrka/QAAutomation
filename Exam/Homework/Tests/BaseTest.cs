using Homework.Pages.AccordionPage;
using Homework.Pages.CoreGuidePage;
using Homework.Pages.SecondTask;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Reflection;


namespace Homework.Tests
{
    [TestFixture]
    public class BaseTest
    {
        public IWebDriver Driver { get; protected set; }
        public IndexPage IndexPage { get; private set; }
        public AccordionPage AccordionPage { get; private set; }

        public NetPage NetPage { get; private set; }
        public GuidePage GuidePage { get; private set; }

        [OneTimeSetUp]
        public void StartUp()
        {
            Driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            Driver.Manage().Window.Maximize();
           // Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            IndexPage = new IndexPage(Driver);
            AccordionPage = new AccordionPage(Driver);

            NetPage = new NetPage(Driver);
            GuidePage = new GuidePage(Driver);
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            //if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            //{
            //    var screenshot = ((ITakesScreenshot)Driver).GetScreenshot();
            //    var path = Path.GetFullPath(Directory.GetCurrentDirectory()
            //                          + @"\..\..\..\Screenshots\") +
            //                          TestContext.CurrentContext.Test.Name + ".png";
            //    screenshot.SaveAsFile(path, ScreenshotImageFormat.Png);
            //}

            Driver.Quit();
        }
    }
}
