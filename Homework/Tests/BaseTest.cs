using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace Homework.Tests
{
    [TestFixture]
    public class BaseTest
    {
        public IWebDriver _driver { get; private set; }

        [OneTimeSetUp]
        public void Initialize()
        {
            _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            _driver.Manage().Window.Maximize();
        }

        [OneTimeTearDown]
        public void CleanUp()
        {
            _driver.Quit();
        }
    }
}
