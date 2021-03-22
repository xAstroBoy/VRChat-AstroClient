using MelonLoader;
using RubyButtonAPI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnhollowerBaseLib;
using UnhollowerRuntimeLib;
using UnityEngine;
using VRC;
using VRC.SDKBase;

#region AstroClient Imports

using AstroClient.ConsoleUtils;

#endregion AstroClient Imports

namespace AstroClient
{
    public class EmojiUtils : Overridables
    {
        public static void SpawnlastEmoji()
        {
            if (IsVRChatCooldownActive)
            {
                if (SkipVRChatOnlineCooldown)
                {
                    SpawnOfflineEmoji(LastUsedEmoji, false);
                }
            }
            else
            {
                SpawnOnlineEmoji(LastUsedEmoji);
                IsBeingSpawnedFromMenu = true;
            }
        }

        public static void IncreaseEmojiInt()
        {
            if (EmojiInt != EmojiPrefabsClone.Count() - 1)
            {
                EmojiInt++;
            }
            UpdateEmojiButton();
        }

        public static void OnLevelLoad()
        {
            Cooldown = 0f;
            IsVRChatCooldownActive = false;
            Killcoroutines = true;
            isOnlineSpammerActive = false;
            ToggleOnlineSpawner(false);
            UpdateEmojiSpawning(true);
        }

        public static void SpawnEmojiRPCHook(VRCPlayer player, int emoji)
        {
            if (player == VRCPlayer.field_Internal_Static_VRCPlayer_0)
            {
                SetEmoji(emoji);
                UpdateLastSpawnedEmoji(emoji);
                if (IsVRChatCooldownActive)
                {
                    if (!IsBeingSpawnedFromMenu)
                    {
                        if (SkipVRChatOnlineCooldown)
                        {
                            SpawnOfflineEmoji(emoji, false);
                        }
                    }
                }
                else
                {
                    IsVRChatCooldownActive = true;
                }
                return;
            }
            SpawnLocalEmoji(player, emoji);
        }

        public override void OnUpdate()
        {
            if (IsVRChatCooldownActive)
            {
                Cooldown += Time.deltaTime;
                if (Cooldown >= VRChatEmojiCooldown)
                {
                    IsVRChatCooldownActive = false;
                    Cooldown = 0f;
                }
            }
            try {
                UpdateEmojiSpawning();
            }
            catch (Exception e)
            {
                ModConsole.Error("Error in EmojiUtils OnUpdate : " + e);
            }
        }




        public static void DecreaseEmojiInt()
        {
            if (EmojiInt != 0)
            {
                EmojiInt--;
            }
            UpdateEmojiButton();
        }

        public static void SetEmoji(int emoji)
        {
            EmojiInt = emoji;
            UpdateEmojiButton();
        }

        public static void SpawnOnlineEmoji(int emoji)
        {
            if (IsBeingSpawnedFromMenu)
            {
                IsBeingSpawnedFromMenu = false;
            }
            if (!IsVRChatCooldownActive)
            {
                Networking.RPC(0, VRCPlayer.field_Internal_Static_VRCPlayer_0.gameObject, "SpawnEmojiRPC", new Il2CppSystem.Object[] { new Il2CppSystem.Int32 { m_value = emoji }.BoxIl2CppObject() });
                IsVRChatCooldownActive = true;
            }
        }

        public static void SetEmojiButton(GameObject obj)
        {
        }

        public static void UpdateEmojiButton()
        {
            if (EmojiIntReveal != null)
            {
                var emojiname = (EmojiNames)EmojiInt;
                EmojiIntReveal.setButtonText(emojiname.ToString());
            }
        }

        public static void UpdateLastSpawnedEmoji(int emoji)
        {
            if (LastSpawnedEmojiName != null)
            {
                LastUsedEmoji = emoji;
                var emojiname = (EmojiNames)emoji;
                LastSpawnedEmojiName.setButtonText(emojiname.ToString());
            }
        }

        public static void UpdateEmojiSpamCounter()
        {
            if (EmojiSpamCounter != null)
            {
                EmojiSpamCounter.setButtonText("Spawn " + EmojiSpammerInt + " Emojis (LOCAL)");
            }
        }

