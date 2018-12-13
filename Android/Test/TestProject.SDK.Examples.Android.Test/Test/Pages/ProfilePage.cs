using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using SeleniumExtras.PageObjects;
using AndroidElement = OpenQA.Selenium.Appium.Android.AndroidElement;

namespace TestProject.SDK.Examples.Android.Test.Pages
{
	class ProfilePage
	{
		AndroidDriver<AndroidElement> driver;

		public ProfilePage(IWebDriver driver)
		{
			this.driver = (AndroidDriver<AndroidElement>)driver;
		}

		[FindsBy(How = How.ClassName, Using = "UIAKeyboard")]
		private IWebElement keyboard;

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

		public void HideKeyboardIfVisible()
		{
			if (keyboard != null)
				driver.PressKeyCode(AndroidKeyCode.Keycode_ESCAPE);
		}

		public void UpdateProfile(string country, string address, string email, string phone)
		{
			TypeCountry(country);
			TypeAddress(address);
			HideKeyboardIfVisible();
			TypeEmail(email);
			TypePhone(phone);
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