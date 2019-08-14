using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using SeleniumExtras.PageObjects;
using System.Threading;
using AndroidElement = OpenQA.Selenium.Appium.Android.AndroidElement;

namespace TestProject.SDK.Examples.Android.Test.Pages
{
	class LoginPage
	{
		AndroidDriver<AndroidElement> driver;

		public LoginPage(IWebDriver driver)
		{
			this.driver = (AndroidDriver<AndroidElement>)driver;
		}

		[FindsBy(How = How.Id, Using = "name")]
		public IWebElement nameElement;

		[FindsBy(How = How.ClassName, Using = "UIAKeyboard")]
		public IWebElement keyboard;

		[FindsBy(How = How.Id, Using = "password")]
		public IWebElement passwordElement;

		[FindsBy(How = How.Id, Using = "login")]
		public IWebElement loginElement;

		public bool Displayed => loginElement.Displayed;

		public void TypeName(string name)
		{
			nameElement.SendKeys(name);
		}

		public void TypePassword(string password)
		{
			passwordElement.SendKeys(password);
		}

		public void ClickLogin()
		{
			loginElement.Click();
		}

		public void Sleep()
		{
			Thread.Sleep(1000);
		}

		public void HideKeyboardIfVisible()
		{
			if (keyboard != null)
				driver.PressKeyCode(AndroidKeyCode.Keycode_ESCAPE);
		}

		public void Login(string name, string password)
		{
			HideKeyboardIfVisible();
			TypeName(name);
			TypePassword(password);
			ClickLogin();
		}
	}
}