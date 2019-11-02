using Homework;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class Tests : BaseTest
    {
        long householdId = 0;
        string[] userEmails = { "pesho@gmail.com", "ralitsa@abv.bg" };
        string[] firstNames = { "Pesho", "Ralitsa" };
        string[] lastNames = { "Peshev", "Kirilova" };
        List<User> users = new List<User>();
        List<long> wishlistIds = new List<long>();
        Random random = new Random();

        [Test]
        [Order(1)]
        public async Task CreateHouseholds()
        {
            var requestHousehold = new Household { Name = "Bibliotekata" };
            var content = new StringContent(requestHousehold.ToJson(), Encoding.UTF8, "application/json");
            var response = await Client.PostAsync("/households", content);
            response.EnsureSuccessStatusCode();
            var responseAsString = await response.Content.ReadAsStringAsync();

            var household = Household.FromJson(responseAsString);
            householdId = household.Id;
            Assert.AreEqual(householdId, 13);
        }

        [Test]
        [Order(2)]
        public async Task CreateUsers()
        {
            for (int i = 0; i < 2; i++)
            {
                var userToRequest = new User
                {
                    Email = userEmails[i],
                    FirstName = firstNames[i],
                    LastName = lastNames[i],
                    HouseholdId = householdId,
                };
                
                var content = new StringContent(userToRequest.ToJson(), Encoding.UTF8, "application/json");

                var response = await Client.PostAsync("/users", content);
                response.EnsureSuccessStatusCode();
                var responseAsString = await response.Content.ReadAsStringAsync();

                var user = User.FromJson(responseAsString);
                users.Add(user);
                users.ForEach(u => wishlistIds.Add(u.WishlistId));
            }
            Assert.AreEqual(users.Count(u=>u.HouseholdId == householdId), 2);
        }

        [Test]
        [Order(3)]
        public async Task AddBooksToUsers()
        {
            foreach (var user in users)
            {
                var responseBooks = await Client.GetAsync("/books");
                responseBooks.EnsureSuccessStatusCode();
                var responseBooksAsString = await responseBooks.Content.ReadAsStringAsync();

                Book[] books = Book.FromJson(responseBooksAsString);
                var bookId = books[random.Next(0, books.Length)].Id;
                var request = new HttpRequestMessage(HttpMethod.Post, $"/wishlists/{user.WishlistId}/books/{bookId}");
                
                var response = await Client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            }
        }

        [Test]
        [Order(4)]
        public async Task GetAllWishlistsForHousehold()
        {
            var response = await Client.GetAsync($"/households/{householdId}/wishlistBooks");
            response.EnsureSuccessStatusCode();
            var responseAsString = await response.Content.ReadAsStringAsync();
            var books = Book.FromJson(responseAsString);
            Assert.AreNotEqual(books.Length, 0);
        }

    }
}