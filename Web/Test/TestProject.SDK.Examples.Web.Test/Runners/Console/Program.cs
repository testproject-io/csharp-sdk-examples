using System.Reflection;
using TestProject.Common.Enums;
using TestProject.SDK.Examples.Web.Test;

namespace TestProject.SDK.Examples.Web.Runners.Console
{
	class Program
	{
		private static string DevToken = "YOUR_DEV_TOKEN";
		private static AutomatedBrowserType BrowserType = AutomatedBrowserType.Chrome; // Specify the target browser

		static void Main(string[] args)
		{
			using (Runner runner = new RunnerBuilder(DevToken).AsWeb(BrowserType).Build())
			{
				runner.Run(new BasicTest());
				runner.Run(new ExtendedTest(), true);

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
}