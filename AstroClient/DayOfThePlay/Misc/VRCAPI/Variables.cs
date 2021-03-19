using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DayBots.VRCAPI
{
    public class Variables
    {
        public HttpClient HttpClient { get; set; }
        public HttpClientHandler HttpClientHandler { get; set; }
        public CookieContainer CookieContainer { get; set; }

        public string Auth { get; set; }
        public string AuthCookie { get; set; }
        public Classes.UserSelf Self { get; set; }
        public async Task<string> SendRequest(HTTPMethods method,string endpoint,Dictionary<string, string> Headers)
        {
            HttpClient.DefaultRequestHeaders.Clear();
            if (Headers != null)
            {
                foreach (var x in Headers)
                    HttpClient.DefaultRequestHeaders.Add(x.Key, x.Value);
            }
            var content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(Headers));
            HttpClient.DefaultRequestHeaders.Add("Cookie", "auth=" + AuthCookie);
            switch (method)
            {
                case HTTPMethods.GET:
                    return await HttpClient.GetAsync(endpoint+ "?apiKey=JlE5Jldo5Jibnk5O5hTx6XVqsJu4WJ26").Result.Content.ReadAsStringAsync();
                case HTTPMethods.POST:
                    return await HttpClient.PostAsync(endpoint + "?apiKey=JlE5Jldo5Jibnk5O5hTx6XVqsJu4WJ26", content).Result.Content.ReadAsStringAsync();
                case HTTPMethods.PUT:
                    return await HttpClient.PutAsync(endpoint + "?apiKey=JlE5Jldo5Jibnk5O5hTx6XVqsJu4WJ26", content).Result.Content.ReadAsStringAsync();
                default:
                    break;
            }
            return null;
        }
        public enum HTTPMethods
        {
            GET,
            POST,
            PUT
        }
    }
}
