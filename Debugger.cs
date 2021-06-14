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


namespace SWFinn
{
    public class RunTest : MonoBehaviour
    {
        public static void runtest(string[] args)
        {
            ETGModConsole.Log("Running Test");
            PlayerController primaryPlayer = Gungeon.Game.PrimaryPlayer;

            //AkSoundEngine.PostEvent("Footstepsadfsafd", primaryPlayer.gameObject);

            AkSoundEngine.PostEvent(args[0], primaryPlayer.gameObject);

            ETGModConsole.Log("AKVersion: " + AkSoundEngine.AK_SOUNDBANK_VERSION.ToString());


            //Result of soundbank load: AK_WrongBankVersion.
            //Version: 2.1.9
        }
        public static void testname(string[] args)
        {
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
                ETGModConsole.Log(name);
            }
            else
            {
                ETGModConsole.Log("not custom character");
            }
        }
        public static void getGunName(string[] args)
        {
            GameManager instance = GameManager.Instance;
            if (instance == null)
            {

            }
            else
            {
                PlayerController primaryPlayer = instance.PrimaryPlayer;
                List<int> list = primaryPlayer.startingGunIds;
                //                int id = primaryPlayer.inventory.CurrentGun.PickupObjectId;
                for (int i = 0; i < list.Count; i++)
                {
                    ETGModConsole.Log("Current Gun ID: " + list[i]);
                }

                for (int i = 0; i < primaryPlayer.inventory.AllGuns.Count; i++)
                {
                    Gun gun = primaryPlayer.inventory.AllGuns[i];
                    ETGModConsole.Log("Gun name: " + gun.gunName);

                }




            }

        }
        public static void caseydebugger(string[] notused)
        {
            GameManager instance = GameManager.Instance;
            if (instance == null)
            {

            }
            else
            {
                Debug.Log("[Finn] Casey Debugger");
                PlayerController primaryPlayer = instance.PrimaryPlayer;
                //List<int> list = primaryPlayer.startingGunIds;
                //                int id = primaryPlayer.inventory.CurrentGun.PickupObjectId;
                for (int ii = 0; ii < primaryPlayer.inventory.AllGuns.Count; ii++)
                {
                    Gun gun = primaryPlayer.inventory.AllGuns[ii];
                    if (gun.gunName == "Casey")
                    {
                        //ProjectileModule mod = gun.GetComponent<ProjectileModule>();
                        ProjectileModule mod = gun.DefaultModule;
                        
                        //ProjectileModule.ChargeProjectile cp = gun.GetComponent<ProjectileModule.ChargeProjectile>();

                        ProjectileVolleyData volley = gun.Volley;
                        Dictionary< ProjectileModule, ModuleShootData> m_moduleData = gun.RuntimeModuleData;
                        //if (gun.Volley != null)
                        //{
                        //    for (int x = 0; x < gun.Volley.projectiles.Count; x++)
                        //    {
                        //        ModuleShootData moduleShootData = new ModuleShootData();
                        //        Debug.Log("gun ammo: " + gun.ammo);
                        //        if (gun.ammo < gun.Volley.projectiles[x].GetModNumberOfShotsInClip(gun.CurrentOwner))
                        //        {
                        //            moduleShootData.numberShotsFired = gun.Volley.projectiles[x].GetModNumberOfShotsInClip(gun.CurrentOwner) - gun.ammo;
                        //        }
                        //        m_moduleData.Add(gun.Volley.projectiles[x], moduleShootData);
                        //        Debug.Log("m_moduleData: " + m_moduleData.ToString());
                        //    }
                        //}

                        if (gun.Volley == null && gun.singleModule.shootStyle == ProjectileModule.ShootStyle.Charged)
                        {
                            //bool fuckle = true;
                            Debug.Log("Volley ==null, shootstyle = charged");
                        }
                        if (gun.Volley != null && gun.Volley.projectiles.Count == 1 && gun.Volley.projectiles[0].shootStyle == ProjectileModule.ShootStyle.Charged)
                        {
                            //bool fuckle2 = true;
                            Debug.Log("Volley !=null, projectilecount = 1, shootstyle = charged");

                            //ProjectileVolleyData volley = this.Volley;
                            for (int i = 0; i < volley.projectiles.Count; i++)
                            {
                                ProjectileModule projectileModule = volley.projectiles[i];

                                for (int x=0; x< projectileModule.chargeProjectiles.Count; x++)
                                {
                                    Debug.Log("ChargeProjectile: " + x);
                                    ProjectileModule.ChargeProjectile chargeProjectile = projectileModule.chargeProjectiles[x];
                                    Debug.Log("Charge LongestChargeTime: " + projectileModule.LongestChargeTime);
                                    Debug.Log("Charge ChargeTime: " + chargeProjectile.ChargeTime);
                                    Debug.Log("Reflects Bullets: " + chargeProjectile.ReflectsIncomingBullets);
                                    
                                    //chargeProjectile.ChargeTime = .25f;

                                }

                                
                                for (int y=0; y<projectileModule.projectiles.Count; y++)
                                {
                                    Projectile projectile = projectileModule.projectiles[y];
                                    ETGModConsole.Log("Projectile Force: " + projectile.baseData.force);

                                }
                                


                            }
                                //if (projectileModule.shootStyle == ProjectileModule.ShootStyle.Charged)
                                //{
                                //    ModuleShootData moduleShootData2 = m_moduleData[projectileModule];
                                //    ProjectileModule.ChargeProjectile chargeProjectile2 = projectileModule.GetChargeProjectile(moduleShootData2.chargeTime);
                                //    if (chargeProjectile2 != null)// && chargeProjectile2.Projectile)
                                //    {
                                //        Debug.Log("Casey Charge Time: " +chargeProjectile2.ChargeTime);
                                //        Debug.Log("Reflects Bullets: " + chargeProjectile2.ReflectsIncomingBullets);
                                //        Debug.Log("Has sound effect: " + chargeProjectile2.UsesAdditionalWwiseEvent);
                                        
                                //    }
                                //    else
                                //    {
                                //        Debug.Log("No chargeProjectile");
                                //    }
                                //}

                                //else
                                //{
                                //    Debug.Log("No ProjectileModule, " + i);
                                //}
                            






                        }


                        if (mod !=null)
                        {
                            Debug.Log("ProjectileMod: " + mod.shootStyle);
                            Debug.Log("ProjectileMod longestchargetime: " + mod.LongestChargeTime);
                            Debug.Log("ProjectileMod maxchargetime: " + mod.maxChargeTime);
                            //Debug.Log("ProjectileMod chargetime: " + mod.Re);

                        }
                        else
                        {
                            Debug.Log("No ProjectileMod");
                        }


                        //if (cp != null)
                        //{
                        //    Debug.Log("ChargeProjectile chargetime : " + cp.ChargeTime);
                        //    Debug.Log("ChargeProjectile Reflects bullets: " + cp.ReflectsIncomingBullets);
                        //}

                        //else
                        //{
                        //    Debug.Log("No ChargeProjectile");
                        //}

                        Debug.Log("Reload time" + gun.reloadTime);
                        Debug.Log("gun class" + gun.gunClass);
                        Debug.Log("herosword" + gun.IsHeroSword);


                    }
                }

                Debug.Log("[Finn] End Casey Debugger");


            }
        }
        public static void testgunaudio(string[] notused)
        {
            GameManager instance = GameManager.Instance;
            PlayerController primaryPlayer = instance.PrimaryPlayer;

            for (int ii = 0; ii < primaryPlayer.inventory.AllGuns.Count; ii++)
            {
                Gun gun = primaryPlayer.inventory.AllGuns[ii];
                if (gun.gunName == "Casey")
                {
                    ETGModConsole.Log("gunswitchGroup: " + gun.gunSwitchGroup);
                    ETGModConsole.Log("OverrideFinalAudio: " + gun.OverrideFinaleAudio);
                    ETGModConsole.Log("OverrideNormalAudio: " + gun.OverrideNormalFireAudioEvent);

                    //AkSoundEngine ak = gun.GetComponent<AkSoundEngine>();
                    //Dictionary<string, string> additionalshootsounds = gun.AdditionalShootSoundsByModule;

                    ProjectileVolleyData volley = gun.Volley;
                    if (gun.Volley != null && gun.Volley.projectiles.Count == 1 && gun.Volley.projectiles[0].shootStyle == ProjectileModule.ShootStyle.Charged)
                    {

                        for (int g = 0; g < volley.projectiles.Count; g++)
                        {
                            ProjectileModule projectileModule = volley.projectiles[g];
                            string runtimeguid = projectileModule.runtimeGuid;
                            ETGModConsole.Log("runtimeguid: " + runtimeguid);

                            //ETGModConsole.Log("AdditonalShootSounds: "+gun.AdditionalShootSoundsByModule[runtimeguid]);

                            for (int x = 0; x < projectileModule.chargeProjectiles.Count; x++)
                            {

                                ProjectileModule.ChargeProjectile chargeProjectile = projectileModule.chargeProjectiles[x];
                                ETGModConsole.Log("additionalwiseevent : " + chargeProjectile.AdditionalWwiseEvent);

                            }

                        }

                    }
                }
            }

        }