        public static void SpawnEmoji()
        {
            if (!OnlineSpawn)
            {
                SpawnOfflineEmoji(EmojiInt, false);
                IsBeingSpawnedFromMenu = true;
            }
            else
            {
                if (!IsVRChatCooldownActive)
                {
                    SpawnOnlineEmoji(EmojiInt);
                    IsBeingSpawnedFromMenu = true;
                }
                else
                {
                    if (SkipVRChatOnlineCooldown)
                    {
                        SpawnOfflineEmoji(EmojiInt, false);
                        IsBeingSpawnedFromMenu = true;
                    }
                }
            }
        }

        public static IEnumerator OfflineSpammer()
        {
            for (int i = 0; i < EmojiSpammerInt; i++)
            {
                if (SlowSpawningAllowed)
                {
                    yield return new WaitForSeconds(0.5f);
                }

                SpawnOfflineEmoji(EmojiInt, false);
            }
            yield return null;
        }

        public static void OfflineEmojiSpammer()
        {
            MelonCoroutines.Start(OfflineSpammer());
        }

        public static void OnlineEmojiSpammer()
        {
            if (Killcoroutines)
            {
                Killcoroutines = false;
            }
            if (!isOnlineSpammerActive)
            {
                isOnlineSpammerActive = true;
                MelonCoroutines.Start(OnlineSpammer());
            }
        }

        public static IEnumerator OnlineSpammer()
        {
            if (isOnlineSpammerActive)
            {
                for (int i = 0; i < 15; i++)
                {
                    if (Killcoroutines)
                    {
                        Killcoroutines = false;
                        yield break;
                    }
                    while (IsVRChatCooldownActive)
                        yield return null;

                    SpawnOnlineEmoji(EmojiInt);
                }
                isOnlineSpammerActive = false;
                yield break;
            }
            else
            {
                yield break;
            }
        }

        public static void SpawnLocalEmoji(VRCPlayer player, int emoji)
        {
            if (player != null)
            {
                var EmojiGen = player.field_Private_MonoBehaviourPublicGaVoInStInStVoInStVoUnique_0 ;
                if (EmojiGen != null)
                {
                    EmojiGen.Method_Public_Void_Int32_0(emoji);
                }
                if (IsBeingSpawnedFromMenu)
                {
                    IsBeingSpawnedFromMenu = false;
                }
            }
        }

        public static void SpawnOfflineEmoji(int emoji, bool MakeOthersSeeit)
        {
            var EmojiGen = Player.prop_Player_0.field_Internal_VRCPlayer_0.field_Private_MonoBehaviourPublicGaVoInStInStVoInStVoUnique_0;
            if (EmojiGen != null)
            {
                EmojiGen.Method_Public_Void_Int32_0(emoji);

                if (IsBeingSpawnedFromMenu)
                {
                    IsBeingSpawnedFromMenu = false;
                }

                if (MakeOthersSeeit)
                {
                    if (IsVRChatCooldownActive)
                    {
                        Networking.RPC(0, VRCPlayer.field_Internal_Static_VRCPlayer_0.gameObject, "SpawnEmojiRPC", new Il2CppSystem.Object[] { new Il2CppSystem.Int32 { m_value = emoji }.BoxIl2CppObject() });
                    }
                }
            }
        }

        public static void add_x1()
        {
            EmojiSpammerInt = EmojiSpammerInt + 1;
            UpdateEmojiSpamCounter();
        }

        public static void add_x10()
        {
            EmojiSpammerInt = EmojiSpammerInt + 10;
            UpdateEmojiSpamCounter();
        }

        public static void add_x100()
        {
            EmojiSpammerInt = EmojiSpammerInt + 100;
            UpdateEmojiSpamCounter();
        }

        public static void sub_x1()
        {
            EmojiSpammerInt = EmojiSpammerInt - 1;
            UpdateEmojiSpamCounter();
        }

        public static void sub_x10()
        {
            EmojiSpammerInt = EmojiSpammerInt - 10;
            UpdateEmojiSpamCounter();
        }

