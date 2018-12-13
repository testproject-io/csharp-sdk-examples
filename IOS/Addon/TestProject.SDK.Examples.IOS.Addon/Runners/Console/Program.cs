using OpenQA.Selenium;
using IOSElement = OpenQA.Selenium.Appium.iOS.IOSElement;
using TestProject.SDK.Examples.IOS.Addon;
using OpenQA.Selenium.Appium.iOS;

namespace TestProject.SDK.Examples.Android.Runners.Console
{
	class Program
	{
		public static string DevToken = "YOUR_DEV_TOKEN";
		public static string DeviceUDID = "DEVICE_UDID";
		public static string DeviceName = "DEVICE_NAME";
		public static string BundleId = "io.testproject.Demo";

		static void Main(string[] args)
		{
			using (Runner runner = RunnerFactory.Instance.CreateIOS(DevToken, DeviceUDID, DeviceName, BundleId))
			{
				RunAction(runner);
				RunElementAction(runner);
			}

			System.Console.ReadKey();
		}

		static void RunAction(Runner runner)
		{
			// Create Action
			var action = new ClearFieldsAction();

			// Get the Driver
			var driver = (IOSDriver<IOSElement>)runner.GetDriver();

			// Prepare the App
			driver.ResetApp();

			// Prepare state
			driver.FindElement(By.Id("name")).SendKeys("John Smith");
			driver.FindElement(By.Id("password")).SendKeys("12345");

			// Run action
			runner.Run(action);
		}

		static void RunElementAction(Runner runner)
		{
			// Create Action
			var action = new TypeRandomPhoneAction();

			// Get the Driver
			var driver = (IOSDriver<IOSElement>)runner.GetDriver();

			// Prepare the App
			driver.ResetApp();

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