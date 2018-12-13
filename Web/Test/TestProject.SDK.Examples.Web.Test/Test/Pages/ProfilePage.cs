using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace TestProject.SDK.Examples.Web.Test.Pages
{
	class ProfilePage
	{
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

		private IWebDriver driver;
		public ProfilePage(IWebDriver driver)
		{
			this.driver = driver;
		}

		public bool Displayed => logoutElement.Displayed;

		public bool Saved => savedElement.Displayed;

		public void SelectCountry(string country)
		{
			var countrySelect = new SelectElement(countryElement);
			countrySelect.SelectByText(country);
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

		public void UpdateProfile(string country, string address, string email, string phone)
		{
			SelectCountry(country);
			TypeAddress(address);
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