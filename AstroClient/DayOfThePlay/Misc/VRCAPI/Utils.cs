using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace DayBots.VRCAPI
{
    internal class Utils
    {
        internal static string GetRespondsStream(WebResponse webResponse_0)
        {
            string result = "";
            using (Stream responseStream = webResponse_0.GetResponseStream())
            {
                using (StreamReader streamReader = new StreamReader(responseStream))
                {
                    result = streamReader.ReadToEnd();
                }
            }
            webResponse_0.Dispose();
            return result;
        }

        internal static string WebGet(string url, Dictionary<string, string> Parameter)
        {
            WebRequest requestclient = WebRequest.Create(url);
            requestclient.ContentType = "application/json";
            requestclient.Timeout = 500;
            foreach (var x in Parameter)
                requestclient.Headers.Add(x.Key, x.Value);
            ServicePointManager.ServerCertificateValidationCallback = ((object s, X509Certificate c, X509Chain cc, SslPolicyErrors ssl) => true);
            return GetRespondsStream(requestclient.GetResponse());
        }

        internal static string GetConfig()
        {
            return WebGet("https://api.vrchat.cloud/api/1/config", null);
        }
    }
}