using OpenQA.Selenium;
using OpenQA.Selenium.Appium.iOS;
using TestProject.SDK.Addons.Actions;
using TestProject.SDK.Addons.Helpers;
using TestProject.Common.Attributes;

namespace TestProject.SDK.Examples.IOS.Addon
{
	[Action(Name = "Clear Fields")]
	public class ClearFieldsAction : IIOSAction
	{
		public ExecutionResult Execute(IOSAddonHelper helper)
		{
			foreach (IOSElement element in helper.Driver.FindElements(By.ClassName("XCUIElementTypeTextField")))
				element.Clear();

			foreach (IOSElement element in helper.Driver.FindElements(By.ClassName("XCUIElementTypeSecureTextField")))
				element.Clear();

			return ExecutionResult.Passed;
		}
	}
}