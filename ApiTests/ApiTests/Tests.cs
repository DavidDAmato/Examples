using NUnit.Framework;
using ApiTests.Consts;
using ApiTests.Utilities;
using Newtonsoft.Json.Linq;

namespace ApiTests
{
	[TestFixture]
	public class Tests : TestBaseSetup
	{
		// instead of using a numbers here I would sugguest an approach to pull data from several other sources via a scheduled task so you can do a "fuzzy compare" within a range weekly, daily, hourly ect.
		// to test all rates you could have a class that contains the rates and pairs and iterates over each one. Using a data fetcher would cut down on maintenance of test cases, as well false failures.
		private const int DogeToBtcRate = 1800000;
		private const int BtcToEthRate = 10;
		private const double LtcToEthRate = .15;

		[Test()]
		public void TestRateEndpoint()
		{
			var result = ApiUtil.GetResponse($"{BaseUri}{ApiConsts.RateEndpoint}{Pairs.BtcToDoge}");
			var json = JObject.Parse(result);
			Assert.AreEqual(json[JsonConsts.Pair].ToString().ToLower(), Pairs.BtcToDoge, "Pair was not correct");
			var rate = json.GetFloat(JsonConsts.Rate);
			Assert.IsTrue(rate > DogeToBtcRate && rate < (DogeToBtcRate * 2), "rate was not within specified range");

			var result2 = ApiUtil.GetResponse($"{BaseUri}{ApiConsts.RateEndpoint}{Pairs.BtcToEth}");
			var json2 = JObject.Parse(result2);
			Assert.AreEqual(json2[JsonConsts.Pair].ToString(), Pairs.BtcToEth, "Pair was not correct");
			var rate2 = json2.GetFloat(JsonConsts.Rate);
			Assert.IsTrue(rate2 > BtcToEthRate && rate2 < (BtcToEthRate * 2), "rate was not within specified range");
			
			// ect. iterate
		}

		[Test()]
		public void TestMarketInfo()
		{
			var result = ApiUtil.GetResponse($"{BaseUri}{ApiConsts.MarketInfoEndpoint}{Pairs.LtcToEth}");
			var json = JObject.Parse(result);

			Assert.AreEqual(json[JsonConsts.Pair].ToString().ToLower(), Pairs.LtcToEth, "Pair was not correct");

			// Again theres a bunch of cool ways to build your baseline data based on ourside sources to dynamically choose these values from other apis or a file or stream, it seemed like over kill for a demo.
			var rate = json.GetFloat(JsonConsts.Rate);
			Assert.IsTrue(rate > LtcToEthRate && rate < (LtcToEthRate * 2), "Rate was not within specified range");

			var minerFee = json.GetFloat(JsonConsts.MinerFee);
			Assert.IsTrue(minerFee > 0.0001 && minerFee < 0.003, "MinerFee was not within specified range");

			var limit = json.GetFloat(JsonConsts.Limit);
			Assert.IsTrue(limit > 20 && limit < 100, "Minimum was not within specified range");
			
			var min = json.GetFloat(JsonConsts.Minimum);
			Assert.IsTrue(min > .001 && min < .1, "Minimum was not within specified range");

			var max = json.GetFloat(JsonConsts.MaxLimit);
			Assert.IsTrue(max > 20 && max < 80, "Maximum was not within specified range");

			// once you have dynamic baselines, iterate here as well. 
		}

	}
}
