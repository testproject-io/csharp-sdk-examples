using OpenQA.Selenium;
using System.Threading;
using TestProject.SDK.Drivers;
using TestProject.SDK.Examples.Web.Addon;

namespace TestProject.SDK.Examples.Web.Runners.Nunit.Base
{
	public class TestBase : Configuration
	{
		private const string name = "John Smith";
		private const string password = "12345";

		public static void RunAction(Runner runner)
		{
			// Create Action
			var action = new ClearFieldsAction();

			// Prepare state
			var driver = (WebDriver)runner.GetDriver();
			driver.Navigate().GoToUrl("https://example.testproject.io/web/");
			driver.FindElement(By.Id("name")).SendKeys(name);
			driver.FindElement(By.Id("password")).SendKeys(password);

			// Run action
			runner.Run(action);

			Thread.Sleep(1000);
		}


		public static void RunElementAction(Runner runner)
		{
			// Create Action
			var action = new TypeRandomPhoneAction();

			// Prepare state
			var driver = (WebDriver)runner.GetDriver();
			driver.Navigate().GoToUrl("https://example.testproject.io/web/");

			driver.FindElement(By.Id("name")).SendKeys(name);
			driver.FindElement(By.Id("password")).SendKeys(password);
			driver.FindElement(By.Id("login")).Click();

			// Set action parameters
			action.countryCode = "1";
			action.maxDigits = 8;

			// Run action
			runner.Run(action, By.Id("phone"));

			Thread.Sleep(1000);
		}
	}
}