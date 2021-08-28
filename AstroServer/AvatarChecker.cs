namespace AstroServer
{
    using AstroServer.Serializable;
    using MongoDB.Driver;
    using MongoDB.Entities;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Timers;

    public static class AvatarChecker
    {
        private static string proxyFilePath = "/root/proxies.txt";

        private static Mutex mutex;

        private static System.Timers.Timer CheckTimer;

        private static bool IsChecking;

        private static List<string> proxies = new List<string>();

        public static void Initialize()
        {
            mutex = new Mutex(false);
            LoadProxies();
            CheckTimer = new System.Timers.Timer(10000)
            {
                Enabled = true
            };
            CheckTimer.Elapsed += OnTimerElapsed;
            Console.WriteLine($"AvatarChecker: Initialized. {proxies.Count} proxies..");
        }

        private static void LoadProxies()
        {
            mutex.WaitOne();
            proxies = File.ReadAllLines(proxyFilePath).ToList();
            Console.WriteLine($"{proxies.Count} proxies loaded..");
            mutex.ReleaseMutex();
        }

        private static int GetChecked()
        {
            return DB.Find<AvatarDataEntity>().ManyAsync(a => a.CheckedRecently).Result.Count;
        }

        private static int GetNotChecked()
        {
            return DB.Find<AvatarDataEntity>().ManyAsync(a => !a.CheckedRecently).Result.Count;
        }

        private static void OnTimerElapsed(object sender, ElapsedEventArgs e)
        {
            if (!IsChecking)
            {
                if (proxies.Count < 10)
                {
                    Console.WriteLine("Reloading proxy list, don't have enough!");
                    LoadProxies();
                }

                IsChecking = true;
                //var rand = new Random();
                //CheckTimer.Interval = 2000;

                try
                {
                    var toCheck = DB.Find<AvatarDataEntity>().Limit(100).ManyAsync(f => !f.CheckedRecently).Result;

                    if (toCheck.Any())
                    {
                        List<Task> tasks = new List<Task>();
                        Console.WriteLine($"Avatar check in progress! Checking {toCheck.Count} avatars..");
                        foreach (var found in toCheck)
                        {
                            Task task = new Task(() =>
                            {
                                CheckAvatar(found);
                            });
                            tasks.Add(task);
                        }

                        tasks.ForEach(t => t.Start());
                        Task.WaitAll(tasks.ToArray());
                        Console.WriteLine($"Avatar check done! {GetChecked()}/{GetNotChecked()}");
                        Console.WriteLine($"{proxies.Count} proxies left..");
                    }
                    else
                    {
                        Console.WriteLine("Avatar checking is caught up!");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                IsChecking = false;
            }
            else
            {
                //Console.WriteLine("Avatar Check Already In Progress...");
            }
        }

        /// <summary>
        /// Adds the avatar to the checker which removes it from the database if it doesn't exist anymore.
        /// </summary>
        /// <param name="avatarDataEntity"></param>
        public static void CheckAvatar(AvatarDataEntity avatarDataEntity)
        {
            var rand = new Random();
            var proxy = proxies[rand.Next(0, proxies.Count)];

            //var image1 = CheckImage(proxy, avatarDataEntity.ThumbnailURL);
            var image2 = CheckImage(proxy, avatarDataEntity.ImageURL);

            //if (image1 == 0 || image2 == 0)
            if (image2 == 0)
            {
                Console.WriteLine($"Invalid avatar found: {avatarDataEntity.Name}, {avatarDataEntity.ImageURL}");
                avatarDataEntity.DeleteAsync().GetAwaiter().GetResult();
            }
            //else if (image1 == 2 || image2 == 2)
            else if (image2 == 2)
            {
                avatarDataEntity.CheckedRecently = false;
                _ = avatarDataEntity.SaveAsync();
            }
            else
            {
                avatarDataEntity.CheckedRecently = true;
                _ = avatarDataEntity.SaveAsync();
            }
        }

        public static int CheckImage(string proxy, string url)
        {
            var proxyObject = new WebProxy($"http://{proxy}/");
            //string HeaderFake = $"{VRCApplicationSetup.field_Private_Static_VRCApplicationSetup_0.field_Public_String_0}-{VRCApplicationSetup.field_Private_Static_VRCApplicationSetup_0.field_Public_Int32_0}--Release";
            try
            {
                proxyObject.UseDefaultCredentials = true;
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
                webRequest.AllowWriteStreamBuffering = true;
                webRequest.Timeout = 30000;
                webRequest.Proxy = proxyObject;

                webRequest.Headers.Add("User-Agent", "VRCX 2021.05.26.1");
                //webRequest.Headers.Add("User-Agent", "VRCX 2021.04.04");
                webRequest.Headers.Add("X-Platform", "standalonewindows");
                //webRequest.Headers.Add("X-Client-Version", HeaderFake);
                //webRequest.Headers.Add("User-Agent", "VRC.Core.BestHTTP");

                using (var response = webRequest.GetResponse())
                {
                    using (var responseStream = response.GetResponseStream())
                    {
                    }
                }
            }
            catch (WebException ex) when ((ex.Response as HttpWebResponse)?.StatusCode == HttpStatusCode.NotFound)
            {
                return 0;
            }
            catch (WebException ex) when ((ex.Response as HttpWebResponse)?.StatusCode == HttpStatusCode.Forbidden)
            {
                //Console.WriteLine($"{ex.Message}: {proxy}, {url}");
                RemoveProxy(proxy);
                RemoveProxyFromFile(proxy, "banned");
                return 2;
            }
            catch (WebException we)
            {
                if (we.Status == WebExceptionStatus.Timeout)
                {
                    RemoveProxyFromFile(proxy, "huge timeout");
                }
                Console.WriteLine($"{we.Message}: {proxy}, {url}");
                RemoveProxy(proxy);
                return 2;
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message}: {proxy}, {url}");
                RemoveProxy(proxy);
                return 2;
            }

            return 1;
        }

        private static void RemoveProxy(string proxy)
        {
            mutex.WaitOne();
            proxies.Remove(proxy);
            mutex.ReleaseMutex();
        }

        private static void RemoveProxyFromFile(string proxy, string reason)
        {
            mutex.WaitOne();
            var lines = File.ReadLines(proxyFilePath).ToList();
            lines.Remove(proxy);
            File.WriteAllLines(proxyFilePath, lines.ToArray());
            Console.WriteLine($"Proxy {proxy} removed from file. {reason}");
            mutex.ReleaseMutex();

        }
    }
}