        public static void sub_x100()
        {
            EmojiSpammerInt = EmojiSpammerInt - 100;
            UpdateEmojiSpamCounter();
        }

        public static void RestoreSpammer()
        {
            EmojiSpammerInt = 1;
            UpdateEmojiSpamCounter();
        }

        public static void ToggleOnlineSpawner()
        {
            OnlineSpawn = !OnlineSpawn;
            if (EmojiSpawnerChoices != null)
            {
                EmojiSpawnerChoices.setToggleState(OnlineSpawn);
            }
        }

        public static void ToggleOnlineSpawner(bool @override)
        {
            OnlineSpawn = @override;
            if (EmojiSpawnerChoices != null)
            {
                EmojiSpawnerChoices.setToggleState(@override);
            }
        }

        public static void ToggleEmojiSpawnerOnce()
        {
            SkipVRChatOnlineCooldown = !SkipVRChatOnlineCooldown;
            if (SpawnOfflineEmojisToggle != null)
            {
                SpawnOfflineEmojisToggle.setToggleState(SkipVRChatOnlineCooldown);
            }
            if (SpawnOfflineEmojisToggle2 != null)
            {
                SpawnOfflineEmojisToggle2.setToggleState(SkipVRChatOnlineCooldown);
            }
        }

        public static void ToggleEmojiSkipCooldown()
        {
            SkipVRChatOnlineCooldown = !SkipVRChatOnlineCooldown;
            if (SpawnOfflineEmojisToggle != null)
            {
                SpawnOfflineEmojisToggle.setToggleState(SkipVRChatOnlineCooldown);
            }
            if (SpawnOfflineEmojisToggle2 != null)
            {
                SpawnOfflineEmojisToggle2.setToggleState(SkipVRChatOnlineCooldown);
            }
        }

        public static void UpdateEmojiSpawning()
        {
            if (EmojiStatusEmojiMenu != null)
            {
                if (!IsVRChatCooldownActive)
                {
                    EmojiStatusEmojiMenu.setButtonText("Visible");
                    EmojiStatusEmojiMenu.setTextColor(Color.green);
                }
                else
                {
                    if (SkipVRChatOnlineCooldown)
                    {
                        EmojiStatusEmojiMenu.setButtonText("Local");
                        EmojiStatusEmojiMenu.setTextColor(Color.red);
                    }
                    else
                    {
                        EmojiStatusEmojiMenu.setButtonText("VRChat Cooldown is active.");
                        EmojiStatusEmojiMenu.setTextColor(Color.red);
                    }
                }
            }
            if (EmojiStatusEmojiSpawner != null)
            {
                if (!IsVRChatCooldownActive)
                {
                    EmojiStatusEmojiSpawner.setButtonText("Visible");
                    EmojiStatusEmojiSpawner.setTextColor(Color.green);
                }
                else
                {
                    if (SkipVRChatOnlineCooldown)
                    {
                        EmojiStatusEmojiSpawner.setButtonText("Local");
                        EmojiStatusEmojiSpawner.setTextColor(Color.red);
                    }
                    else
                    {
                        EmojiStatusEmojiSpawner.setButtonText("VRChat Cooldown is active.");
                        EmojiStatusEmojiSpawner.setTextColor(Color.red);
                    }
                }
            }
        }

        public static void UpdateEmojiSpawning(bool @override)
        {
            if (EmojiStatusEmojiMenu != null)
            {
                if (@override)
                {
                    EmojiStatusEmojiMenu.setButtonText("Visible");
                    EmojiStatusEmojiMenu.setTextColor(Color.green);
                }
                else
                {
                    EmojiStatusEmojiMenu.setButtonText("Local");
                    EmojiStatusEmojiMenu.setTextColor(Color.red);
                }
            }
            if (EmojiStatusEmojiSpawner != null)
            {
                if (@override)
                {
                    EmojiStatusEmojiSpawner.setButtonText("Visible");
                    EmojiStatusEmojiSpawner.setTextColor(Color.green);
                }
                else
                {
                    EmojiStatusEmojiSpawner.setButtonText("Local");
                    EmojiStatusEmojiSpawner.setTextColor(Color.red);
                }
            }
        }

