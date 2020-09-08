namespace BlazorGraphQLClient.Model {

    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class Data {

        [JsonProperty("country")]
        public List<Country> Country { get; set; }

        public Data() {
        }
    }
}
