


using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using NUnit.Framework;

namespace ApiTests
{
	public static class ApiUtil
	{
	

		/// <summary>
		/// </summary>
		/// <returns>HttpClient</returns>
		public static HttpClient CreateHttpClient(string baseUrl)
		{
			var cookieContainer = new CookieContainer();
			var uri = new Uri(baseUrl);
			var handler = new HttpClientHandler() { CookieContainer = cookieContainer };
			var client = new HttpClient(handler) { BaseAddress = uri };
			client.DefaultRequestHeaders.Accept.Clear();
			client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			return client;
		}
		
		public static string GetGetResponse(string url)
		{
			var actualResult = string.Empty;
			using (var client = CreateHttpClient(url))
			{
				//Note .result keeps us in the current thread.
				HttpResponseMessage response = client.GetAsync(url).Result;     
				Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
				using (var content = response.Content)
				{
					actualResult = content.ReadAsStringAsync().Result;
				}
			}
			if (actualResult == null || actualResult == string.Empty)
			{
				Console.WriteLine($"actualResult was null or empty, error?");
			}
			Console.WriteLine($"actualResult: {actualResult}");
			return actualResult;
		}





	}
}
