using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YnabRestApi {
    public static class ApiClientFactory {
        /// <summary>
        /// Creates an client for calling the YNAB REST API.
        /// </summary>
        /// <param name="accessToken">The API access token.</param>
        /// <returns>An API client.</returns>
        public static YnabApi Create(string accessToken, Func<HttpClient> httpClientSource = null) {
            return Create(accessToken, "https://api.youneedabudget.com/v1", httpClientSource);
        }

        /// <summary>
        /// Creates an client for calling the YNAB REST API.
        /// </summary>
        /// <param name="accessToken">The API access token.</param>
        /// <param name="hostUrl">The base address of the YNAB REST API.</param>
        /// <returns>An API client.</returns>
        public static YnabApi Create(string accessToken, string hostUrl, Func<HttpClient> httpClientSource = null) {
            var refitSettings = new RefitSettings();
            //DefaultContractResolver defaultContractResolver = new DefaultContractResolver();
            //refitSettings.ContentSerializer = defaultContractResolver;

            HttpClient httpClient = httpClientSource != null ? httpClientSource() : new HttpClient();
            httpClient.BaseAddress = new Uri(hostUrl);
            httpClient.DefaultRequestHeaders.Add("Authorization", "BEARER " + accessToken);

            return RestService.For<YnabApi>(httpClient, refitSettings);
        }
    }
}
