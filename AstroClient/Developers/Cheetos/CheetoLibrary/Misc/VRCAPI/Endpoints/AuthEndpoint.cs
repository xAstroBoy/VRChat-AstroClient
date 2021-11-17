namespace AstroClient.CheetoLibrary.Misc.VRCAPI.Endpoints
{
    using System;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;

    public class AuthEndpoint
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public Variables Variables;

        public AuthEndpoint(Variables variables, string username, string password)
        {
            Username = username;
            Password = password;
            Variables = variables;
        }

        public async Task<string> Login()
        {
            var response = await Variables.HttpClient.GetAsync($"auth/user?apiKey={API.APIKEYLONG}");
            string authCookie = "";
            if (response.IsSuccessStatusCode)
            {
                foreach (var cookie in Variables.CookieContainer.GetCookies(new Uri("https://api.vrchat.cloud/api/1/")).Cast<Cookie>())
                    if (cookie.Name == "auth")
                    {
                        Variables.AuthCookie = cookie.Value;
                        authCookie = cookie.Value;
                    }
            }
            return authCookie;
        }
    }
}