using IntegrationTests.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace IntegrationTests
{
    [TestFixture]
    public class BaseTest
    {
        protected HttpClient _client;
        //protected string _userId;
        //protected RequestAuthor _author;


        [SetUp]
        public void Setup()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://libexam2.azurewebsites.net/");

            //_author = new RequestAuthor
            //{
            //    FirstName = "FirstName-Irrrka",
            //    LastName = "LastName-Irrrka",
            //    Genre = "Genre-Irrrka"
            //};
        }
    }
}
