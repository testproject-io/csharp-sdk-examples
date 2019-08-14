using System;
using TestProject.SDK.Examples.Web.Test.Pages;
using TestProject.SDK.Tests;
using TestProject.SDK.Tests.Helpers;
using TestProject.Common.Attributes;
using TestProject.SDK.PageObjects;
using TestProject.Common.Enums;
using TestProject.SDK.Examples.Web.Addon;
using TestProject.SDK.Reporters;

namespace TestProject.SDK.Examples.Web.Test
{
	[Test(Name = "Test with Addon proxy")]
	public class ProxyTest : IWebTest
	{
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

			profilePage.SelectCountry(country);
			profilePage.TypeAddress(address);
			profilePage.TypeEmail(email);

			// Type random phone number using Addon proxy
			var actionProxy = new TypeRandomPhoneAction("1", 7);
			ExecutionResult result = helper.ExecuteProxy(actionProxy, profilePage.GetPhoneElement());
			report.Step("Type random phone number using Addon proxy", result == ExecutionResult.Passed);

			// Save profile
			profilePage.Save();
			report.Step("Profile information saved", profilePage.Saved, TakeScreenshotConditionType.Always);

			report.Result = "Test completed successfully";
			return profilePage.Saved ? ExecutionResult.Passed : ExecutionResult.Failed;
		}
	}
}