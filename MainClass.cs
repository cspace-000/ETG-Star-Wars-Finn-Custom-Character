using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using UnityEngine;
using Dungeonator;
using Gungeon;
using MonoMod.RuntimeDetour;
using System.IO;
using System.Collections;
using System.Collections.ObjectModel;
using SWFinn.Audio;
using CustomCharacters;


//using UnityEngine.SceneManagement;

namespace SWFinn
{
    public class MainClass : ETGModule
    {
        public override void Init()
        {
            AudioResourceLoader.InitAudio();

        }
        public override void Start()
        {
            //ETGModConsole.Commands.AddGroup("audiotest", new Action<string[]>(RunTest.runtest));
            //ETGModConsole.Commands.AddGroup("testname", new Action<string[]>(RunTest.testname));
            //ETGModConsole.Commands.AddGroup("getgun", new Action<string[]>(RunTest.getGunName));
            //ETGModConsole.Commands.AddGroup("get", new Action<string[]>(RunTest.Get));
            //ETGModConsole.Commands.AddGroup("tele", new Action<string[]>(GRandomTeleport.TeleportToSpecificRoom));
            //ETGModConsole.Commands.AddGroup("getcasey", new Action<string[]>(RunTest.caseydebugger));
            //ETGModConsole.Commands.AddGroup("getstats", new Action<string[]>(RunTest.GetPlayerStats));
            //ETGModConsole.Commands.AddGroup("gunaudio", new Action<string[]>(RunTest.testgunaudio));
            
            SoundBankStrings.Create_Databases();

            try
            {

                Hook hook1 = new Hook(typeof(Foyer).GetMethod("PlayerCharacterChanged", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public),
                    typeof(Hooks).GetMethod("PlayerCharacterChangedHook", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance), typeof(Foyer));
                MainClass.flag1 = true;

                Hook hook2  = new Hook(typeof(GameActor).GetMethod("SetIsFlying", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public),
                    typeof(Hooks).GetMethod("SetIsFlyingHook", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance), typeof(GameActor));
                MainClass.flag2 = true;

                Hook hook3 = new Hook(typeof(JetpackItem).GetMethod("DoEffect", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic),
                    typeof(Hooks).GetMethod("DoEffectHook", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance), typeof(JetpackItem));
                MainClass.flag3 = true;

                Hook hook4 = new Hook(typeof(JetpackItem).GetMethod("DoActiveEffect", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic),
                    typeof(Hooks).GetMethod("DoActiveEffectHook", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance), typeof(JetpackItem));
                MainClass.flag4 = true;

                Hook hook5 = new Hook(typeof(DungeonFloorMusicController).GetMethod("SwitchToBossMusic", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public),
                    typeof(Hooks).GetMethod("SwitchToBossMusicHook", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance), typeof(DungeonFloorMusicController));
                MainClass.flag5 = true;

                Hook hook6 = new Hook(typeof(DungeonFloorMusicController).GetMethod("EndBossMusic", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public),
                    typeof(Hooks).GetMethod("EndBossMusicHook", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance), typeof(DungeonFloorMusicController));
                MainClass.flag6 = true;

                //Hook hook7 = new Hook(typeof(PlayerController).GetMethod("DoConsumableBlank", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic),
                //    typeof(Hooks).GetMethod("DoConsumableBlankHook", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance), typeof(PlayerController));
                //Class1.flag7 = true;

                Hook hook8 = new Hook(typeof(PlayerController).GetMethod("HandleItemStolen", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public),
                    typeof(Hooks).GetMethod("HandleItemStolenHook", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance), typeof(PlayerController));
                MainClass.flag8 = true;

                //Hook hook9 = new Hook(typeof(PlayerController).GetMethod("HandleItemPurchased", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public),
                //    typeof(Hooks).GetMethod("HandleItemPurchasedHook", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance), typeof(PlayerController));
                //Class1.flag9 = true;

                Hook hook10 = new Hook(typeof(RoomHandler).GetMethod("HandleRoomClearReward", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public),
                    typeof(Hooks).GetMethod("HandleRoomClearRewardHook", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance), typeof(RoomHandler));
                MainClass.flag10 = true;

                Hook hook11 = new Hook(typeof(PlayerController).GetMethod("OnDidDamage", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public),
                    typeof(Hooks).GetMethod("OnDidDamageHook", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance), typeof(PlayerController));
                MainClass.flag11 = true;

                Hook hook12 = new Hook(typeof(FlippableCover).GetMethod("Interact", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public),
                    typeof(Hooks).GetMethod("InteractHook", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance), typeof(FlippableCover));
                MainClass.flag12 = true;

                Hook hook13 = new Hook(typeof(CompanionController).GetMethod("Initialize", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public),
                    typeof(Hooks).GetMethod("InitializeHook", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance), typeof(CompanionController));
                MainClass.flag13 = true;

                Hook hook14 = new Hook(typeof(PlayerController).GetMethod("OnGunChanged", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic),
                    typeof(Hooks).GetMethod("OnGunChangedHook", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance), typeof(PlayerController));
                MainClass.flag14 = true;

                //Hook hook15 = new Hook(typeof(BilliardsStickItem).GetMethod("HandleHitEnemy", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic),
                //    typeof(Hooks).GetMethod("HandleHitEnemyHook", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance), typeof(BilliardsStickItem));

                //Hook hook19 = new Hook(typeof(BilliardsStickItem).GetMethod("HandleHitEnemyHitEnemy", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic),
                //    typeof(Hooks).GetMethod("HandleHitEnemyHitEnemyHook", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance), typeof(BilliardsStickItem));
                //ETGModConsole.Log("Billards Hook Installed");

                Hook hook18 = new Hook(typeof(Projectile).GetMethod("Reflected", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public),
                    typeof(Hooks).GetMethod("ReflectedHook", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance), typeof(Projectile));

                Hook hook15 = new Hook(typeof(Projectile).GetMethod("HandleKnockback", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public),
                    typeof(Hooks).GetMethod("HandleKnockbackHook", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance), typeof(Projectile));
                MainClass.flag15 = true;

                Hook hook16 = new Hook(typeof(CompanionController).GetMethod("HandleCopDeath", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic),
                    typeof(Hooks).GetMethod("HandleCopDeathHook", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance), typeof(CompanionController));
                    MainClass.flag0 = true;

                Hook hook17 = new Hook(typeof(Gun).GetMethod("HandleDodgeroll", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public),
                    typeof(Hooks).GetMethod("HandleDodgerollHook", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance), typeof(Gun));
                //Class1.flag0 = true;

                Hook hook19 = new Hook(typeof(PlayerController).GetMethod("orig_Start", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public),
                    typeof(Hooks).GetMethod("orig_StartHook", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance), typeof(PlayerController));

                Hook hook20 = new Hook(typeof(BashelliskIntroDoer).GetMethod("PlayerWalkedIn", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public),
                    typeof(Hooks).GetMethod("PlayerWalkedInHook", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance), typeof(BashelliskIntroDoer));

                Hook hook21 = new Hook(typeof(PlayerController).GetMethod("AcquirePassiveItem", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public),
                    typeof(Hooks).GetMethod("AcquirePassiveItemHook", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance), typeof(PlayerController));
                
                //Debug.Log("Installed QuickrestartHook");


                //Hook hook20 = new Hook(typeof(AkSoundEngine).GetMethod("PostEvent", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public),
                //    typeof(Hooks).GetMethod("PostEventHook", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static));


                Debug.Log("here");



            }
            catch (Exception exception)
            {
                Debug.Log("[FinnCharacter] Error occured while installing hooks");
                Debug.LogException(exception);
                Debug.Log(string.Format("flag0: {0}, flag1: {1}, flag2: {2}, flag3: {3}, flag4: {4}, flag5: {5}, " +
                    "flag6: {6}, flag7: {7}, flag8: {8}, flag9: {9}, flag10: {10}, " +
                    "flag11: {11}, flag12: {12}, flag13: {13}, flag14: {14}, flag15: {15}" , 
                    MainClass.flag0, MainClass.flag1, MainClass.flag2, MainClass.flag3, MainClass.flag4, MainClass.flag5, 
                    MainClass.flag6, MainClass.flag7, MainClass.flag8, MainClass.flag9, MainClass.flag10, 
                    MainClass.flag11, MainClass.flag12, MainClass.flag13, MainClass.flag14, MainClass.flag15));

            }

        }
        public override void Exit()
        {
            
        }

