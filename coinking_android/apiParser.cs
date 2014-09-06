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
				string currentCoin = "Currently Mining: " + userInfo["currentCoinNickname"];

				apiInfoList.Add(userHashrate);
				apiInfoList.Add(currentCoin);

				return apiInfoList;
			}
		}
	}
}

