using System.IO;
using System.Reflection;
using UnityEngine;

namespace SWFinn.Audio
{

    public class AudioResourceLoader
    {

        public static readonly string ResourcesDirectoryName = "SWFinnMod";
        public static readonly string AutoprocessDirectoryName = "Mods/SWFinnMod";
        public static readonly string AutoprocessModPathName = "Mods/SWFinnMod";
        public static readonly string ResourcesAutoprocessDirectoryName = AutoprocessDirectoryName;

        public static readonly string FullPathGame = Path.Combine(Application.dataPath, "..");

        public static readonly string FullPathResources = FullPathGame;
        public static readonly string FullPathAutoprocess = Path.Combine(FullPathResources, AutoprocessDirectoryName);


        public static void InitAudio()
        {
            LoadAllAutoloadResourcesFromModPath(AutoprocessModPathName);
            // LoadAllAutoloadResourcesFromAssembly(Assembly.GetExecutingAssembly(), "ExpandTheGungeon");

            // LoadAllAutoloadResourcesFromPath(FullPathAutoprocess, "ExpandTheGungeon");
        }


        public static void LoadAllAutoloadResourcesFromModPath(string path)
        {
            ResourceLoaderSoundbanks LoaderSoundbanks = new ResourceLoaderSoundbanks();
            LoaderSoundbanks.AutoloadFromModZIPOrModFolder(path);
        }

    }
}