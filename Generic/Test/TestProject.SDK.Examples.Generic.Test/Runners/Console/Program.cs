using System.Reflection;
using TestProject.SDK.Examples.Generic.Test;

namespace TestProject.SDK.Examples.Runners.Console
{
	class Program
	{
		private static string DevToken = "YOUR_DEV_TOKEN";

		static void Main(string[] args)
		{
			RunBasicTest();
			RunExtendedTest();
			RunProxyTest();

			System.Console.ReadKey();
		}

		static void RunBasicTest()
		{
			using (Runner runner = RunnerFactory.Instance.Create(DevToken))
			{
				// Create test
				var test = new BasicTest();

				// Run test
				runner.Run(test);
			}
		}

		static void RunExtendedTest()
		{
			using (Runner runner = RunnerFactory.Instance.Create(DevToken))
			{
				// Create test
				var test = new ExtendedTest();
				test.a = 1;
				test.b = 1;
				test.expectedResult = 2;

				// Run test
				runner.Run(test);
			}
		}

		static void RunProxyTest()
		{
			using (Runner runner = RunnerFactory.Instance.Create(DevToken))
			{
				// Create test
				var test = new ProxyTest();
				test.a = 1;
				test.b = 1;
				test.expectedResult = 2;

                /**
                * Load proxy assembly into memory to allow SDK finding it's classes
                * This is only required when running the action proxy in Debug mode via IDE
                * This not not needed when running from TestProject platform
                */
				Assembly.LoadFrom("AddonProxy.dll");

				// Run test
				runner.Run(test);
			}
		}
	}
}