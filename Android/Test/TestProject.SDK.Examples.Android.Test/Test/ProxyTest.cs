using TestProject.Addons.Proxy;
using TestProject.Common.Attributes;
using TestProject.Common.Enums;
using TestProject.SDK.Examples.Android.Test.Pages;
using TestProject.SDK.PageObjects;
using TestProject.SDK.Tests;
using TestProject.SDK.Tests.Helpers;

namespace TestProject.SDK.Examples.Android.Test
{
	[Test(Name = "Clear Fields")]
	public class ProxyTest : IAndroidTest
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


		public ExecutionResult Execute(AndroidTestHelper helper)
		{
			var driver = helper.Driver;
			var report = helper.Reporter;

			driver.ResetApp();

			var loginPage = PageFactory.InitElements<LoginPage>(driver);
			report.Step("Launched TestProject Demo app", loginPage.Displayed);

			loginPage.Login(name, password);
			var profilePage = PageFactory.InitElements<ProfilePage>(driver);

			report.Step($"Logged in with {name}:{password}", profilePage.Displayed);

			profilePage.HideKeyboardIfVisible();
			profilePage.TypeCountry(country);
			profilePage.TypeAddress(address);
			profilePage.TypeEmail(email);

			// Type random phone number using Addon proxy
			var actionProxy = CAndroidExampleAddon.CreateTypeRandomPhoneAction("1", 7);
			ExecutionResult result = helper.ExecuteProxy(actionProxy, profilePage.GetPhoneElement());
			report.Step("Type random phone number using Addon proxy", result.Equals(ExecutionResult.Passed));

			// Save profile
			profilePage.Save();

			report.Step("Profile information saved", profilePage.Saved, TakeScreenshotConditionType.Always);

			report.Result = "Test completed successfully";
			return ExecutionResult.Passed;
		}
	}
}