namespace AstroClient
{
    using AstroLibrary.Console;
    using AstroLibrary.Extensions;
    using AstroLibrary.Utility;
    using MelonLoader;
    using RubyButtonAPI;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using VRC;
    using VRC.SDKBase;

    internal class EmojiUtils : GameEvents
    {
        internal static  void SpawnlastEmoji()
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

        internal static  void IncreaseEmojiInt()
        {
            EmojiInt++;
            UpdateEmojiButton();
        }

        internal override void OnSceneLoaded(int buildIndex, string sceneName)
        {
            Cooldown = 0f;
            IsVRChatCooldownActive = false;
            Killcoroutines = true;
            isOnlineSpammerActive = false;
            ToggleOnlineSpawner(false);
            UpdateEmojiSpawning(true);
        }

        internal override void SpawnEmojiRPC(VRCPlayer player, int Emoji)
        {
            if (player == VRCPlayer.field_Internal_Static_VRCPlayer_0)
            {
                SetEmoji(Emoji);
                UpdateLastSpawnedEmoji(Emoji);
                if (IsVRChatCooldownActive)
                {
                    if (!IsBeingSpawnedFromMenu)
                    {
                        if (SkipVRChatOnlineCooldown)
                        {
                        }
                    }
                }
                else
                {
                    IsVRChatCooldownActive = true;
                }
                return;
            }
        }

        internal override void OnPlayerJoined(Player player)
        {
            if (player != null)
            {
                var vrcplayer = player.GetVRCPlayer();
                if (vrcplayer != null)
                {
                    if (vrcplayer.Get_Emoji_Cooldown() != 0)
                    {
                        vrcplayer.Set_Emoji_Cooldown(0);
                        ModConsole.DebugLog($"[EmojiBypasser] : Removed Player {player.DisplayName()} 's Emoji Cooldown.");
                    }
                }
            }
        }

        internal override void OnUpdate()
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
            try
            {
                UpdateEmojiSpawning();
            }
            catch (Exception e)
            {
                ModConsole.Error("Error in EmojiUtils OnUpdate : " + e);
            }
        }

        internal static  void DecreaseEmojiInt()
        {
            if (EmojiInt != 0)
            {
                EmojiInt--;
            }
            UpdateEmojiButton();
        }

        internal static  void SetEmoji(int emoji)
        {
            EmojiInt = emoji;
            UpdateEmojiButton();
        }

        internal static  void SpawnOnlineEmoji(int emoji)
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

        internal static  void SetEmojiButton(GameObject obj)
        {
        }

        internal static  void UpdateEmojiButton()
        {
            if (EmojiIntReveal != null)
            {
                var emojiname = (EmojiNames)EmojiInt;
                EmojiIntReveal.SetButtonText(emojiname.ToString());
            }
        }

        internal static  void UpdateLastSpawnedEmoji(int emoji)
        {
            if (LastSpawnedEmojiName != null)
            {
                LastUsedEmoji = emoji;
                var emojiname = (EmojiNames)emoji;
                LastSpawnedEmojiName.SetButtonText(emojiname.ToString());
            }
        }

        internal static  void UpdateEmojiSpamCounter()
        {
            if (EmojiSpamCounter != null)
            {
                EmojiSpamCounter.SetButtonText("Spawn " + EmojiSpammerInt + " Emojis (LOCAL)");
            }
        }

        internal static  void SpawnEmoji()
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

        internal static  IEnumerator OfflineSpammer()
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

        internal static  void OfflineEmojiSpammer()
        {
            _ = MelonCoroutines.Start(OfflineSpammer());
        }

        internal static  void OnlineEmojiSpammer()
        {
            if (Killcoroutines)
            {
                Killcoroutines = false;
            }
            if (!isOnlineSpammerActive)
            {
                isOnlineSpammerActive = true;
                _ = MelonCoroutines.Start(OnlineSpammer());
            }
        }

        internal static  IEnumerator OnlineSpammer()
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

