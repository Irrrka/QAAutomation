namespace IntegrationTests.Models
{
    using Newtonsoft.Json;

    public partial class ResponseAuthor
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("age")]
        public long Age { get; set; }

        [JsonProperty("genre")]
        public string Genre { get; set; }
    }

    public partial class ResponseAuthor
    {
        public static ResponseAuthor FromJson(string json) => JsonConvert.DeserializeObject<ResponseAuthor>(json, IntegrationTests.Models.Converter.Settings);
    }

   
}
