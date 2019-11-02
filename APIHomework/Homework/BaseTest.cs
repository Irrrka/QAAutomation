using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Homework
{
    public class BaseTest
    {
        public HttpClient Client;

        [SetUp]
        public void Setup()
        {
            Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:3000/");
            Client.DefaultRequestHeaders.Add("G-Token", "ROM831ESV");
        }

    }
}
