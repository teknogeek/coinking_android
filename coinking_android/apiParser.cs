using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Json;
using System.IO;

namespace coinking_android
{
	public static class apiParser
	{
		public static List<string> getApiInfo(string apiKey)
		{
			List<string> apiInfoList = new List<string>();

			WebRequest req = HttpWebRequest.Create("https://coinking.io/api.php?key=" + apiKey + "&type=myinfo&output=json");
			using(Stream responseStream = req.GetResponse().GetResponseStream())
			{
				JsonObject userInfo = (JsonObject)JsonObject.Load(responseStream);

				string userHashrate = "Hashrate: " + userInfo["userHashrate"].ToString() + " KH/s";
				string validShares = "Valid Shares: " + userInfo["userValidShares"];
				string invalidShares = "Invalid Shares: " + userInfo["userInvalidShares"] + " (" + userInfo["userInvalidPercent"] + "%)";
				string currentCoin = "Currently Mining: " + UCFirst(userInfo["currentCoin"]) + " (" + userInfo["currentCoinNickname"] + ")";

				apiInfoList.Add(userHashrate);
				apiInfoList.Add(currentCoin);
				apiInfoList.Add(validShares);
				apiInfoList.Add(invalidShares);

				return apiInfoList;
			}
		}

		static string UCFirst(string s)
		{
			// Check for empty string.
			if (string.IsNullOrEmpty(s))
			{
				return string.Empty;
			}

			// Return char and concat substring.
			return char.ToUpper(s[0]) + s.Substring(1);
		}
	}
}

