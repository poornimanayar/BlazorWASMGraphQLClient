namespace BlazorGraphQLClient.Model {

    using System;
    using Newtonsoft.Json;

    public class Country {

        [JsonProperty("capital")]
        public String Capital { get; set; }

        [JsonProperty("flag")]
        public Flag Flag { get; set; }

        [JsonProperty("name")]
        public String Name { get; set; }

        public Country() {
        }
    }
}
