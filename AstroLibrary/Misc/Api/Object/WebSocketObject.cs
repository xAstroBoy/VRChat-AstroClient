﻿namespace AstroLibrary.Misc.Api.Object
{
	public class WebSocketObject
    {
        public string type { get; set; }
        public string content { get; set; }
    }

    public class WebSocketContent
    {
        public string userId { get; set; }
        public User user { get; set; }
        public string location { get; set; }
        public string instance { get; set; }
        public World world { get; set; }
        public bool canRequestInvite { get; set; }
    }
}