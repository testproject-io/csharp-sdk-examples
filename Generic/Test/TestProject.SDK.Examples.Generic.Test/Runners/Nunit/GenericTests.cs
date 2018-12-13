using NUnit.Framework;
using System.Reflection;
using TestProject.SDK.Examples.Generic.Test;

namespace TestProject.SDK.Examples.Generic.Runners.Nunit
{
	[TestFixture]
	public class GenericTests
	{
		private static string DevToken = "YOUR_DEV_TOKEN";

		Runner runner;

		[SetUp]
		public void SetUp()
		{
			runner = RunnerFactory.Instance.Create(DevToken);
		}

		[TearDown]
		public void TearDown()
		{
			runner.Dispose();
		}

		[Test]
		public void RunTest()
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
			runner.Run(new ProxyTest(), true);
		}
	}
}
