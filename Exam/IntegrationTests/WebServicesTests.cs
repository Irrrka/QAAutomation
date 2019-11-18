namespace IntegrationTests
{
    using FluentAssertions;
    using IntegrationTests.Models;
    using NUnit.Framework;
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;

    [TestFixture]
    public class WebServicesTests : BaseTest
    {
        [Test]
        public async Task IndependentAuthorTests_WithValidData_ShouldReturnSuccess()
        {
            //POST Author

            var author = new RequestAuthor
            {
                FirstName = "FirstName-Irrrka",
                LastName = "LastName-Irrrka",
                Genre = "Genre-Irrrka"
            };

            var expectedAuthor = new ResponseAuthor
            {
                Name = "FirstName-Irrrka LastName-Irrrka",
                Genre = "Genre-Irrrka",
                Age = 2018
            };

            var content = new StringContent(author.ToJson(), Encoding.UTF8, "application/json");

            var response = await _client.PostAsync("/api/authors/", content);
            response.EnsureSuccessStatusCode();
            var responseAsString = await response.Content.ReadAsStringAsync();
            var actualAuthor = ResponseAuthor.FromJson(responseAsString);

            Assert.AreEqual(expectedAuthor.Name, actualAuthor.Name, "Post Author not working properly!");
            Assert.AreEqual(expectedAuthor.Genre, actualAuthor.Genre, "Post Author not working properly!");
            Assert.AreEqual(expectedAuthor.Age, actualAuthor.Age, "Post Author not working properly!");
            expectedAuthor.Id = actualAuthor.Id.ToString();
            Assert.IsNotNull(actualAuthor.Id, "Post Author not working properly!");

            //GETAuthor

            var responseGet = await _client.GetAsync($"/api/authors/{expectedAuthor.Id}");
            responseGet.EnsureSuccessStatusCode();

            var contentGet = await response.Content.ReadAsStringAsync();
            var actualGetAuthor = ResponseAuthor.FromJson(contentGet);

            Assert.AreEqual(expectedAuthor.Name, actualGetAuthor.Name, "Get Author not working properly!");
            Assert.AreEqual(expectedAuthor.Age, actualGetAuthor.Age, "Get Author not working properly!");
            Assert.AreEqual(expectedAuthor.Genre, actualGetAuthor.Genre, "Get Author not working properly!");

            //DELETEAuthor

            var responseDelete = await _client.DeleteAsync($"/api/authors/{expectedAuthor.Id}");
            responseDelete.EnsureSuccessStatusCode();

            Assert.AreEqual(responseDelete.StatusCode, HttpStatusCode.NoContent, "Delete Author not working properly!");
        }

    }
}
