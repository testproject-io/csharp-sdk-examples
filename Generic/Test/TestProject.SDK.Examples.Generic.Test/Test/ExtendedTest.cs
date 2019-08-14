using TestProject.Common.Attributes;
using TestProject.Common.Enums;
using TestProject.SDK.Tests;
using TestProject.SDK.Tests.Helpers;

namespace TestProject.SDK.Examples.Generic.Test
{
	[Test(Name = "Extended Test")]
	public class ExtendedTest : IGenericTest
	{

		[Parameter(DefaultValue = "1")]
		public int a;

		[Parameter(DefaultValue = "1")]
		public int b;

		[Parameter(Description = "Calculation expected result")]
		public int expectedResult;

		[Parameter(Description = "Calculation actual result", Direction = ParameterDirection.Output)]
		public int actualResult;

		public ExecutionResult Execute(GenericTestHelper helper)
		{
			actualResult = a + b;

			helper.Reporter.Step($"{a} + {b} == {expectedResult}?", actualResult == expectedResult);

			helper.Reporter.Result = "Addition result is: " + actualResult;

			return actualResult == expectedResult ? ExecutionResult.Passed : ExecutionResult.Failed;
		}
	}
}