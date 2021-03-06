using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using Ionic.Zip;
using UnityEngine;

namespace SWFinn.Audio
{

	public class ResourceLoaderSoundbanks
	{

		public void AutoloadFromModZIPOrModFolder(string path)
		{
			int FilesLoaded = 0;
			if (File.Exists(path + ".zip"))
			{
				Debug.Log("Zip Found");
				ZipFile ModZIP = ZipFile.Read(path + ".zip");
				if (ModZIP != null && ModZIP.Entries.Count > 0)
				{
					foreach (ZipEntry entry in ModZIP.Entries)
					{
						if (entry.FileName.EndsWith(".bnk"))
						{
							using (MemoryStream ms = new MemoryStream())
							{
								entry.Extract(ms);
								ms.Seek(0, SeekOrigin.Begin);
								LoadSoundbankFromStream(ms, entry.FileName.ToLower().Replace(".bnk", string.Empty));
								FilesLoaded++;
							}
						}
					}
					if (FilesLoaded > 0) { return; }
				}
			}
			// Zip file wasn't found. Try to load from Mod folder instead.
			//AutoloadFromPath(AudioResourceLoader.FullPathAutoprocess, "ExpandTheGungeon");
		}

		//public void AutoloadFromPath(string path, string prefix)
		//{
		//	if (string.IsNullOrEmpty(path)) { throw new ArgumentNullException("path", "Path cannot be null."); }
		//	if (string.IsNullOrEmpty(prefix)) { throw new ArgumentNullException("prefix", "Prefix name cannot be null."); }
		//	prefix = prefix.Trim();
		//	if (string.IsNullOrEmpty(prefix)) { throw new ArgumentException("Prefix name cannot be an empty (or whitespace only) string.", "prefix"); }
		//	path = path.Replace('/', Path.DirectorySeparatorChar);
		//	path = path.Replace('\\', Path.DirectorySeparatorChar);
		//	if (!Directory.Exists(path))
		//	{
		//		//if (ExpandStats.debugMode)
		//		//{
		//		Console.WriteLine(string.Format("{0}: No autoload directory in path, not autoloading anything. Path='{1}'.", typeof(ResourceLoaderSoundbanks), path));
		//		//}
		//	}
		//	else
		//	{
		//		List<string> list = new List<string>(Directory.GetFiles(path, "*.bnk", SearchOption.AllDirectories));
		//		for (int i = 0; i < list.Count; i++)
		//		{
		//			string text = list[i];
		//			string text2 = text;
		//			text2 = text2.Replace('/', Path.DirectorySeparatorChar);
		//			text2 = text2.Replace('\\', Path.DirectorySeparatorChar);
		//			text2 = text2.Substring(text2.IndexOf(path) + path.Length);
		//			text2 = text2.Substring(0, text2.Length - ".bnk".Length);
		//			bool flag5 = text2.IndexOf(Path.DirectorySeparatorChar) == 0;
		//			if (flag5) { text2 = text2.Substring(1); }
		//			text2 = prefix + ":" + text2;
		//			//if (ExpandStats.debugMode)
		//			//{
		//			Console.WriteLine(string.Format("{0}: Soundbank found, attempting to autoload: name='{1}' file='{2}'", typeof(ResourceLoaderSoundbanks), text2, text));
		//			//}
		//			using (FileStream fileStream = File.OpenRead(text)) { LoadSoundbankFromStream(fileStream, text2); }
		//		}
		//	}
		//}

		private void LoadSoundbankFromStream(Stream stream, string name)
		{
			byte[] array = StreamToByteArray(stream);
			IntPtr intPtr = Marshal.AllocHGlobal(array.Length);
			try
			{
				Marshal.Copy(array, 0, intPtr, array.Length);
				uint num;
				AKRESULT akresult = AkSoundEngine.LoadAndDecodeBankFromMemory(intPtr, (uint)array.Length, false, name, false, out num);
				//if (ExpandStats.debugMode)
				//{
				Console.WriteLine(string.Format("Result of soundbank load: {0}.", akresult));
				//}
			}
			finally
			{
				Marshal.FreeHGlobal(intPtr);
			}
		}

		public static byte[] StreamToByteArray(Stream input)
		{
			byte[] array = new byte[16384];
			byte[] result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				int count;
				while ((count = input.Read(array, 0, array.Length)) > 0) { memoryStream.Write(array, 0, count); }
				result = memoryStream.ToArray();
			}
			return result;
		}
	}
}