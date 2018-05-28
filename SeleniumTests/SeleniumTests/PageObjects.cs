using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SeleniumTests
{
	public class Page
	{
		private IWebDriver Driver { get; set; }

		public By ByOrderQuanityPieChartBy => By.Id("pie");

		public By AverageProcessingTimeBy =>
			By.CssSelector(
				"body > div.stats.ng-scope > div > div > div.col-md-4.raw-data > div:nth-child(2) > div:nth-child(1) > div > div.panel-body > p");

		public Page(IWebDriver Driver)
		{
			this.Driver = Driver;
			PageFactory.InitElements(this.Driver, this);
		}

	}
}
