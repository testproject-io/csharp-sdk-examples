using System;
using TestProject.SDK.Examples.Web.Test.Pages;
using TestProject.SDK.Tests;
using TestProject.SDK.Tests.Helpers;
using TestProject.Common.Attributes;
using TestProject.SDK.PageObjects;
using TestProject.SDK.Reporters;
using TestProject.Common.Enums;

namespace TestProject.SDK.Examples.Web.Test
{
	[Test(Name = "Extended Test", Description = "Check if we can login")]
	public class ExtendedTest : IWebTest
	{
		// Test parameters
		[Parameter(DefaultValue = "John Smith")]
		public string name;

		[Parameter(DefaultValue = "12345")]
		public string password;

		[Parameter(DefaultValue = "United States")]
		public string country;

		[Parameter(DefaultValue = "Address")]
		public string address;

		[Parameter(DefaultValue = "someone@somewhere.tld")]
		public string email;

		[Parameter(DefaultValue = "+1 555 555 555")]
		public string phone;

		public ExecutionResult Execute(WebTestHelper helper)
		{
			// Get driver initialized by TestProject Agent
			// No need to specify browser type, it can be done later via UI
			var driver = helper.Driver;
			TestReporter report = helper.Reporter;

			// Navigate to TestProject Demo website
			driver.Navigate().GoToUrl("https://example.testproject.io/web/");

			// Initialize the properties of the LoginPage with the driver
			var loginPage = PageFactory.InitElements<LoginPage>(driver);
			report.Step("Navigated to TestProject Demo", loginPage.Displayed);

			// Login using provided credentials
			loginPage.Login(name, password);

			// Initialize the properties of the profilePage with the driver
			var profilePage = PageFactory.InitElements<ProfilePage>(driver);
			report.Step($"Logged in with {name}:{password}", profilePage.Displayed);

			// Complete profile forms and save it
			profilePage.UpdateProfile(country, address, email, phone);
			report.Step("Profile information saved", profilePage.Saved, TakeScreenshotConditionType.Never);

			report.Result = "Test completed successfully";
			return ExecutionResult.Passed;
		}
	}
}