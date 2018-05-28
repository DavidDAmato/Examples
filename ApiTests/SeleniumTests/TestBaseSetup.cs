using System;
using NUnit.Framework;
using System.Drawing;
using System.Net.Http.Headers;

namespace ApiTests
{
	public class TestBaseSetup
	{

	
		public TestBaseSetup()
		{

		}

		[OneTimeTearDown]
		public void TearDown()
		{

		}

	}
}
