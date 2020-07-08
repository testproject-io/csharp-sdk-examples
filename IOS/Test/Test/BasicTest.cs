using OpenQA.Selenium;
using TestProject.SDK.Tests;
using TestProject.SDK.Tests.Helpers;

namespace TestProject.SDK.Examples.IOS.Test
{
	public class BasicTest : IIOSTest
	{

		public ExecutionResult Execute(IOSTestHelper helper)
		{
			// Get driver initialized by TestProject Agent
			// No need to specify browser type, it can be done later via UI
			var driver = helper.Driver;

			driver.ResetApp();

			driver.FindElementById("name").SendKeys("John Smith");
			driver.FindElementById("password").SendKeys("12345");
			driver.FindElementById("login").Click();

			if (driver.FindElements(By.Id("logout")).Count > 0)
				return ExecutionResult.Passed;
			return ExecutionResult.Failed;
		}
	}
}