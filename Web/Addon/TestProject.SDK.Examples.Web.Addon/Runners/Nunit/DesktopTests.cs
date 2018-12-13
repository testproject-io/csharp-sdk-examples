using NUnit.Framework;
using TestProject.SDK.Common.Enums;
using TestProject.SDK.Examples.Web.Runners.Nunit.Base;

namespace TestProject.SDK.Examples.Web.Runners.Nunit
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
		public void RunAction()
		{
			RunAction(runner);
		}

		[Test]
		public void RunElementAction()
		{
			RunElementAction(runner);
		}

		[OneTimeTearDown]
		public void TearDown()
		{
			runner.Dispose();
		}
	}
}