using NUnit.Framework;
using TestProject.SDK.Examples.Generic.Addon;

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
		public void RunAction()
		{
			// Create Action
			var action = new AdditionAction();
			action.a = 1;
			action.b = 1;

			// Run action
			runner.Run(action);
		}
	}
}