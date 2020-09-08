namespace GraphQLClient {

    using System;
    using System.Threading.Tasks;

    public interface IGraphQLService {

        Task<Root<T>> SendRequest<T>(String graphQLEndpoint, Object graphQLQueryOrMutation) where T : class, new();
    }
}
