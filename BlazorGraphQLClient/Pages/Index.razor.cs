namespace BlazorGraphQLClient.Pages {

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using BlazorGraphQLClient.Model;
    using GraphQLClient;
    using Microsoft.AspNetCore.Components;

    public partial class Index {
        const String GraphQLEndPoint = "http://countries-274616.ew.r.appspot.com/";

        public Country Country { get; set; }

        public IList<CountryItem> CountryItems { get; set; }

        public String ExceptionMessage { get; set; }

        public IList<GraphQLError> GraphQLErrors { get; set; }

        public String SelectedCountryAlpha3Code { get; set; }

        [Inject]
        protected IGraphQLService GraphQLService { get; set; }

        public Index() {
            var list = new List<CountryItem>();
            list.Add(new CountryItem { Name = "United States", Alpha3Code = "USA" });
            list.Add(new CountryItem { Name = "Japan", Alpha3Code = "JPN" });
            list.Add(new CountryItem { Name = "Mexico", Alpha3Code = "MEX" });

            this.CountryItems = list;
            this.SelectedCountryAlpha3Code = list[0].Alpha3Code;
        }

        async void QueryGraphQLClicked(Boolean submitBadQuery = false) {
            ResetForm();

            var queryObject = new {
                query = @"query Country($alpha3Code: String!) {
                    Country(alpha3Code: $alpha3Code) {
                        name
                        capital
                        flag {
                            svgFile
                        }
                    }
                }",
                variables = $@"{{ ""alpha3Code"": ""{this.SelectedCountryAlpha3Code}"" }}"
            };

            if (submitBadQuery) {
                // note the name is now namex to simulate an invalid GraphQL query

                queryObject = new {
                    query = @"query Country($alpha3Code: String!) {
                    Country(alpha3Code: $alpha3Code) {
                        namex
                        capital
                        flag {
                            svgFile
                        }
                    }
                }",
                    variables = $@"{{ ""alpha3Code"": ""{this.SelectedCountryAlpha3Code}"" }}"
                };
            }

            Root<Data> result = await this.GraphQLService.SendRequest<Data>(GraphQLEndPoint, queryObject);

            if (result.HasData) {
                var country = result.Data.Country.Single();
                this.Country = country;
            } else if (result.HasErrors) {
                this.GraphQLErrors = result.Errors;
            } else if (result.HasException) {
                this.ExceptionMessage = result.Exception.Message;
            }
            await InvokeAsync(StateHasChanged);
        }

        void ResetForm() {
            this.Country = null;
            this.GraphQLErrors = null;
            this.ExceptionMessage = null;
        }
    }
}
