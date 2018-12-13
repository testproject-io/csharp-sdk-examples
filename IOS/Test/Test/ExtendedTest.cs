using TestProject.SDK.Examples.IOS.Test.Pages;
using TestProject.SDK.Tests;
using TestProject.SDK.Tests.Helpers;
using TestProject.SDK.PageObjects;
using TestProject.SDK.Common.Attributes;
using TestProject.SDK.Common.Enums;

namespace TestProject.SDK.Examples.IOS.Test
{
	[Test(Name = "Extended Test")]
	public class ExtendedTest : IIOSTest
	{
		[Parameter(DefaultValue = "John Smith")]
		public string name;

		[Parameter(DefaultValue = "12345")]
		public string password;

		[Parameter(DefaultValue = "Earth")]
		public string country;

		[Parameter(DefaultValue = "Address")]
		public string address;

		[Parameter(DefaultValue = "someone@somewhere.tld")]
		public string email;

		[Parameter(DefaultValue = "+1 555 555 555")]
		public string phone;

		public ExecutionResult Execute(IOSTestHelper helper)
		{
			var driver = helper.Driver;
			var report = helper.Reporter;

			driver.ResetApp();

			var loginPage = PageFactory.InitElements<LoginPage>(driver);
			report.Step("Launched TestProject Demo app", loginPage.Displayed);

			loginPage.Login(name, password);

			var profilePage = PageFactory.InitElements<ProfilePage>(driver);
			report.Step($"Logged in with {name}:{password}", profilePage.Displayed);

			profilePage.UpdateProfile(country, address, email, phone);
			report.Step("Profile information saved", profilePage.Saved, TakeScreenshotConditionType.Always);

			report.Result = "Test completed successfully";
			return ExecutionResult.Passed;
		}
	}
}