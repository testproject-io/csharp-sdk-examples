using System.Reflection;
using TestProject.SDK.Examples.IOS.Test;

namespace TestProject.SDK.Examples.IOS.Runners.Console
{
	class Program
	{
		public static string DevToken = "YOUR_DEV_TOKEN";
		public static string DeviceUDID = "DEVICE_UDID";
		public static string DeviceName = "DEVICE_NAME";
		public static string BundleId = "io.testproject.Demo";

		static void Main(string[] args)
		{
			RunBasicTest();
			RunExtendedTest();
			RunProxyTest();

			System.Console.ReadKey();
		}

		static void RunBasicTest()
		{
			using (Runner runner = RunnerFactory.Instance.CreateIOS(DevToken, DeviceUDID, DeviceName, BundleId))
				runner.Run(new BasicTest());
		}

		static void RunExtendedTest()
		{
			using (Runner runner = RunnerFactory.Instance.CreateIOS(DevToken, DeviceUDID, DeviceName, BundleId))
				runner.Run(new ExtendedTest(), true);
		}

		static void RunProxyTest()
		{
			using (Runner runner = RunnerFactory.Instance.CreateIOS(DevToken, DeviceUDID, DeviceName, BundleId))
			{
				/**
				* Load proxy assembly into memory to allow SDK finding it's classes
				* This is only required when running the action proxy in Debug mode via IDE
				* This not not needed when running from TestProject platform
				*/
				Assembly.LoadFrom("AddonProxy.dll");

				// Run the test
				runner.Run(new ProxyTest(), true);
			}
		}
	}
}