using AstroClient.ConsoleUtils;
using AstroClient.Finder;

namespace AstroClient.Worlds
{
    public class WorldSoundCleaner
    {
        public static void CleanWorldBGMusic()
        {
            if (WorldUtils.GetWorldID() == "wrld_d29bb0d0-d268-42dc-8365-926f9d485505")
            {
                var sound = GameObjectFinder.Find("Midnight Rooftop/Audio");
                if (sound != null)
                {
                    sound.gameObject.SetActive(false);
                    ModConsole.Log("Deactivated Midnight Rooftop Audio");
                }
            }

            if (WorldUtils.GetWorldID() == "wrld_4cf554b4-430c-4f8f-b53e-1f294eed230b")
            {
                var sound = GameObjectFinder.Find("music");
                if (sound != null)
                {
                    UnityEngine.Object.Destroy(sound);
                    ModConsole.Log("Destroyed music");
                }
            }

            if (WorldUtils.GetWorldID() == "wrld_fae3fa95-bc18-46f0-af57-f0c97c0ca90a")
            {
                var sound = GameObjectFinder.Find("GameObject (1)/GameObject/Sala de la lluvia/Audio de la zona de lluvia");
                if (sound != null)
                {
                    UnityEngine.Object.Destroy(sound);
                    ModConsole.Log("Destroyed Audio de la zona de lluvia.");
                }
            }

            if (WorldUtils.GetWorldID() == "wrld_9c72e56b-d2b0-4c9b-b816-07a857f6ae4e")
            {
                var sound = GameObjectFinder.Find("Environment/BGM");
                if (sound != null)
                {
                    sound.gameObject.SetActive(false);
                    ModConsole.Log("Deactivated BGM.");
                }
            }

            if (WorldUtils.GetWorldID() == "wrld_c87d9e7a-d46a-4ca4-9077-a6322ac0f7e7")
            {
                var sound = GameObjectFinder.Find("BgmManager");
                if (sound != null)
                {
                    if (sound.active)
                    {
                        sound.SetActive(false);
                        ModConsole.Log("Disabled BgmManager.");
                    }
                }
            }
        }
    }
}