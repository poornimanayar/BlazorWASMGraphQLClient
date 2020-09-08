namespace BlazorGraphQLClient.Model {

    using System;
    using Newtonsoft.Json;

    public class Flag {

        [JsonProperty("svgFile")]
        public String SvgFile { get; set; }

        public Flag() {
        }
    }
}
