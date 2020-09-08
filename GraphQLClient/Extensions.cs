namespace GraphQLClient {

    using System;
    using Newtonsoft.Json;

    public class Extensions {

        [JsonProperty("code")]
        public String Code { get; set; }

        public Extensions() {
        }
    }
}
