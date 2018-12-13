using NUnit.Framework;
using OpenQA.Selenium;
using AndroidElement = OpenQA.Selenium.Appium.Android.AndroidElement;
using TestProject.SDK.Examples.Android.Addon;
using TestProject.SDK.Drivers;

namespace TestProject.SDK.Examples.Android.Runners.Nunit
{
	[TestFixture]
	public class AndroidActions
	{
		public static string DevToken = "YOUR_DEV_TOKEN";
		public static string DeviceUDID = "DEVICE_UDID";
		public static string PackageName = "io.testproject.demo";
		public static string ActivityName = ".MainActivity";

		private static Runner runner;
		private static AndroidDriver<AndroidElement> driver;

		[OneTimeSetUp]
		public static void Setup()
		{
			runner = RunnerFactory.Instance.CreateAndroid(DevToken, DeviceUDID, PackageName, ActivityName);
			driver = (AndroidDriver<AndroidElement>)runner.GetDriver();
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