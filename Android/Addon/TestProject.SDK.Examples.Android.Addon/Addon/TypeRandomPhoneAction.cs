using System;
using OpenQA.Selenium.Appium.Android;
using TestProject.SDK.Addons.ElementAction;
using TestProject.SDK.Addons.Helpers;
using TestProject.SDK.Common.Attributes;
using TestProject.SDK.Common.Enums;

namespace TestProject.SDK.Examples.Android.Addon
{
	[Action(Name = "Type Random Phone Number")]
	public class TypeRandomPhoneAction : IAndroidElementAction
	{
		[Parameter]
		public string countryCode = "1";

		[Parameter]
		public int maxDigits;

		[Parameter(Direction = ParameterDirection.Output)]
		public string phone;

		public ExecutionResult Execute(AndroidAddonHelper helper, AndroidElement element)
		{
			var randomer = new Random();
			long number = randomer.Next(1, (int)Math.Pow(10, maxDigits));
			phone = $"+{countryCode}{number}";
			element.SendKeys(phone);
			return ExecutionResult.Passed;
		}
	}
}