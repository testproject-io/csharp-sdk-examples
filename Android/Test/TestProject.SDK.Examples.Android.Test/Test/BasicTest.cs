using TestProject.SDK.Examples.Android.Test.Pages;
using TestProject.SDK.Tests;
using TestProject.SDK.Tests.Helpers;
using TestProject.SDK.PageObjects;

namespace TestProject.SDK.Examples.Android.Test
{
	public class BasicTest : IAndroidTest
	{
		public string name = "John Smith";
		public string password = "12345";
		public string country = "USA";
		public string address = "Street number and name";
		public string email = "john.smith@somewhere.tld";
		public string phone = "+1 555 555 55";

		public ExecutionResult Execute(AndroidTestHelper helper)
		{
			var driver = helper.Driver;

			driver.ResetApp();

			// Login using provided credentials
			var loginPage = PageFactory.InitElements<LoginPage>(driver);

			// Perform login
			loginPage.Login(name, password);

			// Complete profile form
			var profilePage = PageFactory.InitElements<ProfilePage>(driver);

			profilePage.UpdateProfile(country, address, email, phone);

			return profilePage.Saved ? ExecutionResult.Passed : ExecutionResult.Failed;
		}
	}
}