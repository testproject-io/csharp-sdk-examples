using IOSElement = OpenQA.Selenium.Appium.iOS.IOSElement;
using SeleniumExtras.PageObjects;
using System.Threading;
using TestProject.SDK.Drivers;
using OpenQA.Selenium;

namespace TestProject.SDK.Examples.IOS.Test.Pages
{
	class LoginPage
	{
		IOSDriver<IOSElement> driver;

		public LoginPage(IWebDriver driver)
		{
			this.driver = (IOSDriver<IOSElement>)driver;
		}

		[FindsBy(How = How.Id, Using = "name")]
		public IWebElement nameElement;

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

		public void Login(string name, string password)
		{
			TypeName(name);
			TypePassword(password);
			ClickLogin();
		}
	}
}