        public static void Get(string[] notused)
        {
            PrototypeDungeonRoom[] prototypedungeonrooms = UnityEngine.GameObject.FindObjectsOfType<PrototypeDungeonRoom>();

            Dungeon d = GameManager.Instance.Dungeon;
            int count = d.data.rooms.Count;

            ETGModConsole.Log("There are rooms:" + count);
            ETGModConsole.Log("There are prototyperooms: " + prototypedungeonrooms.Length.ToString());

            for (int i = 0; i < prototypedungeonrooms.Length; i++)
            {
                PrototypeDungeonRoom room = prototypedungeonrooms[i];
                if (room.name == "DraGunRoom01")
                {
                    ETGModConsole.Log("Found DraGunRoom01");

                }
            }
            //foreach (RoomHandler roomHandler in d.data.rooms)
            for (int i = 0; i < count; i++)
            {
                RoomHandler roomHandler = d.data.rooms[i];
                string roomname = roomHandler.GetRoomName();
                ETGModConsole.Log("roomname: " + roomname);
                
            }

        }
        public static void GetPlayerStats(string[] notused)
        {
            GameManager instance = GameManager.Instance;

            PlayerController primaryPlayer = instance.PrimaryPlayer;
            //for (int i = 0; i < PlayerStats.StatType; i++)
            //{
            //    ETGModConsole.Log()
            //}

            float accuracy = primaryPlayer.stats.GetBaseStatValue(PlayerStats.StatType.Accuracy);
            float RateOfFire = primaryPlayer.stats.GetBaseStatValue(PlayerStats.StatType.RateOfFire);
            ETGModConsole.Log(String.Format("accuracy: {0} rof: {1}", accuracy, RateOfFire));

        }



    }


    public class GRandomTeleport
    {
        public static void TeleportToSpecificRoom(string[] args)
        {
            //(this.dungeonFloors[i].dungeonSceneName == ss_ratscene)
            string roomname = args[0];

            //ETGModConsole.Log("ARGS 0 == " + roomname);
            bool flag = false;

            RoomHandler roomHandler;
            Dungeon d = GameManager.Instance.Dungeon;
            int count = d.data.rooms.Count;
            for (int i = 0; i < count; i++)
            //foreach (RoomHandler roomHandler in d.data.rooms)
            {
                roomHandler = d.data.rooms[i];
                if (roomname == "boss")
                {

                    if (roomHandler.area.PrototypeRoomCategory == PrototypeDungeonRoom.RoomCategory.BOSS &&
                            roomHandler.area.PrototypeRoomBossSubcategory == PrototypeDungeonRoom.RoomBossSubCategory.FLOOR_BOSS)
                    {

                        {
                            roomname = roomHandler.GetRoomName();
                            flag = true;
                            ETGModConsole.Log("Teleporting to: " + roomname);
                            Tele(roomHandler);
                            break;
                        }


                    }
                }
                else
                {
                    if (roomHandler.GetRoomName() == roomname)
                    {
                        flag = true;
                        ETGModConsole.Log("Teleporting to: " + roomname);
                        Tele(roomHandler);

                    }
                }


            }

            if (!flag)
            {
                ETGModConsole.Log(roomname + " Not Found");
            }




        }


        public static void Tele(RoomHandler room)
        {
            IntVector2 Epicenter = room.Epicenter;

            Vector2 vEpicenter = Epicenter.ToVector2();
            if (room.GetRoomName() == "DraGunRoom01")
            {
                vEpicenter -= new Vector2(0.0f, 5.0f);
            }



            PlayerController primaryPlayer = Gungeon.Game.PrimaryPlayer;
            primaryPlayer.TeleportToPoint(vEpicenter, true);
          

        }




    }
}
