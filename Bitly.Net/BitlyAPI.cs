using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Bitly.Net
{
    public class BitlyAPI
    {
        private string BitlyApi = @"https://api-ssl.bitly.com/shorten?access_token={0}&longUrl={1}";
        public string ACCESS_TOKEN { get; set; }
        public BitlyAPI()
        {
        }

        /// <summary>
        /// Create new Bitly object with access token
        /// </summary>
        /// <param name="access_token"></param>
        public BitlyAPI(string access_token)
        {
            ACCESS_TOKEN = access_token;
        }

        /// <summary>
        /// Check Access Token using synchronous method
        /// </summary>
        /// <returns></returns>
        public bool CheckAccessToken()
        {
            if (string.IsNullOrEmpty(ACCESS_TOKEN))
                return false;
            string temp = string.Format(BitlyApi, ACCESS_TOKEN, "google.com");
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage res = client.GetAsync(temp).Result;
                return res.IsSuccessStatusCode;
            }
        }

        /// <summary>
        /// Check Access Token using asynchronous
        /// </summary>
        /// <returns></returns>
        public async Task<bool> CheckAccessTokenAsync()
        {
            return await Task.Run(() => CheckAccessToken());
        }

        /// <summary>
        /// Shortern long URL using synchronous
        /// </summary>
        /// <param name="long_url"></param>
        /// <returns></returns>
        public string Shorten(string long_url)
        {
            if (CheckAccessToken())
            {
                using (HttpClient client = new HttpClient())
                {
                    string temp = string.Format(BitlyApi, ACCESS_TOKEN, WebUtility.UrlEncode(long_url));
                    var res = client.GetAsync(temp).Result;
                    if (res.IsSuccessStatusCode)
                    {
                        var message = res.Content.ReadAsStringAsync().Result;
                        dynamic obj = JsonConvert.DeserializeObject(message);
                        return obj.results[long_url].shortUrl;
                    }
                    else
                    {
                        return "Can not short URL";
                    }
                }
            }
            else
            {
                return "Can not short URL";
            }
        }

        /// <summary>
        /// Shortern long URL using asynchronous
        /// </summary>
        /// <param name="long_url"></param>
        /// <returns></returns>
        public async Task<string> ShortenAsync(string long_url)
        {
            return await Task.Run(() => Shorten(long_url));
        }
    }
}
