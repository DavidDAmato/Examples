using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Drawing;
using SeleniumTests.PageObjects;
using SeleniumTests.Selenium;

namespace SeleniumTests
{
	public class TestBaseSetup
	{
		protected IWebDriver Driver { get; private set; }
		protected Page Page { get; private set; }
		protected WebDriverWait Wait { get; private set; }
		private const string PageToLoad = "https://shapeshift.io/#/coins";

		public TestBaseSetup()
		{
			this.Driver = SeleniumDriverUtil.CreateChromeDriver();
			// set the size so if other people have a different resolution things still work for sizing checks.
			this.Driver.Manage().Window.Size = new Size(1024, 768);
			this.Wait = new WebDriverWait(Driver, new TimeSpan(0, 0, 10));
			this.Page = new Page(this.Driver);
			Driver.Navigate().GoToUrl(PageToLoad);
		}

		[OneTimeTearDown]
		public void TearDown()
		{
			this.Driver.Close();
			this.Driver.Dispose();
		}

		// Takes a by and returns the IWebElement. Used to refresh elements on pages that change frequently (ajax ect.)
		public IWebElement GetElement(By by)
		{
			return this.Wait.Until(d => d.FindElement(by));
		}
	}
}
