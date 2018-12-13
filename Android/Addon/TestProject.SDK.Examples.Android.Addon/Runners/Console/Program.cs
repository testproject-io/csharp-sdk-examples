using OpenQA.Selenium;
using AndroidElement = OpenQA.Selenium.Appium.Android.AndroidElement;
using TestProject.SDK.Examples.Android.Addon;
using TestProject.SDK.Drivers;

namespace TestProject.SDK.Examples.Android.Runners.Console
{
	class Program
	{
		public static string DevToken = "YOUR_DEV_TOKEN";
		public static string DeviceUDID = "DEVICE_UDID";
		public static string PackageName = "io.testproject.demo";
		public static string ActivityName = ".MainActivity";

		static void Main(string[] args)
		{
			using (Runner runner = RunnerFactory.Instance.CreateAndroid(DevToken, DeviceUDID, PackageName, ActivityName))
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
			var driver = (AndroidDriver<AndroidElement>)runner.GetDriver();

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
			var driver = (AndroidDriver<AndroidElement>)runner.GetDriver();

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