using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using TestProject.Common.Enums;
using TestProject.SDK.Examples.Web.Test;

namespace TestProject.SDK.Examples.Web.Runners.Nunit
{
	public class ExplicitNameTests
	{
		Runner runner;

		[OneTimeSetUp]
		public void SetUp()
		{
			runner = new RunnerBuilder("YOUR_DEV_TOKEN")
				.WithProjectName("Web Example Project")
				.WithJobName("Web Example Job")
				.AsWeb(AutomatedBrowserType.Chrome).Build();
		}

		[Test]
		public void RunTest()
		{
			// Run test
			runner.Run(new BasicTest());
		}

		[OneTimeTearDown]
		public void TearDown()
		{
			runner.Dispose();
		}
	}
}
