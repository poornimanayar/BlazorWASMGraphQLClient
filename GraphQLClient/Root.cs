namespace GraphQLClient {

    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class Root<T> where T : class, new() {

        [JsonProperty("data")]
        public T Data { get; set; }

        [JsonProperty("errors")]
        public IList<GraphQLError> Errors { get; set; }

        [JsonIgnore]
        public Exception Exception { get; set; }

        [JsonIgnore]
        public Boolean HasData { get { return this.Data != null; } }

        [JsonIgnore]
        public Boolean HasErrors { get { return this.Errors != null; } }

        [JsonIgnore]
        public Boolean HasException { get { return this.Exception != null; } }

        public Root() {
        }
    }
}
