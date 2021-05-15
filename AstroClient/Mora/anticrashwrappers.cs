namespace AstroClient.Mora
{
	using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Linq;
	using System.Net;
	using System.Net.Cache;
	using System.Net.Security;
	using System.Security.Cryptography.X509Certificates;
	using UnityEngine;
	using VRC;

	class anticrashwrappers
	{
		public static class anticrashWrapper
		{
			public static string[] shader_list;
			public static List<string> shader_list_local = new List<string>();
			public static GameObject GetPlayerCamera()
			{
				return GameObject.Find("Camera (eye)");
			}

			public static PlayerManager GetPlayerManager()
			{
				return PlayerManager.prop_PlayerManager_0;
			}
			public static string[] to_array(WebResponse res)
			{
				return convert(res).Split(Environment.NewLine.ToCharArray());
			}

			public static bool is_known(string shader)
			{
				return (shader_list.Contains(shader)) || shader_list_local.Contains(shader);
			}

			public static string convert(WebResponse res)
			{
				string result = "";
				using (Stream responseStream = res.GetResponseStream())
				{
					using (StreamReader streamReader = new StreamReader(responseStream))
					{
						result = streamReader.ReadToEnd();
					}
				}
				res.Dispose();
				return result;
			}
			public static string[] get_shader_blacklist()
			{
				WebRequest webRequest = WebRequest.Create("https://raw.githubusercontent.com/morag12/vrchat_useful_mod/master/blacklist-shaders.txt");
				HttpRequestCachePolicy cachePolicy = new HttpRequestCachePolicy(HttpRequestCacheLevel.BypassCache);
				webRequest.CachePolicy = cachePolicy;
				ServicePointManager.ServerCertificateValidationCallback = ((object s, X509Certificate c, X509Chain cc, SslPolicyErrors ssl) => true);
				return (from x in to_array(webRequest.GetResponse())
						where !string.IsNullOrEmpty(x)
						select x).ToArray<string>();
			}
		}
	}
}
