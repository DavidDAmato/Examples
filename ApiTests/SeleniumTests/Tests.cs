using System.Collections.Generic;
using NUnit.Framework;
using System.Web.Script.Serialization;
using Newtonsoft.Json.Linq;

namespace ApiTests
{
	[TestFixture]
	public class Tests : TestBaseSetup
	{
		private const string baseUri = "https://shapeshift.io/rate/"; //"https://info.shapeshift.io/api";
		// Ideally you'd have a dynamic object return based on your input objects. Examples of this are the two specific return methods using custom objects.

		[Test()]
		public void TestRateEndpoint()
		{
			var pair = "btc_doge";
			var result = ApiUtil.GetGetResponse($"{baseUri}{pair}");
			JObject json = JObject.Parse(result);
			var rateValue = json["rate"];
			var pairValue = json["pair"];
			Assert.AreEqual(result, "", "Result was not expected.");

		}

		[Test()]
		public void Test2()
		{

		}

	}
}
