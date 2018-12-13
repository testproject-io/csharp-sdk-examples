using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace TestProject.SDK.Examples.Web.Test.Pages
{
	class LoginPage
	{
		[FindsBy(How = How.Id, Using = "name")]
		private IWebElement nameElement;

		[FindsBy(How = How.Id, Using = "password")]
		private IWebElement passwordElement;

		[FindsBy(How = How.Id, Using = "login")]
		private IWebElement loginElement;

		private IWebDriver driver;
		public LoginPage(IWebDriver driver)
		{
			this.driver = driver;
		}

		public bool Displayed => nameElement.Displayed;

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

		public void Login(string name, string password)
		{
			TypeName(name);
			TypePassword(password);
			ClickLogin();
		}
	}
}