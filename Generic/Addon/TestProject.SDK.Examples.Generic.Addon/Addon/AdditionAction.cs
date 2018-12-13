using System;
using TestProject.SDK.Addons.Actions;
using TestProject.SDK.Addons.Helpers;
using TestProject.SDK.Common.Attributes;
using TestProject.SDK.Common.Enums;

namespace TestProject.SDK.Examples.Generic.Addon
{
	[Action(Name = "Addition", Description = "Add {{a}} to {{b}}")]
	public class AdditionAction : IGenericAction
	{
		[Parameter]
		public int a;

		[Parameter]
		public int b;

		[Parameter(Description = "Addition result", Direction = ParameterDirection.Output)]
		public int result;

		public ExecutionResult Execute(GenericAddonHelper helper)
		{
			result = a + b;
			helper.Reporter.Result = "Addition result is: " + result;

			return ExecutionResult.Passed;
		}
	}
}