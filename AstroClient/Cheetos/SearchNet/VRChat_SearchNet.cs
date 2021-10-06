using System;
using Newtonsoft.Json;

namespace AstroClient.Cheetos
{
    internal class VRChat_SearchNet
    {
        public string _id { get; set; }

        public VRChat_SearchNet.World_Event Action { get; set; }

        public string Username { get; set; }

        public string worldid { get; set; }

        public string worldname { get; set; }

        public string worldprivacy { get; set; }

        public string avatarid { get; set; }

        public bool ParsefromJson(string Json)
        {
            bool result;
            try
            {
                VRChat_SearchNet vrchat_SearchNet = JsonConvert.DeserializeObject<VRChat_SearchNet>(Json);
                this.Action = vrchat_SearchNet.Action;
                this.avatarid = vrchat_SearchNet.avatarid;
                this.Username = vrchat_SearchNet.Username;
                this.worldname = vrchat_SearchNet.worldname;
                this.worldprivacy = vrchat_SearchNet.worldprivacy;
                this.worldid = vrchat_SearchNet.worldid;
                this._id = vrchat_SearchNet._id;
                result = true;
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public enum World_Event
        {
            Leave,
            Join
        }
    }
}
