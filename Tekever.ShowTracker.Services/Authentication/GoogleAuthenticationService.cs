using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using Tekever.ShowTracker.Services.Interfaces;

namespace Tekever.ShowTracker.Services.Authentication
{
	public class GoogleAuthenticationService : IGoogleAuthenticationService
	{

        private readonly HttpClient _client = new();
        private readonly IConfiguration _config;

        public GoogleAuthenticationService(IConfiguration config)
        {
            _config = config;
        }

        public async Task<string> Authentication()
        {

            var uriBuilder = new UriBuilder();


            uriBuilder.Host = _config["openIdProvider:host"];
            uriBuilder.Path = _config["openIdProvider:path"];
            uriBuilder.Scheme = "http";
            var uri = uriBuilder.Uri;

            uri = uri.AddParameter("response_type", _config["openIdProvider:response_type"]);
            uri = uri.AddParameter("client_id", _config["openIdProvider:client_id"]);
            uri = uri.AddParameter("scope", _config["openIdProvider:scope"]);
            uri = uri.AddParameter("redirect_uri", _config["openIdProvider:redirect_uri"]);
            uri = uri.AddParameter("nonce", _config["openIdProvider:nonce"]);

            return uri.ToString();
        }

        public async Task<string> GetIdToken(string authCode)
        {
            var baseURI = $"https://{_config["openIdProvider:openIdApi"]}/token";

            var content = new Dictionary<string, string?>
            {
                { "code", authCode },
                { "client_id", _config["openIdProvider:client_id"] },
                { "client_secret", _config["openIdProvider:client_secret"] },
                { "redirect_uri", _config["openIdProvider:redirect_uri"] },
                { "grant_type", "authorization_code" }
            };
            var values = new FormUrlEncodedContent(content);

            var response = await _client.PostAsync(baseURI, values);

            var idToken = JObject.Parse((await response.Content.ReadAsStringAsync()))["id_token"].ToString();

            return idToken;
        }
    }
}
