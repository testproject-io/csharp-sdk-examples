using System;
using OpenQA.Selenium.Appium.iOS;
using TestProject.SDK.Addons.ElementAction;
using TestProject.SDK.Addons.Helpers;
using TestProject.SDK.Common.Attributes;
using TestProject.SDK.Common.Enums;

namespace TestProject.SDK.Examples.IOS.Addon
{
	[Action(Name = "Type Random Phone Number")]
	public class TypeRandomPhoneAction : IIOSElementAction
	{
		[Parameter]
		public string countryCode = "1";

		[Parameter]
		public int maxDigits;

		[Parameter(Direction = ParameterDirection.Output)]
		public string phone;

		public ExecutionResult Execute(IOSAddonHelper helper, IOSElement element)
		{
			var randomer = new Random();
			long number = randomer.Next(1, (int)Math.Pow(10, maxDigits));
			phone = $"+{countryCode}{number}";
			element.SendKeys(phone);
			return ExecutionResult.Passed;
		}
	}
}