using TestProject.SDK.Tests;
using TestProject.SDK.Tests.Helpers;

namespace TestProject.SDK.Examples.Generic.Test
{
	public class BasicTest : IGenericTest
	{
		public ExecutionResult Execute(GenericTestHelper helper)
		{
			int a = 1, b = 1;

			if (a + b == 2)
			{
				return ExecutionResult.Passed;
			}
			else
			{
				return ExecutionResult.Failed;
			}
		}
	}
}