using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using NUnit.Framework;

namespace ApiTests.Utilities
{
	public static class ApiUtil
	{
		/// <summary>
		/// Creates http client
		/// </summary>
		/// <returns>HttpClient</returns>
		public static HttpClient CreateHttpClient(string baseUrl)
		{
			var uri = new Uri(baseUrl);
			var handler = new HttpClientHandler();
			var client = new HttpClient(handler) { BaseAddress = uri };
			client.DefaultRequestHeaders.Accept.Clear();
			client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			return client;
		}

		/// <summary>
		/// Gets a reponse from a URL.
		/// </summary>
		/// <returns>content response as string</returns>
		public static string GetResponse(string url, HttpStatusCode code = HttpStatusCode.OK)
		{
			var result = string.Empty;
			using (var client = CreateHttpClient(url))
			{
				var response = client.GetAsync(url).Result; // .result blocks thread
				Assert.AreEqual(code, response.StatusCode);
				using (var content = response.Content)
				{
					result = content.ReadAsStringAsync().Result;
				}
			}
			if (result == null || result == string.Empty)
			{
				throw new Exception($"Could not parse result using url: {url}");
			}
			Console.WriteLine($"result: \r\n {result}");
			return result;
		}

	}
}