        private static bool flag1 = false;
        private static bool flag2 = false;
        private static bool flag3 = false;
        private static bool flag4 = false;
        private static bool flag5 = false;
        private static bool flag6 = false;
        private static bool flag7 = false;
        private static bool flag8 = false;
        private static bool flag9 = false;
        private static bool flag10 = false;
        private static bool flag11 = false;
        private static bool flag12 = false;
        private static bool flag13 = false;
        private static bool flag14 = false;
        private static bool flag15 = false;
        private static bool flag0 = false;


    }

    

    public class Hooks : MonoBehaviour
    {
        public void PlayerCharacterChangedHook(Action<Foyer, PlayerController> orig, Foyer self, PlayerController player)
        {
            //ETGModConsole.Log("hook is a go");
            GameManager instance = GameManager.Instance;
            CustomCharacter customCharacter;


            if (instance == null)
            {
                customCharacter = null;
            }
            else
            {
                PlayerController primaryPlayer = instance.PrimaryPlayer;
                customCharacter = ((primaryPlayer != null) ? primaryPlayer.GetComponent<CustomCharacter>() : null);
            }

            //CustomCharacter customcharacter = GameManager.Instance.PrimaryPlayer.GetComponent<CustomCharacters.CustomCharacter>();
            if (customCharacter)
            {
                string name = customCharacter.data.name;
                //ETGModConsole.Log("Name: " + name);
                if (name == "Finn FN-2187")
                {
                    //ETGModConsole.Log("should be playing sound");

                    System.Random rnd = new System.Random();
                    int nu = rnd.Next(0, SoundBankStrings.charselect.Count);
                    string used_string = SoundBankStrings.charselect[nu];

                    AkSoundEngine.PostEvent(used_string, player.gameObject);


                    player.gameObject.AddComponent<FinnBehaviour>();
                    player = FinnGun.AddSounds(player);

                    Hooks.m_accuracy = player.stats.GetBaseStatValue(PlayerStats.StatType.Accuracy);
                    Hooks.m_rateoffire = player.stats.GetBaseStatValue(PlayerStats.StatType.RateOfFire);
                    //PlayerItem item = player.activeItems.GetFirst();
                    //item.gameObject.AddComponent<JetPackSpeed>();
                    Hooks.bossMusic = SoundBankStrings.music;

                }
                //else
                //{
                //    ETGModConsole.Log("not finn");
                //}

            }

            //else
            //{
            //    //ETGModConsole.Log("not customcharacter");
            //}

            orig(self, player);

        }
        public void orig_StartHook(Action<PlayerController> orig, PlayerController self)
        {
            try
            {
                orig(self);
            }

            catch { }
            GameManager instance = GameManager.Instance;



            if (instance == null)
            {

            }
            else
            {
                //Debug.Log("Orig Start should be doing this");
                self = FinnGun.AddSounds(self);
                self.gameObject.AddComponent<FinnBehaviour>();
                //Debug.Log("Orig Start should have added sounds");

                Hooks.m_accuracy = self.stats.GetBaseStatValue(PlayerStats.StatType.Accuracy);
                Hooks.m_rateoffire = self.stats.GetBaseStatValue(PlayerStats.StatType.RateOfFire);
                Hooks.bossMusic = SoundBankStrings.music;
            }


        }

