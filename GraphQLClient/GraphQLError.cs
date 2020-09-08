namespace GraphQLClient {

    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class GraphQLError {

        [JsonProperty("extensions")]
        public Extensions Extensions { get; set; }

        [JsonProperty("locations")]
        public List<Location> Locations { get; set; }

        [JsonProperty("message")]
        public String Message { get; set; }

        public GraphQLError() {
        }
    }
}
