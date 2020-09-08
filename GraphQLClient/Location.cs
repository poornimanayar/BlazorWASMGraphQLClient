namespace GraphQLClient {

    using System;
    using Newtonsoft.Json;

    public class Location {

        [JsonProperty("column")]
        public Int32 Column { get; set; }

        [JsonProperty("line")]
        public Int32 Line { get; set; }

        public Location() {

        }
    }
}