        private static List<string> bossMusic;


        public void SetIsFlyingHook(System.Action<GameActor, bool, string, bool, bool> orig, GameActor self, bool value, string reason, bool adjustShadow = true, bool modifyPathing = false)
        {
            try
            {
                orig(self, value, reason, adjustShadow, modifyPathing);
            }

            catch
            {
            }

            GameManager instance = GameManager.Instance;
            PlayerController primaryPlayer; //= instance.PrimaryPlayer;
            if (self.gameActor is PlayerController)
            {
                if (instance == null)
                {
                    primaryPlayer = null;
                }
                else
                {
                    primaryPlayer = instance.PrimaryPlayer;

                        if (value)
                        {
                            System.Random rnd = new System.Random();
                            int nu = rnd.Next(0, SoundBankStrings.onflying.Count);
                            string used_string = SoundBankStrings.onflying[nu];

                            AkSoundEngine.PostEvent(used_string, primaryPlayer.gameObject);
                        }
                        else
                        {

                            System.Random rnd = new System.Random();
                            int nu = rnd.Next(0, SoundBankStrings.onground.Count);
                            string used_string = SoundBankStrings.onground[nu];

                            AkSoundEngine.PostEvent(used_string, primaryPlayer.gameObject);
                        }

                    


                }

            }





        }
        public void DoEffectHook(Action<JetpackItem, PlayerController> orig, JetpackItem self, PlayerController user)
        {   //isFlying
            //ETGModConsole.Log("JetPackHook");
            try
            {
                orig(self, user);

            }
            catch
            {

            }

            user.MovementModifiers += JetPackSpeed.MotionModifier;

            GameManager instance = GameManager.Instance;
            PlayerController primaryPlayer; //= instance.PrimaryPlayer;

            if (instance == null)
            {
                primaryPlayer = null;
            }
            else
            {//isFlying
                primaryPlayer = instance.PrimaryPlayer;
                for (int i = 0; i < primaryPlayer.inventory.AllGuns.Count; i++)
                {
                    Gun gun = primaryPlayer.inventory.AllGuns[i];

                    if (gun.gunName == "Rogue Special")
                    {
                        //ETGModConsole.Log("Found gun");
                        gun.PreventNormalFireAudio = true; 

                        gun.OverrideNormalFireAudioEvent = "tie_fighter_1";

                        //float accuracy = primaryPlayer.stats.GetBaseStatValue(PlayerStats.StatType.Accuracy);
                        //float RateOfFire = primaryPlayer.stats.GetBaseStatValue(PlayerStats.StatType.RateOfFire);

                        //float accuracy = Hooks.m_accuracy;
                        //float RateOfFire = Hooks.m_rateoffire;

                        Hooks.m_accuracy /= 10;
                        Hooks.m_rateoffire *= 10;
                        // ETGModConsole.Log(String.Format("Start IsFlying accuracy:{0} rof:{1}", accuracy, RateOfFire));

                        primaryPlayer.stats.SetBaseStatValue(PlayerStats.StatType.Accuracy, Hooks.m_accuracy, primaryPlayer);
                        primaryPlayer.stats.SetBaseStatValue(PlayerStats.StatType.RateOfFire, Hooks.m_rateoffire, primaryPlayer);

                       // ETGModConsole.Log(String.Format("End isFlying accuracy:{0} rof:{1}", primaryPlayer.stats.GetBaseStatValue(PlayerStats.StatType.Accuracy), primaryPlayer.stats.GetBaseStatValue(PlayerStats.StatType.RateOfFire)));

                    }
                }
            }
        


    }
        private static float m_accuracy;
        private static float m_rateoffire;
        public void DoActiveEffectHook(Action<JetpackItem, PlayerController> orig, JetpackItem self, PlayerController user)
        {   //onGround
            try
            {
                
                orig(self, user);
            }
            catch
            {
            }
            user.MovementModifiers -= JetPackSpeed.MotionModifier;
            GameManager instance = GameManager.Instance;
            PlayerController primaryPlayer; //= instance.PrimaryPlayer;

            if (instance == null)
            {
                primaryPlayer = null;
            }
            else
            {
                primaryPlayer = instance.PrimaryPlayer;
                for (int i = 0; i < primaryPlayer.inventory.AllGuns.Count; i++)
                {   //onGround
                    Gun gun = primaryPlayer.inventory.AllGuns[i];

                    if (gun.gunName == "Rogue Special")
                    {
                        //ETGModConsole.Log("Found gun");
                        gun.PreventNormalFireAudio = true;

                        gun.OverrideNormalFireAudioEvent = "blast2";
                        float accuracy = primaryPlayer.stats.GetBaseStatValue(PlayerStats.StatType.Accuracy);
                        float RateOfFire = primaryPlayer.stats.GetBaseStatValue(PlayerStats.StatType.RateOfFire);

                        Hooks.m_accuracy *= 10;
                        Hooks.m_rateoffire /= 10;

                        //  ETGModConsole.Log(String.Format("Start onGround accuracy:{0} rof:{1}", accuracy, RateOfFire));
                        //primaryPlayer.stats.SetBaseStatValue(PlayerStats.StatType.Accuracy, 3f, primaryPlayer);
                        //primaryPlayer.stats.SetBaseStatValue(PlayerStats.StatType.RateOfFire, 1f, primaryPlayer);

                        primaryPlayer.stats.SetBaseStatValue(PlayerStats.StatType.Accuracy, Hooks.m_accuracy, primaryPlayer);
                        primaryPlayer.stats.SetBaseStatValue(PlayerStats.StatType.RateOfFire, Hooks.m_rateoffire, primaryPlayer);

                        // ETGModConsole.Log(String.Format("End onGround accuracy:{0} rof:{1}", primaryPlayer.stats.GetBaseStatValue(PlayerStats.StatType.Accuracy), primaryPlayer.stats.GetBaseStatValue(PlayerStats.StatType.RateOfFire)));

                    }
                }
            }


        }
        public void SwitchToBossMusicHook(Action<DungeonFloorMusicController, string, GameObject>orig, DungeonFloorMusicController self, string bossMusicString, GameObject source)
        {
            //bossMusicString = "Play_2";
            System.Random rnd = new System.Random();

            int nu = rnd.Next(0, Hooks.bossMusic.Count);
            Hooks.bossMusicString = Hooks.bossMusic[nu];

            Hooks.bossMusic.Remove(Hooks.bossMusicString);

            Hooks.source = source;
            //ETGModConsole.Log("Boss Music: "+SoundBankStrings.music.Count + Hooks.bossMusicString);
            try
            {
                orig(self, Hooks.bossMusicString, Hooks.source);
            }
            catch
            {

            }


        }
        private static string bossMusicString;
        private static GameObject source;
        public void EndBossMusicHook(Action<DungeonFloorMusicController>orig, DungeonFloorMusicController self)
        {
            string StopbossMusicString = Hooks.bossMusicString + "_stop";
            if (StopbossMusicString != null)
            {
                //ETGModConsole.Log("Stopping music: ");
                AkSoundEngine.PostEvent(StopbossMusicString, Hooks.source);
            }

            try
            {
                orig(self);
                

            }
            catch
            {

            }
            GameManager instance = GameManager.Instance;
            PlayerController primaryPlayer; //= instance.PrimaryPlayer;
                                            //ETGModConsole.Log("Vicotry Music");
            if (instance == null)
            {
                primaryPlayer = null;
            }
            else
            {
                
                
                primaryPlayer = instance.PrimaryPlayer;
                System.Random rnd = new System.Random();
                int nu = rnd.Next(0, SoundBankStrings.victory.Count);
                string sound_string = SoundBankStrings.victory[nu];
                AkSoundEngine.PostEvent(sound_string, primaryPlayer.gameObject);


                


            }
        }
        //public void DoConsumableBlankHook(Action<PlayerController>orig, PlayerController self)
        //{
        //    try
        //    {
        //        orig(self);
        //    }
        //    catch
        //    {

