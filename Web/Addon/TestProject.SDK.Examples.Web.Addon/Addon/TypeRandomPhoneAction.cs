using System;
using OpenQA.Selenium;
using TestProject.Common.Attributes;
using TestProject.Common.Enums;
using TestProject.SDK.Addons.Helpers;
using TestProject.SDK.Addons.ElementAction;

namespace TestProject.SDK.Examples.Web.Addon
{
	[Action(Name = "Type Random Phone Number")]
	public class TypeRandomPhoneAction : IWebElementAction
	{
		// Action parameters
		[Parameter]
		public string countryCode = "1";

		[Parameter]
		public int maxDigits;

		[Parameter(Direction = ParameterDirection.Output)]
		public string phone;

		public ExecutionResult Execute(WebAddonHelper helper, IWebElement element)
		{
			var randomer = new Random();
			long number = randomer.Next(1, (int)Math.Pow(10, maxDigits));
			phone = $"+{countryCode}{number}";
			element.SendKeys(phone);
			return ExecutionResult.Passed;
		}
	}
}