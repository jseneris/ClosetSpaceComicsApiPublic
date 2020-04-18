using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosetSpaceComics.Service.Code
{
	public static class CommonCode
	{
		public static String GetSeoFriendlyName(String name)
		{
			var spaceLess = name.Replace(' ', '-');
			var tempName = String.Concat(spaceLess.Where(x => x == '-' || Char.IsLetterOrDigit(x))).ToLowerInvariant();

			var chars = new List<char>();
			var lastChar = ' ';

			foreach (var character in tempName)
			{
				var temp = lastChar;
				lastChar = character;

				if (character == '-' && temp == '-') continue;

				chars.Add(character);
			}

			if (chars.Last() == '-') chars.RemoveAt(chars.Count() - 1);
			tempName = String.Concat(chars);

			return tempName;
		}
	}
}