        //    }

        //    GameManager instance = GameManager.Instance;
        //    PlayerController primaryPlayer; //= instance.PrimaryPlayer;
        //    //ETGModConsole.Log("Vicotry Music");
        //    if (instance == null)
        //    {
        //        primaryPlayer = null;
        //    }
        //    else
        //    {
        //        //ETGModConsole.Log("DoConsumableBlankHook");
        //        primaryPlayer = instance.PrimaryPlayer;

        //        System.Random rnd = new System.Random();
        //        int nu = rnd.Next(0, SoundBankStrings.rey.Count);
        //        string used_string = SoundBankStrings.rey[nu];

        //        AkSoundEngine.PostEvent(used_string, primaryPlayer.gameObject);
        //    }



        //}
        public void HandleItemStolenHook(Action<PlayerController, ShopItemController> orig, PlayerController self, ShopItemController item)
        {
            try
            {
                orig(self, item);
            }
            catch
            {

            }

            GameManager instance = GameManager.Instance;
            PlayerController primaryPlayer; //= instance.PrimaryPlayer;
            //ETGModConsole.Log("Vicotry Music");
            if (instance == null)
            {
                primaryPlayer = null;
            }
            else
            {
                
                primaryPlayer = instance.PrimaryPlayer;
                System.Random rnd = new System.Random();
                int nu = rnd.Next(0, SoundBankStrings.stealing.Count);
                string used_string = SoundBankStrings.stealing[nu];
                AkSoundEngine.PostEvent(used_string, primaryPlayer.gameObject);
            }



        }
        //public void HandleItemPurchasedHook(Action<PlayerController, ShopItemController> orig, PlayerController self, ShopItemController item)
        //{
        //    try
        //    {
        //        orig(self, item);
        //    }
        //    catch
        //    {

