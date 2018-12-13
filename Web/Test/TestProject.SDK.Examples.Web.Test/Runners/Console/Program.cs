using System.Reflection;
using TestProject.SDK.Common.Enums;
using TestProject.SDK.Examples.Web.Test;

namespace TestProject.SDK.Examples.Web.Runners.Console
{
	class Program
	{
		private static string DevToken = "YOUR_DEV_TOKEN";
		private static AutomatedBrowserType BrowserType = AutomatedBrowserType.Chrome; // Specify the target browser

		static void Main(string[] args)
		{
			RunBasicTest();
			RunExtendedTest();
			RunProxyTest();
		}

		static void RunBasicTest()
		{
			using (Runner runner = RunnerFactory.Instance.CreateWeb(DevToken, BrowserType))
				runner.Run(new BasicTest());
		}

		static void RunExtendedTest()
		{
			using (Runner runner = RunnerFactory.Instance.CreateWeb(DevToken, BrowserType))
				runner.Run(new ExtendedTest(), true);
		}

		static void RunProxyTest()
		{
			using (Runner runner = RunnerFactory.Instance.CreateWeb(DevToken, BrowserType))
			{
				/**
				* Load proxy assembly into memory to allow SDK finding it's classes
				* This is only required when running the action proxy in Debug mode via IDE 
				* This not not needed when running from TestProject platform
				*/
				Assembly.LoadFrom("AddonProxy.dll");
				runner.Run(new BasicTest(), true);
			}
		}
	}
}