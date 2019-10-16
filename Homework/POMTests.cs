using Homework.Pages;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace Homework
{
    [TestFixture]
    public class POMTests
    {
        private LoginPage _loginPage;
        private RegistrationPage _regPage;
        private RegistrationUser _user;
        private ChromeDriver _driver;

        [SetUp]
        public void CalssInit()
        {
            _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            _driver.Manage().Window.Maximize();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            _loginPage = new LoginPage(_driver);
            _regPage = new RegistrationPage(_driver);

            _user = UserFactory.CreateValidUser();
        }

        [Test]
        public void FillRegistrationFormWithoutFirstName()
        {
            _user.FirstName = "";

            _regPage.Navigate(_loginPage);
            _regPage.FillForm(_user);

            _regPage.AssertErrorMessage("firstname is required.");
        }

        [Test]
        public void FillRegistrationFormWithoutLastName()
        {
            _user.LastName = "";

            _regPage.Navigate(_loginPage);
            _regPage.FillForm(_user);

            _regPage.AssertErrorMessage("lastname is required.");
        }

        [Test]
        public void FillRegistrationFormWithoutPassword()
        {
            _user.Password = "";

            _regPage.Navigate(_loginPage);
            _regPage.FillForm(_user);

            _regPage.AssertErrorMessage("passwd is required.");
        }

        [Test]
        public void FillRegistrationFormWithoutPhoneNumber()
        {
            _user.Phone = "";

            _regPage.Navigate(_loginPage);
            _regPage.FillForm(_user);

            _regPage.AssertErrorMessage("You must register at least one phone number.");
        }

        [Test]
        public void FillRegistrationFormWithoutCity()
        {
            _user.City = "";

            _regPage.Navigate(_loginPage);
            _regPage.FillForm(_user);

            _regPage.AssertErrorMessage("city is required.");
        }

        [Test]
        public void FillRegistrationFormWithoutAddress()
        {
            _user.Address = "";

            _regPage.Navigate(_loginPage);
            _regPage.FillForm(_user);

            _regPage.AssertErrorMessage("address1 is required.");
        }

        [Test]
        public void FillRegistrationFormWithInvalidPostCode()
        {
            _user.PostCode = "1234";

            _regPage.Navigate(_loginPage);
            _regPage.FillForm(_user);

            _regPage.AssertErrorMessage("The Zip/Postal code you've entered is invalid. It must follow this format: 00000");
        }

        [Test]
        public void FillRegistrationFormWithInvalidPostCodeAndWithoutAddress()
        {
            _user.PostCode = "1234";
            _user.Address = "";

            _regPage.Navigate(_loginPage);
            _regPage.FillForm(_user);

            _regPage.AssertErrorMessage("address1 is required.");
           // _regPage.AssertErrorMessage("The Zip/Postal code you've entered is invalid. It must follow this format: 00000");
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}
