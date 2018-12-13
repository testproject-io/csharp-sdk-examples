using NUnit.Framework;
using OpenQA.Selenium;
using TestProject.SDK.Drivers;
using TestProject.SDK.Examples.IOS.Addon;
using IOSElement = OpenQA.Selenium.Appium.iOS.IOSElement;


namespace TestProject.SDK.Examples.IOS.Runners.Nunit
{
	[TestFixture]
	public class IOSTests
	{
		public static string DevToken = "YOUR_DEV_TOKEN";
		public static string DeviceUDID = "DEVICE_UDID";
		public static string DeviceName = "DEVICE_NAME";
		public static string BundleId = "io.testproject.Demo";

		private static Runner runner;
		private static IOSDriver<IOSElement> driver;


		[OneTimeSetUp]
		public static void Setup()
		{
			runner = RunnerFactory.Instance.CreateIOS(DevToken, DeviceUDID, DeviceName, BundleId);
			driver = (IOSDriver<IOSElement>)runner.GetDriver();
		}

		[OneTimeTearDown]
		public static void TearDown()
		{
			runner.Dispose();
		}

		[SetUp]
		public void PrepareApp()
		{
			driver.ResetApp();
		}

		[Test]
		public void RunAction()
		{
			// Create Action
			var action = new ClearFieldsAction();

			// Prepare state
			driver.FindElement(By.Id("name")).SendKeys("John Smith");
			driver.FindElement(By.Id("password")).SendKeys("12345");

			// Run action
			runner.Run(action);
		}

		[Test]
		public void RunElementAction()
		{
			// Create Action
			var action = new TypeRandomPhoneAction();

			// Prepare state
			driver.FindElement(By.Id("name")).SendKeys("John Smith");
			driver.FindElement(By.Id("password")).SendKeys("12345");
			driver.FindElement(By.Id("login")).Click();
			driver.HideKeyboard();

			// Set action parameters
			action.countryCode = "1";
			action.maxDigits = 8;

			// Run action
			runner.Run(action, By.Id("phone"));
		}
	}
}