        //    }
        //    GameManager instance = GameManager.Instance;
        //    PlayerController primaryPlayer; //= instance.PrimaryPlayer;
        //    //ETGModConsole.Log("Vicotry Music");
        //    if (instance == null)
        //    {
        //        primaryPlayer = null;
        //    }
        //    else
        //    {
        //        //ETGModConsole.Log("HandleItemPurchasedHook");
        //        primaryPlayer = instance.PrimaryPlayer;
        //        //AkSoundEngine.PostEvent("Play_2", primaryPlayer.gameObject);
        //    }



        //}
        public virtual void HandleRoomClearRewardHook(Action<RoomHandler> orig, RoomHandler self)
        {
            try
            {
                orig(self);
            }
            catch
            {

            }


            GameManager instance = GameManager.Instance;
            PlayerController primaryPlayer; //= instance.PrimaryPlayer;
            //ETGModConsole.Log("RoomClearReward");
            if (instance == null)
            {
                primaryPlayer = null;
            }
            else
            {
                //int randomNumber1 = Hooks.random1.Next(0, 100);
                //if (randomNumber1 > 66)
                //{
                    primaryPlayer = instance.PrimaryPlayer;
                    System.Random rnd = new System.Random();
                    int nu = rnd.Next(0, SoundBankStrings.roomClear.Count);
                    string used_string = SoundBankStrings.roomClear[nu];
                    AkSoundEngine.PostEvent(used_string, primaryPlayer.gameObject);

                //}
                //ETGModConsole.Log("EndRoomClearReward");


            }



        }
        public void OnDidDamageHook(Action<PlayerController, float, bool, HealthHaver>orig, PlayerController self, float damageDone, bool fatal, HealthHaver target)
        {
            try
            {
                orig(self, damageDone, fatal, target);
            }
            catch
            {

            }
            GameManager instance = GameManager.Instance;
            PlayerController primaryPlayer; //= instance.PrimaryPlayer;
            //ETGModConsole.Log("Vicotry Music");
            if (instance == null)
            {
                primaryPlayer = null;
            }
            else
            {
                int randomNumber1 = Hooks.random1.Next(0, 100);
                //ETGModConsole.Log("OnDidDamageHook");

                
                if (randomNumber1 > 85)
                {
                    primaryPlayer = instance.PrimaryPlayer;
                    System.Random rnd = new System.Random();
                    int nu = rnd.Next(0, SoundBankStrings.battle_cry.Count);
                    string used_string = SoundBankStrings.battle_cry[nu];

                    AkSoundEngine.PostEvent(used_string, primaryPlayer.gameObject);

                }


                
            }



        }
        public void InteractHook(Action<FlippableCover, PlayerController>orig, FlippableCover self, PlayerController player)
        {
            try
            {
                orig(self, player);
            }
            catch
            {

            }

            GameManager instance = GameManager.Instance;
            PlayerController primaryPlayer; //= instance.PrimaryPlayer;
            //ETGModConsole.Log("Vicotry Music");
            if (instance == null)
            {
                primaryPlayer = null;
            }
            else
            {
                //ETGModConsole.Log("InteractHook");
                primaryPlayer = instance.PrimaryPlayer;

                System.Random rnd = new System.Random();
                int nu = rnd.Next(0, SoundBankStrings.table.Count);
                string used_string = SoundBankStrings.table[nu];

                AkSoundEngine.PostEvent(used_string, primaryPlayer.gameObject);
            }

        }
        public void InitializeHook(Action<CompanionController, PlayerController> orig, CompanionController self, PlayerController player)
        {
            try
            {
                orig(self, player);
            }
            catch
            {

            }

            GameManager instance = GameManager.Instance;
            PlayerController primaryPlayer; //= instance.PrimaryPlayer;
            //ETGModConsole.Log("Vicotry Music");
            if (instance == null)
            {
                primaryPlayer = null;
            }
            else
            {
                //ETGModConsole.Log("InitializeHook");
                primaryPlayer = instance.PrimaryPlayer;

                System.Random rnd = new System.Random();
                int nu = rnd.Next(0, SoundBankStrings.companion.Count);
                string used_string = SoundBankStrings.companion[nu];

                AkSoundEngine.PostEvent(used_string, primaryPlayer.gameObject);
            }

        }
        public void OnGunChangedHook(Action6<PlayerController, Gun, Gun, Gun, Gun, bool>orig, PlayerController self, Gun previous, Gun current, Gun previousSecondary, Gun currentSecondary, bool newGun)
        {
            try
            {
                orig(self, previous, current, previousSecondary, currentSecondary, newGun);
            }
            catch
            {

            }       //    
            GameManager instance = GameManager.Instance;
            //PlayerController primaryPlayer; //= instance.PrimaryPlayer;
            //ETGModConsole.Log("Vicotry Music");
            if (instance == null)
            {
                //primaryPlayer = null;
            }
            else
            {
                if (current.gunName == "Casey")
                {

                    System.Random rnd = new System.Random();
                    int nu = rnd.Next(0, SoundBankStrings.light_saber_unsheath.Count);
                    string used_string = SoundBankStrings.light_saber_unsheath[nu];

                    AkSoundEngine.PostEvent(used_string, self.gameObject);
                }

                if (previous.gunName == "Casey")
                {
                    //ETGModConsole.Log("SheathSoundnotworking");
                    //string used_string = SoundBankStrings.light_saber_sheath[0];
                    AkSoundEngine.PostEvent("LightSaber_sheath", self.gameObject);
                }

            }





        }
        public void ReflectedHook(Action<Projectile> orig, Projectile self)
        {
            try
            {
                orig(self);
            }

            catch { }
            GameManager instance = GameManager.Instance;
            PlayerController primaryPlayer; //= instance.PrimaryPlayer;
            //ETGModConsole.Log("Vicotry Music");
            if (instance == null)
            {
                primaryPlayer = null;
            }
            else
            {
                primaryPlayer = instance.PrimaryPlayer;
                if (primaryPlayer.CurrentGun.gunName == "Casey")
                {
                    AkSoundEngine.PostEvent("LightSaber_reflect", self.gameObject);
                }
                
            }

               

        }
        public void HandleKnockbackHook(Action<Projectile, SpeculativeRigidbody, PlayerController, bool, bool> orig,
            Projectile self, SpeculativeRigidbody rigidbody, PlayerController player, bool killedTarget = false, bool alreadyPlayerDelayed = false)
        {
            try
            {
                orig(self, rigidbody, player, killedTarget, alreadyPlayerDelayed);
            }
            catch
            {

            }

            GameManager instance = GameManager.Instance;

            if (instance == null)
            {

            }
            else
            {
                if (self.PossibleSourceGun != null)
                {
                    if (self.PossibleSourceGun.gunName == "Casey" & self.Owner is PlayerController)
                    {
                        //ETGModConsole.Log("Knockback " + self.objectImpactEventName);//rigidbody.name);
                        //ETGModConsole.Log("Knockback " + self.enemyImpactEventName);
                        //ETGModConsole.Log("Knockback " + self.IsBulletScript);

                        System.Random rnd = new System.Random();
                        int nu = rnd.Next(0, SoundBankStrings.light_saber_damage.Count);
                        string used_string = SoundBankStrings.light_saber_damage[nu];

                        AkSoundEngine.PostEvent(used_string, self.gameObject);

                    }

                }



            }
        }
        public void HandleCopDeathHook(Action<CompanionController, Vector2>orig, CompanionController self, Vector2 obj)
        {
            try
            {
                orig(self, obj);
            }
            catch
            {

            }

            AkSoundEngine.PostEvent("OnCopDeath", self.gameObject);

        }
        public void HandleDodgerollHook(Action<Gun, float>orig, Gun self, float fullDodgeTime)
        {
            try
            {
                orig(self, fullDodgeTime);
            }
            catch
            {

            }
            
            int nu = random1.Next(0, SoundBankStrings.rey.Count);
            string used_string = SoundBankStrings.rey[nu];

            AkSoundEngine.PostEvent(used_string, self.gameObject);


        }
        public void PlayerWalkedInHook(Action<BashelliskIntroDoer, PlayerController, List<tk2dSpriteAnimator>> orig, BashelliskIntroDoer self, PlayerController player, List<tk2dSpriteAnimator> animators)
        {
            try { orig(self, player, animators); }
            catch
            {

            }

            AkSoundEngine.PostEvent("serpent", self.gameObject);

        }
        public void AcquirePassiveItemHook(Action<PlayerController, PassiveItem> orig, PlayerController self, PassiveItem item)
        {
            try { orig(self, item); }
            catch
            {

            }
            int randomNumber1 = Hooks.random1.Next(0, 100);
            //ETGModConsole.Log("OnDidDamageHook");


            if (randomNumber1 > 85)
            {

                AkSoundEngine.PostEvent("i_need_a_weapon", self.gameObject);

            }

        }
        private static System.Random random1 = new System.Random();
        
    }

