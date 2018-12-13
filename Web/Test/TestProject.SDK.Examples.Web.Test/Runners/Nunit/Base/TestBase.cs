using System.Reflection;
using TestProject.SDK.Examples.Web.Test;

namespace TestProject.SDK.Examples.Web.Runners.Nunit.Base
{
	public class TestBase : Configuration
	{
		protected void RunTest(Runner runner)
		{
			var test = new BasicTest
			{
				name = "John Smith",
				password = "12345",
				country = "United States",
				address = "5000 Highway 7 East",
				email = "john.smith@tertproject.io",
				phone = "+1 (905) 515-2000"
			};

			// Run action
			runner.Run(test);
		}

		protected void RunExtendedTest(Runner runner)
		{
			// Run the extended test with default values
			runner.Run(new ExtendedTest(), true);
		}

		protected void RunProxyTest(Runner runner)
		{
			/**
			* Load proxy assembly into memory to allow SDK finding it's classes
			* This is only required when running the action proxy in Debug mode via IDE
			* This not not needed when running from TestProject platform
			*/
			Assembly.LoadFrom("AddonProxy.dll");
			runner.Run(new ProxyTest(), true);
		}
	}
}