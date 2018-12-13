using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using TestProject.SDK.Addons.Actions;
using TestProject.SDK.Addons.Helpers;
using TestProject.SDK.Common.Attributes;

namespace TestProject.SDK.Examples.Android.Addon
{
	[Action(Name = "Clear Fields")]
	public class ClearFieldsAction : IAndroidAction
	{
		public ExecutionResult Execute(AndroidAddonHelper helper)
		{
			foreach (AndroidElement element in helper.Driver.FindElements(By.ClassName("android.widget.EditText")))
				element.Clear();

			return ExecutionResult.Passed;
		}
	}
}