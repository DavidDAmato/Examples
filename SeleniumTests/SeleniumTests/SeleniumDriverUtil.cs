using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumTests
{
	public static class SeleniumDriverUtil
	{
		public static IWebDriver CreateChromeDriver()
		{
			// TODO var chromeOptions = new ChromeOptions(); and set opts
			return new ChromeDriver();
		}
	}
}
