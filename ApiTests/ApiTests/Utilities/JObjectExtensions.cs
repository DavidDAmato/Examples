using Newtonsoft.Json.Linq;

namespace ApiTests.Utilities
{
	public static class JObjectExtensions
	{
		/// <summary>
		/// Extract a float from a json node without try parsing all the time.
		/// </summary>
		/// <param name="json"></param>
		/// <param name="node"></param>
		/// <returns></returns>
		public static float GetFloat(this JObject json, string node)
		{
			float num; // don't do inline declares it only works in c#7+ and most places still use 6.
			float.TryParse(json[node].ToString(), out num);
			return num;
		}

	}
}