        internal static  void SpawnLocalEmoji(VRCPlayer player, int emoji)
        {
            if (player != null)
            {
                var EmojiGen = player.field_Private_EmotePlayer_0;
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

        internal static  void SpawnOfflineEmoji(int emoji, bool MakeOthersSeeit)
        {
            var EmojiGen = Player.prop_Player_0.GetVRCPlayer().field_Private_EmotePlayer_0;
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

        internal static  void Add_x1()
        {
            EmojiSpammerInt++;
            UpdateEmojiSpamCounter();
        }

        internal static  void Add_x10()
        {
            EmojiSpammerInt += 10;
            UpdateEmojiSpamCounter();
        }

        internal static  void Add_x100()
        {
            EmojiSpammerInt += 100;
            UpdateEmojiSpamCounter();
        }

        internal static  void Sub_x1()
        {
            EmojiSpammerInt--;
            UpdateEmojiSpamCounter();
        }

        internal static  void Sub_x10()
        {
            EmojiSpammerInt -= 10;
            UpdateEmojiSpamCounter();
        }

        internal static  void Sub_x100()
        {
            EmojiSpammerInt -= 100;
            UpdateEmojiSpamCounter();
        }

        internal static  void RestoreSpammer()
        {
            EmojiSpammerInt = 1;
            UpdateEmojiSpamCounter();
        }

        internal static  void ToggleOnlineSpawner()
        {
            OnlineSpawn = !OnlineSpawn;
            if (EmojiSpawnerChoices != null)
            {
                EmojiSpawnerChoices.SetToggleState(OnlineSpawn);
            }
        }

        internal static  void ToggleOnlineSpawner(bool @override)
        {
            OnlineSpawn = @override;
            if (EmojiSpawnerChoices != null)
            {
                EmojiSpawnerChoices.SetToggleState(@override);
            }
        }

        internal static  void ToggleEmojiSpawnerOnce()
        {
            SkipVRChatOnlineCooldown = !SkipVRChatOnlineCooldown;
            if (SpawnOfflineEmojisToggle != null)
            {
                SpawnOfflineEmojisToggle.SetToggleState(SkipVRChatOnlineCooldown);
            }
            if (SpawnOfflineEmojisToggle2 != null)
            {
                SpawnOfflineEmojisToggle2.SetToggleState(SkipVRChatOnlineCooldown);
            }
        }

        internal static  void ToggleEmojiSkipCooldown()
        {
            SkipVRChatOnlineCooldown = !SkipVRChatOnlineCooldown;
            if (SpawnOfflineEmojisToggle != null)
            {
                SpawnOfflineEmojisToggle.SetToggleState(SkipVRChatOnlineCooldown);
            }
            if (SpawnOfflineEmojisToggle2 != null)
            {
                SpawnOfflineEmojisToggle2.SetToggleState(SkipVRChatOnlineCooldown);
            }
        }

        internal static  void UpdateEmojiSpawning()
        {
            if (EmojiStatusEmojiMenu != null)
            {
                if (!IsVRChatCooldownActive)
                {
                    EmojiStatusEmojiMenu.SetButtonText("Visible");
                    EmojiStatusEmojiMenu.SetTextColor(Color.green);
                }
                else
                {
                    if (SkipVRChatOnlineCooldown)
                    {
                        EmojiStatusEmojiMenu.SetButtonText("Local");
                        EmojiStatusEmojiMenu.SetTextColor(Color.red);
                    }
                    else
                    {
                        EmojiStatusEmojiMenu.SetButtonText("VRChat Cooldown is active.");
                        EmojiStatusEmojiMenu.SetTextColor(Color.red);
                    }
                }
            }
            if (EmojiStatusEmojiSpawner != null)
            {
                if (!IsVRChatCooldownActive)
                {
                    EmojiStatusEmojiSpawner.SetButtonText("Visible");
                    EmojiStatusEmojiSpawner.SetTextColor(Color.green);
                }
                else
                {
                    if (SkipVRChatOnlineCooldown)
                    {
                        EmojiStatusEmojiSpawner.SetButtonText("Local");
                        EmojiStatusEmojiSpawner.SetTextColor(Color.red);
                    }
                    else
                    {
                        EmojiStatusEmojiSpawner.SetButtonText("VRChat Cooldown is active.");
                        EmojiStatusEmojiSpawner.SetTextColor(Color.red);
                    }
                }
            }
        }

        internal static  void UpdateEmojiSpawning(bool @override)
        {
            if (EmojiStatusEmojiMenu != null)
            {
                if (@override)
                {
                    EmojiStatusEmojiMenu.SetButtonText("Visible");
                    EmojiStatusEmojiMenu.SetTextColor(Color.green);
                }
                else
                {
                    EmojiStatusEmojiMenu.SetButtonText("Local");
                    EmojiStatusEmojiMenu.SetTextColor(Color.red);
                }
            }
            if (EmojiStatusEmojiSpawner != null)
            {
                if (@override)
                {
                    EmojiStatusEmojiSpawner.SetButtonText("Visible");
                    EmojiStatusEmojiSpawner.SetTextColor(Color.green);
                }
                else
                {
                    EmojiStatusEmojiSpawner.SetButtonText("Local");
                    EmojiStatusEmojiSpawner.SetTextColor(Color.red);
                }
            }
        }

        internal static  void ToggleEmojiSpamMode()
        {
            SlowSpawningAllowed = !SlowSpawningAllowed;
            if (EmojiSpawnerAllAtOnce != null)
            {
                EmojiSpawnerAllAtOnce.SetToggleState(SlowSpawningAllowed);
            }
        }

        internal static  void InitButton(QMTabMenu main, float x, float y, bool btnHalf)
        {
            var EmojiSpawnerButtons = new QMNestedButton(main, x, y, "Emoji Spawner", "Manual Emoji Spawner.", null, null, null, null, btnHalf);
            EmojiIntReveal = new QMSingleButton(EmojiSpawnerButtons, 3, 0, EmojiNames.Smile.ToString(), new Action(SpawnEmoji), "Spawn Emoji.", null, null);
            _ = new QMSingleButton(EmojiSpawnerButtons, 2, 0, "+", new Action(IncreaseEmojiInt), string.Empty, null, null);
            _ = new QMSingleButton(EmojiSpawnerButtons, 4, 0, "-", new Action(DecreaseEmojiInt), string.Empty, null, null);
            EmojiSpawnerChoices = new QMToggleButton(EmojiSpawnerButtons, 1, 0, "Visible", new Action(ToggleOnlineSpawner), "Local", new Action(ToggleOnlineSpawner), "Decide if the emojis should be spawned online or local.", null, null, null, false);
            EmojiStatusEmojiSpawner = new QMSingleButton(EmojiSpawnerButtons, 5, 0, "Visible", null, "Emoji Visibility", null, Color.green);
            EmojiStatusEmojiMenu = new QMSingleButton("EmojiMenu", 5, 0, "Public", null, "Emoji Visibility", null, Color.green);
            LastSpawnedEmojiName = new QMSingleButton("EmojiMenu", 6, 0, string.Empty, new Action(SpawnlastEmoji), "Last Spawned Emoji.", null, Color.green);
            SpawnOfflineEmojisToggle = new QMToggleButton("EmojiMenu", 5, 1, "Skip Cooldown (Local spawn allowed)", new Action(ToggleEmojiSkipCooldown), "Dont Skip Cooldown (Visible spawn only)", new Action(ToggleEmojiSkipCooldown), "Skip Cooldown (Local & Visible)", null, null, null, false);
            SpawnOfflineEmojisToggle2 = new QMToggleButton(EmojiSpawnerButtons, 0, 0, "Skip Cooldown (Local spawn allowed)", new Action(ToggleEmojiSkipCooldown), "Dont Skip Cooldown (Visible spawn only)", new Action(ToggleEmojiSkipCooldown), "Skip Cooldown (Local & Visible)", null, null, null, false);
            EmojiSpawnerAllAtOnce = new QMToggleButton(EmojiSpawnerButtons, 0, 1, "Use Emoji Cooldown", new Action(ToggleEmojiSpamMode), "Dont use Emoji cooldown", new Action(ToggleEmojiSpamMode), "decide if emojis needs to be spawned all at once or use a cooldown.", null, null, null, false);
            _ = new QMSingleButton(EmojiSpawnerButtons, 1, 1, "+1", new Action(Add_x1), string.Empty, null, null);
            _ = new QMSingleButton(EmojiSpawnerButtons, 2, 1, "+10", new Action(Add_x10), string.Empty, null, null);
            _ = new QMSingleButton(EmojiSpawnerButtons, 3, 1, "+100", new Action(Add_x100), string.Empty, null, null);
            EmojiSpamCounter = new QMSingleButton(EmojiSpawnerButtons, 4, 1, "Spawn 0 Emojis (Local) ", new Action(OfflineEmojiSpammer), "How many emojis to Spawn (LOCAL)", null, null);
            _ = new QMSingleButton(EmojiSpawnerButtons, 5, 1, "Reset Flooder", new Action(RestoreSpammer), string.Empty, null, null);
            _ = new QMSingleButton(EmojiSpawnerButtons, 1, 2, "-1", new Action(Sub_x1), string.Empty, null, null);
            _ = new QMSingleButton(EmojiSpawnerButtons, 2, 2, "-10", new Action(Sub_x10), string.Empty, null, null);
            _ = new QMSingleButton(EmojiSpawnerButtons, 3, 2, "-100", new Action(Sub_x100), string.Empty, null, null);
            _ = new QMSingleButton(EmojiSpawnerButtons, 4, 2, "Spawn 15 Emojis (Online) ", new Action(OnlineEmojiSpammer), "How many emojis to Spawn (Only if the other has The Emoji Unlocker mod.)", null, null);
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

        internal static  List<GameObject> EmojiPrefabsClone;

        internal static  QMSingleButton EmojiIntReveal;

        internal static  QMSingleButton EmojiSpamCounter;

        internal static  QMToggleButton EmojiSpawnerChoices;

        internal static  QMToggleButton EmojiSpawnerAllAtOnce;

        internal static  QMToggleButton SpawnOfflineEmojisToggle;

        internal static  QMToggleButton SpawnOfflineEmojisToggle2;

        internal static  bool IsBeingSpawnedFromMenu = false;

        internal static  bool SlowSpawningAllowed = true;
        internal static  int EmojiSpammerInt = 0;

        internal static  readonly float VRChatEmojiCooldown = 2f;

        internal static  float Cooldown = 0f;

        internal static  bool IsVRChatCooldownActive = false;
        internal static  bool isOnlineSpammerActive = false;
        internal static  bool Killcoroutines = false;
        internal static  int EmojiInt = 0;

        internal static  bool OnlineSpawn = true;

        internal static  bool SkipVRChatOnlineCooldown = false;

        internal static  int LastUsedEmoji = 0;

        internal static  QMSingleButton EmojiStatusEmojiMenu;

        internal static  QMSingleButton LastSpawnedEmojiName;

        internal static  QMSingleButton EmojiStatusEmojiSpawner;
    }
}