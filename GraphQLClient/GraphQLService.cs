namespace GraphQLClient {

    using System;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json;

    public class GraphQLService : IGraphQLService  {
        readonly HttpClient _httpClient;

        public GraphQLService(HttpClient httpClient) {
            if (httpClient is null) {
                throw new ArgumentNullException(nameof(httpClient));
            }
            _httpClient = httpClient;
        }

        public async Task<Root<T>> SendRequest<T>(String graphQLEndpoint, Object graphQLQueryOrMutation) where T : class, new() {
            if (String.IsNullOrWhiteSpace(graphQLEndpoint)) {
                throw new ArgumentException($"'{nameof(graphQLEndpoint)}' cannot be null or whitespace", nameof(graphQLEndpoint));
            }

            if (graphQLQueryOrMutation is null) {
                throw new ArgumentNullException(nameof(graphQLQueryOrMutation));
            }

            try {
                var request = new HttpRequestMessage {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri(graphQLEndpoint),
                    Content = new StringContent(JsonConvert.SerializeObject(graphQLQueryOrMutation), Encoding.UTF8, "application/json")
                };
                // https://docs.microsoft.com/en-us/aspnet/core/blazor/call-web-api?view=aspnetcore-3.1
                var response = await _httpClient.SendAsync(request);
                var json = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<Root<T>>(json);
                return data;
            } catch (Exception ex) {
                var data = new Root<T>() { Exception = ex };
                return data;
            }
        }
    }
}
