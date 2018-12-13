using NUnit.Framework;
using System.Reflection;
using TestProject.SDK.Examples.IOS.Test;

namespace TestProject.SDK.Examples.IOS.Runners.Nunit
{
	[TestFixture]
	public class IOSTests
	{
		public static string DevToken = "YOUR_DEV_TOKEN";
		public static string DeviceUDID = "DEVICE_UDID";
		public static string DeviceName = "DEVICE_NAME";
		public static string BundleId = "io.testproject.Demo";

		Runner runner;

		[SetUp]
		public void SetUp()
		{
			runner = RunnerFactory.Instance.CreateIOS(DevToken, DeviceUDID, DeviceName, BundleId);
		}

		[TearDown]
		public void TearDown()
		{
			runner.Dispose();
		}

		[Test]
		public void RunBasicTest()
		{
			runner.Run(new BasicTest());
		}

		[Test]
		public void RunExtendedTest()
		{
			runner.Run(new ExtendedTest(), true);
		}

		[Test]
		public void RunProxyTest()
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