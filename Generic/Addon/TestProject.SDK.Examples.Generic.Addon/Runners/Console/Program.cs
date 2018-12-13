using TestProject.SDK.Examples.Generic.Addon;

namespace TestProject.SDK.Examples.Generic.Runners.Console
{
	class Program
	{
		private static string DevToken = "YOUR_DEV_TOKEN";

		static void Main(string[] args)
		{
			// Create the Runner
			using (Runner runner = RunnerFactory.Instance.Create(DevToken))
			{
				// Create the Action
				var action = new AdditionAction();
				action.a = 1;
				action.b = 1;

				// Run action
				runner.Run(action);
			}

			System.Console.ReadKey();
		}
	}
}