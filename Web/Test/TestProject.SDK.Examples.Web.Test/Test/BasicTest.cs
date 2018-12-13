using TestProject.SDK.Examples.Web.Test.Pages;
using TestProject.SDK.Tests;
using TestProject.SDK.Tests.Helpers;
using TestProject.SDK.PageObjects;

namespace TestProject.SDK.Examples.Web.Test
{
	public class BasicTest : IWebTest
	{
		public string name = "John Smith";
		public string password = "12345";
		public string country = "United States";
		public string address = "Street number and name";
		public string email = "john.smith@somewhere.tld";
		public string phone = "+1 555 555 55";


		public ExecutionResult Execute(WebTestHelper helper)
		{
			// Get driver initialized by TestProject Agent
			// No need to specify browser type, it can be done later via UI
			var driver = helper.Driver;

			// Navigate to TestProject Demo website
			driver.Navigate().GoToUrl("https://example.testproject.io/web/");

			// Initialize the properties of the LoginPage with the driver
			var loginPage = PageFactory.InitElements<LoginPage>(driver);

			// Login using provided credentials
			loginPage.Login(name, password);

			// Initialize the properties of the profilePage with the driver
			var profilePage = PageFactory.InitElements<ProfilePage>(driver);

			// Complete profile forms and save it
			profilePage.UpdateProfile(country, address, email, phone);

			return profilePage.Saved ? ExecutionResult.Passed : ExecutionResult.Failed;
		}
	}
}