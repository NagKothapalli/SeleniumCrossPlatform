//using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumGrid
{
    [TestFixture]
    public class Gmail
    {
        IWebDriver driver;
        LoginPageObject login;
        DriverSetUp driverSetUp;
        public Gmail()
        {
            driverSetUp = new DriverSetUp();
            driver = driverSetUp.GetWebDriver();
            login = new LoginPageObject(driver);
        }
        [Test]
        public void ComposeEmail()
        {
            Debug.WriteLine("RC : Launch Application");
            login.LaunchApplication();
            login.LoginToApplication();
            login.LogoutFromApplication();
            login.CloseApplication();
        }

        [TearDown]// [TestCleanup]   //@After
        public void CleanUp()
        {
            driverSetUp.KillChromeDriver();
        }
    }
}