        public static void ToggleEmojiSpamMode()
        {
            SlowSpawningAllowed = !SlowSpawningAllowed;
            if (EmojiSpawnerAllAtOnce != null)
            {
                EmojiSpawnerAllAtOnce.setToggleState(SlowSpawningAllowed);
            }
        }

        public static void InitButton(QMNestedButton main, float x, float y, bool btnHalf)
        {
            var EmojiSpawnerButtons = new QMNestedButton(main, x, y, "Emoji Spawner", "Manual Emoji Spawner.", null, null, null, null, btnHalf);
            EmojiUtils.EmojiIntReveal = new QMSingleButton(EmojiSpawnerButtons, 3, 0, EmojiUtils.EmojiNames.Smile.ToString(), new Action(EmojiUtils.SpawnEmoji), "Spawn Emoji.", null, null);
            new QMSingleButton(EmojiSpawnerButtons, 2, 0, "+", new Action(EmojiUtils.IncreaseEmojiInt), string.Empty, null, null);
            new QMSingleButton(EmojiSpawnerButtons, 4, 0, "-", new Action(EmojiUtils.DecreaseEmojiInt), string.Empty, null, null);
            EmojiUtils.EmojiSpawnerChoices = new QMToggleButton(EmojiSpawnerButtons, 1, 0, "Visible", new Action(EmojiUtils.ToggleOnlineSpawner), "Local", new Action(EmojiUtils.ToggleOnlineSpawner), "Decide if the emojis should be spawned online or local.", null, null, null, false);
            EmojiUtils.EmojiStatusEmojiSpawner = new QMSingleButton(EmojiSpawnerButtons, 5, 0, "Visible", null, "Emoji Visibility", null, Color.green);
            EmojiUtils.EmojiStatusEmojiMenu = new QMSingleButton("EmojiMenu", 5, 0, "Public", null, "Emoji Visibility", null, Color.green);
            EmojiUtils.LastSpawnedEmojiName = new QMSingleButton("EmojiMenu", 6, 0, string.Empty, new Action(EmojiUtils.SpawnlastEmoji), "Last Spawned Emoji.", null, Color.green);
            EmojiUtils.SpawnOfflineEmojisToggle = new QMToggleButton("EmojiMenu", 5, 1, "Skip Cooldown (Local spawn allowed)", new Action(EmojiUtils.ToggleEmojiSkipCooldown), "Dont Skip Cooldown (Visible spawn only)", new Action(EmojiUtils.ToggleEmojiSkipCooldown), "Skip Cooldown (Local & Visible)", null, null, null, false);
            EmojiUtils.SpawnOfflineEmojisToggle2 = new QMToggleButton(EmojiSpawnerButtons, 0, 0, "Skip Cooldown (Local spawn allowed)", new Action(EmojiUtils.ToggleEmojiSkipCooldown), "Dont Skip Cooldown (Visible spawn only)", new Action(EmojiUtils.ToggleEmojiSkipCooldown), "Skip Cooldown (Local & Visible)", null, null, null, false);
            EmojiUtils.EmojiSpawnerAllAtOnce = new QMToggleButton(EmojiSpawnerButtons, 0, 1, "Use Emoji Cooldown", new Action(EmojiUtils.ToggleEmojiSpamMode), "Dont use Emoji cooldown", new Action(EmojiUtils.ToggleEmojiSpamMode), "decide if emojis needs to be spawned all at once or use a cooldown.", null, null, null, false);
            new QMSingleButton(EmojiSpawnerButtons, 1, 1, "+1", new Action(EmojiUtils.add_x1), string.Empty, null, null);
            new QMSingleButton(EmojiSpawnerButtons, 2, 1, "+10", new Action(EmojiUtils.add_x10), string.Empty, null, null);
            new QMSingleButton(EmojiSpawnerButtons, 3, 1, "+100", new Action(EmojiUtils.add_x100), string.Empty, null, null);
            EmojiUtils.EmojiSpamCounter = new QMSingleButton(EmojiSpawnerButtons, 4, 1, "Spawn 0 Emojis (Local) ", new Action(EmojiUtils.OfflineEmojiSpammer), "How many emojis to Spawn (LOCAL)", null, null);
            new QMSingleButton(EmojiSpawnerButtons, 5, 1, "Reset Flooder", new Action(EmojiUtils.RestoreSpammer), string.Empty, null, null);
            new QMSingleButton(EmojiSpawnerButtons, 1, 2, "-1", new Action(EmojiUtils.sub_x1), string.Empty, null, null);
            new QMSingleButton(EmojiSpawnerButtons, 2, 2, "-10", new Action(EmojiUtils.sub_x10), string.Empty, null, null);
            new QMSingleButton(EmojiSpawnerButtons, 3, 2, "-100", new Action(EmojiUtils.sub_x100), string.Empty, null, null);
            new QMSingleButton(EmojiSpawnerButtons, 4, 2, "Spawn 15 Emojis (Online) ", new Action(EmojiUtils.OnlineEmojiSpammer), "How many emojis to Spawn (Only if the other has The Emoji Unlocker mod.)", null, null);
        }

