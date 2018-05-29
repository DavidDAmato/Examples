using System;
using System.Linq;
using NUnit.Framework;

namespace SeleniumTests
{
	[TestFixture]
	public class Tests : TestBaseSetup
	{
		[Test()]
		public void AverageProcessingTime()
		{
			// make sure average processing time is displayed, an interger and greater than 1. 
			Assert.IsTrue(GetElement(Page.AverageProcessingTimeBy).Displayed);
			Assert.IsTrue(GetElement(Page.AverageProcessingTimeBy).Enabled, "Average processing time wasn't enabled");

			// seconds sometimes loads without the time before it, wait for a digit. 
			this.Wait.Until(d => d.FindElement(Page.AverageProcessingTimeBy).Text.Any(t => char.IsDigit(t)));

			// ignore case sensitivity
			var text = GetElement(Page.AverageProcessingTimeBy).Text.ToLower();
			Assert.IsTrue(text.Any(char.IsDigit), "No numbers were displayed in average processing time.");
			for (var i = 0; i < text.IndexOf(" ", StringComparison.InvariantCultureIgnoreCase); i++)
			{
				Assert.IsTrue(char.IsDigit(text[i]), $"Index {i} was not a digit.");
			}
			Assert.IsTrue(text.Contains("seconds") || text.Contains("minutes") || text.Contains("hours"), "no time unit was listed");	
		}

		[Test()]
		public void ByOrderQuanity()
		{
			Assert.IsTrue(GetElement(Page.ByOrderQuanityPieChartBy).Displayed, "Order Quantity wasn't displayed");
			Assert.IsTrue(GetElement(Page.ByOrderQuanityPieChartBy).Enabled, "Order Quantity wasn't enabled");

			// the image is sometimes displayed and enabled previous to having accessiable css.
			this.Wait.Until(d => d.FindElement(Page.ByOrderQuanityPieChartBy).GetCssValue("color") == "rgba(153, 153, 153, 1)");
			Assert.IsTrue(GetElement(Page.ByOrderQuanityPieChartBy).GetCssValue("background-color") == "rgba(0, 0, 0, 0)", "Order quanity css value background-color was not correct.");
			Assert.IsTrue(GetElement(Page.ByOrderQuanityPieChartBy).GetCssValue("height") == "104px", "Order quanity css value height was not correct.");
			Assert.IsTrue(GetElement(Page.ByOrderQuanityPieChartBy).GetCssValue("width") == "212px", "Order quanity css value width was not correct.");
		}
	}
}
