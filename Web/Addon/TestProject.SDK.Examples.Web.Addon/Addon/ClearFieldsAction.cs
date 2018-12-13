using System;
using OpenQA.Selenium;
using TestProject.SDK.Addons.Actions;
using TestProject.SDK.Addons.Helpers;
using TestProject.SDK.Common.Attributes;

namespace TestProject.SDK.Examples.Web.Addon
{
	[Action(Name = "Clear Fields")]
	public class ClearFieldsAction : IWebAction
	{
		public ExecutionResult Execute(WebAddonHelper helper)
		{
			// Get Driver
			var driver = helper.Driver;

			// Search for Form elements
			foreach (IWebElement form in driver.FindElements(By.TagName("form")))
			{
				// Ignore invisible forms
				if (!form.Displayed)
					continue;

				// Clear all inputs
				foreach (IWebElement element in form.FindElements(By.TagName("input")))
					element.Clear();
			}

			return ExecutionResult.Passed;
		}
	}
}