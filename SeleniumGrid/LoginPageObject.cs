using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumGrid
{
    public class LoginPageObject
    {
        public IWebDriver WebDriver;
        public LoginPageObject(IWebDriver WebDriver)
        {
            this.WebDriver = WebDriver;
            PageFactory.InitElements(WebDriver, this);
        }
        
        [FindsBy(How = How.Id, Using = "identifierId")] private IWebElement emailAddress;
        [FindsBy(How = How.Id, Using = "txtPassword")] private IWebElement password;
        [FindsBy(How = How.XPath, Using = "//span[text()='Next']")] private IWebElement nextButton;
        public void LaunchApplication()
        {
            Console.WriteLine("LaunchApplication");
            WebDriver.Navigate().GoToUrl(ConfigurationManager.AppSettings["appUrl"]);
        }
        public void LoginToApplication()
        {
            Console.WriteLine("LoginToApplication");
            emailAddress.SendKeys(ConfigurationManager.AppSettings["username"]);
            nextButton.Click();
        }
        public void LogoutFromApplication()
        {
            Console.WriteLine("LogoutFromApplication");
        }
        public void CloseApplication()
        {
            Console.WriteLine("CloseApplication");
        }
    }
}
