using NUnit.Framework;
using TestProject.Common.Enums;
using TestProject.SDK.Examples.Web.Runners.Nunit.Base;

namespace TestProject.SDK.Examples.Runners.Nunit
{
	[TestFixture(AutomatedBrowserType.Edge)]
	[TestFixture(AutomatedBrowserType.Chrome)]
	[TestFixture(AutomatedBrowserType.InternetExplorer)]
	[TestFixture(AutomatedBrowserType.Firefox)]
	public class DesktopTests : TestBase
	{
		Runner runner;

		public DesktopTests(AutomatedBrowserType automatedBrowserType)
		{
			runner = RunnerFactory.Instance.CreateWeb(DevToken, automatedBrowserType);
		}

		[Test]
		public void RunTest()
		{
			RunTest(runner);
		}

		[Test]
		public void RunExtendedTest()
		{
			RunExtendedTest(runner);
		}

		[Test]
		public void RunProxyTest()
		{
			RunProxyTest(runner);
		}

		[OneTimeTearDown]
		public void TearDown()
		{
			runner.Dispose();
		}
	}
}