    public class FinnBehaviour : BraveBehaviour
    {
        public void Start()
        {
            
            if (base.healthHaver)
            {
                base.healthHaver.OnDamaged += this.OnDamaged;
                base.healthHaver.OnPreDeath += this.OnPreDeath;
            }
        }
        private void OnDamaged(float resultValue, float maxValue, CoreDamageTypes damageTypes, DamageCategory damageCategory, Vector2 damageDirection)
        {
            GameManager instance = GameManager.Instance;
            PlayerController primaryPlayer; //= instance.PrimaryPlayer;

            if (instance == null)
            {
                primaryPlayer = null;
            }
            else 
            {
                primaryPlayer = instance.PrimaryPlayer;
                //ETGModConsole.Log("HIT");

                System.Random rnd = new System.Random();
                int nu = rnd.Next(0, SoundBankStrings.hit.Count);
                string used_string = SoundBankStrings.hit[nu];

                AkSoundEngine.PostEvent(used_string, primaryPlayer.gameObject);
            }
        }
        private void OnPreDeath(Vector2 obj)
        {
            GameManager instance = GameManager.Instance;
            PlayerController primaryPlayer; //= instance.PrimaryPlayer;

            if (instance == null)
            {
                primaryPlayer = null;
            }
            else
            {
                primaryPlayer = instance.PrimaryPlayer;
                //ETGModConsole.Log("HIT");

                AkSoundEngine.PostEvent("OnCopDeath", primaryPlayer.gameObject);
            }

        }
    }
    public class FinnGun
    {
        public static PlayerController AddSounds(PlayerController player)
        {
            GameManager instance = GameManager.Instance;

            if (instance == null)
            {
                return player;
            }
            else
            {
                for (int i = 0; i < player.inventory.AllGuns.Count; i++)
                {
                    Gun gun = player.inventory.AllGuns[i];

                    if (gun.gunName == "Rogue Special")
                    {
                        //ETGModConsole.Log("Found gun");
                        gun.PreventNormalFireAudio = true;

                        gun.OverrideNormalFireAudioEvent = "blast2";

                    }
                    if (gun.gunName == "Casey")
                    {
                        //gun.PreventNormalFireAudio = true;
                        //gun.OverrideNormalFireAudioEvent = "blast2";


                        //gun.gunSwitchGroup = "Lightsaber";
                        gun.reloadTime /= 2;
                        //ETGModConsole.Log(gun.gunSwitchGroup);
                        //ETGModConsole.Log(gun.alternateSwitchGroup);

                        ProjectileVolleyData volley = gun.Volley;
                        if (gun.Volley != null && gun.Volley.projectiles.Count == 1 && gun.Volley.projectiles[0].shootStyle == ProjectileModule.ShootStyle.Charged)
                        {

                            for (int g = 0; g < volley.projectiles.Count; g++)
                            {
                                ProjectileModule projectileModule = volley.projectiles[g];

                                for (int x = 0; x < projectileModule.chargeProjectiles.Count; x++)
                                {

                                    ProjectileModule.ChargeProjectile chargeProjectile = projectileModule.chargeProjectiles[x];
                                    chargeProjectile.ChargeTime /= 2;

                                }

                            }

                        }
                    }
                }

                return player;
            }
        }
  
    }
    public class JetPackSpeed
    {
        public static void MotionModifier(ref Vector2 voluntaryVel, ref Vector2 involuntaryVel)
        {
            //ETGModConsole.Log("Modifying speed");
            voluntaryVel = voluntaryVel * 0.25f;
        }

    }

}
