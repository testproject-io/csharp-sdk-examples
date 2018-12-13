using OpenQA.Selenium;
using IOSElement = OpenQA.Selenium.Appium.iOS.IOSElement;
using SeleniumExtras.PageObjects;
using TestProject.SDK.Drivers;

namespace TestProject.SDK.Examples.IOS.Test.Pages
{
	class ProfilePage
	{
		IOSDriver<IOSElement> driver;

		public ProfilePage(IWebDriver driver)
		{
			this.driver = (IOSDriver<IOSElement >)driver;
		}

		[FindsBy(How = How.Id, Using = "greetings")]
		private IWebElement greetingsElement;

		[FindsBy(How = How.Id, Using = "logout")]
		private IWebElement logoutElement;

		[FindsBy(How = How.Id, Using = "country")]
		private IWebElement countryElement;

		[FindsBy(How = How.Id, Using = "address")]
		private IWebElement addressElement;

		[FindsBy(How = How.Id, Using = "email")]
		private IWebElement emailElement;

		[FindsBy(How = How.Id, Using = "phone")]
		private IWebElement phoneElement;

		[FindsBy(How = How.Id, Using = "save")]
		private IWebElement saveElement;

		[FindsBy(How = How.Id, Using = "saved")]
		private IWebElement savedElement;

		public bool Displayed => greetingsElement.Displayed;

		public bool Saved => savedElement.Displayed;


		public void TypeCountry(string country)
		{
			countryElement.SendKeys(country);
		}

		public void TypeAddress(string address)
		{
			addressElement.SendKeys(address);
		}

		public void TypeEmail(string email)
		{
			emailElement.SendKeys(email);
		}

		public void TypePhone(string phone)
		{
			phoneElement.SendKeys(phone);
		}

		public void HideKeyboard()
		{
			driver.HideKeyboard();
		}

		public void UpdateProfile(string country, string address, string email, string phone)
		{
			TypeCountry(country);
			TypeAddress(address);
			TypeEmail(email);
			TypePhone(phone);
			HideKeyboard();
			Save();
		}

		public void Save()
		{
			saveElement.Click();
		}

		public By GetPhoneElement()
		{
			return By.Id("phone");
		}
	}
}