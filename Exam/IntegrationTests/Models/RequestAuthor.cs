using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationTests.Models
{
    using Newtonsoft.Json;

    public partial class RequestAuthor
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("genre")]
        public string Genre { get; set; }

        //[JsonProperty("dateOfBirth")]
        //public string DateOfBirth { get; set; }
    }
}
