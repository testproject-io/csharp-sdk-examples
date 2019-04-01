using TestProject.Addons.Proxy;
using TestProject.SDK.Common.Attributes;
using TestProject.SDK.Common.Enums;
using TestProject.SDK.Tests;
using TestProject.SDK.Tests.Helpers;

namespace TestProject.SDK.Examples.Generic.Test
{
	[Test(Name = "Test with Addon proxy")]
	public class ProxyTest : IGenericTest
	{

		[Parameter(DefaultValue = "1")]
		public int a;

		[Parameter(DefaultValue = "1")]
		public int b;

		[Parameter(Description = "Calculation expected result", DefaultValue = "2")]
		public int expectedResult;

		[Parameter(Description = "Calculation actual result", Direction = ParameterDirection.Output)]
		public int actualResult;


		public ExecutionResult Execute(GenericTestHelper helper)
		{
			var actionProxy = CGenericExampleAddon.CreateAdditionAction(a, b);
			ExecutionResult result = helper.ExecuteProxy(actionProxy);

			actualResult = actionProxy.result;

			bool passed = result.Equals(ExecutionResult.Passed) && actualResult == expectedResult;

			helper.Reporter.Step($"{a} + {b} == {expectedResult}?", passed);

			helper.Reporter.Result = "Addition result is: " + actualResult;

			return passed ? ExecutionResult.Passed : ExecutionResult.Failed;
		}
	}
}