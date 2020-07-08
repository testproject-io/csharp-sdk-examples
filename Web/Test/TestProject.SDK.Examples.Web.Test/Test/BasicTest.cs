using OpenQA.Selenium;
using TestProject.SDK.Tests;
using TestProject.Common.Attributes;
using TestProject.SDK.Tests.Helpers;

namespace TestProject.SDK.Examples.Web.Test
{
	[Test(Name="Basic Test")]
	public class BasicTest : IWebTest
	{
		public ExecutionResult Execute(WebTestHelper helper)
		{
			// Get driver initialized by TestProject Agent
			// No need to specify browser type, it can be done later via UI
			var driver = helper.Driver;

			driver.Navigate().GoToUrl("https://example.testproject.io/web/");

			driver.FindElementByCssSelector("#name").SendKeys("John Smith");
			driver.FindElementByCssSelector("#password").SendKeys("12345");
			driver.FindElementByCssSelector("#login").Click();

			if (driver.FindElements(By.Id("logout")).Count > 0)
				return ExecutionResult.Passed;
			return ExecutionResult.Failed;
		}
	}
}