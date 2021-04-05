using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaleWorlds.Library;

namespace TOW_Core
{
    public class Utils
    {
		public static string GetRandomScene()
		{
			var filterednames = new List<string>();
			string pickedname = "towmm_menuscene_01";
			var path = BasePath.Name + "Modules/TOW_Environment/SceneObj/";
			if (Directory.Exists(path))
			{
				var dirnames = Directory.GetDirectories(path);
				filterednames = dirnames.Where(x => x.Contains("towmm_")).ToList();
			}
			if (filterednames.Count > 0)
			{
				var rng = new Random();
				var index = rng.Next(0, filterednames.Count);
				pickedname = filterednames[index];
				string[] s = pickedname.Split('/');
				pickedname = s[s.Length - 1];
				
			}
			return pickedname;
		}
	}
}