        public enum EmojiNames
        {
            Smile = 0,
            Like = 1,
            Love = 2,
            Frown = 3,
            Dislike = 4,
            Exclaim = 5,
            Laugh = 6,
            Wow = 7,
            Question = 8,
            Kiss = 9,
            InLove = 10,
            Crying = 11,
            Stoic = 12,
            Tongue = 13,
            Blush = 14,
            Angry = 15,
            Fire = 16,
            Money = 17,
            BrokenHeart = 18,
            Gift = 19,
            Beer = 20,
            Tomato = 21,
            ZZZ = 22,
            Thinking = 23,
            Pizza = 24,
            Sunglasses = 25,
            Music = 26,
            Go = 27,
            HandWave = 28,
            Stop = 29,
            Cloud = 30,
            Fall_JackOLantern = 31,
            Fall_Ghost = 32,
            Fall_Skull = 33,
            Fall_Candy = 34,
            Fall_CandyCorn = 35,
            Fall_Boo = 36,
            Fall_Bats = 37,
            Fall_Web = 38,
            Fall_Web_clone = 39,
            Winter_Mistletoe = 40,
            Winter_Snowball = 41,
            Winter_SnowFall = 42,
            Winter_Coal = 43,
            Winter_CandyCane = 44,
            Winter_GingerBread = 45,
            Winter_Confetti = 46,
            Winter_ChampagneClink = 47,
            Winter_Gifts = 48,
            Summer_BeachBall = 49,
            Summer_Drink = 50,
            Summer_HangTen = 51,
            Summer_IceCream = 52,
            Summer_LifeRing = 53,
            Summer_NeonShades = 54,
            Summer_Pineapple = 55,
            Summer_Splash = 56,
            Summer_SunLotion = 57
        }

        public static List<GameObject> EmojiPrefabsClone;

        public static QMSingleButton EmojiIntReveal;

        public static QMSingleButton EmojiSpamCounter;

        public static QMToggleButton EmojiSpawnerChoices;

        public static QMToggleButton EmojiSpawnerAllAtOnce;

        public static QMToggleButton SpawnOfflineEmojisToggle;

        public static QMToggleButton SpawnOfflineEmojisToggle2;

        public static bool IsBeingSpawnedFromMenu = false;

        public static bool SlowSpawningAllowed = true;
        public static int EmojiSpammerInt = 0;

        public static readonly float VRChatEmojiCooldown = 3f;

        public static float Cooldown = 0f;

        public static bool IsVRChatCooldownActive = false;
        public static bool isOnlineSpammerActive = false;
        public static bool Killcoroutines = false;
        public static int EmojiInt = 0;

        public static bool OnlineSpawn = true;

        public static bool SkipVRChatOnlineCooldown = false;

        public static int LastUsedEmoji = 0;

        public static QMSingleButton EmojiStatusEmojiMenu;

        public static QMSingleButton LastSpawnedEmojiName;

        public static QMSingleButton EmojiStatusEmojiSpawner;

    }
}