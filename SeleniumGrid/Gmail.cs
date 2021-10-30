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
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumGrid
{
    [TestFixture]
   [Parallelizable]
    public class Gmail1
    {
        IWebDriver driver;
        LoginPageObject login;
        DriverSetUp driverSetUp;
        public Gmail1()
        {
            
        }
        [Test, Category("Smoke")]
        public void ComposeEmail()
        {
            Debug.WriteLine("RC : ComposeEmail");
            login.LaunchApplication();
            login.LoginToApplication();
            Thread.Sleep(20000);
            login.LogoutFromApplication();
            login.CloseApplication();
        }
        [Test, Category("Regression")]
        public void ReplyEmail()
        {
            Debug.WriteLine("RC : ReplyEmail");
            login.LaunchApplication();
            login.LoginToApplication();
            Thread.Sleep(20000);
            login.LogoutFromApplication();
            login.CloseApplication();
        }
        [SetUp]
        public void Intialize()
        {
            driverSetUp = new DriverSetUp();
            driver = driverSetUp.GetWebDriver("local","chrome");
            login = new LoginPageObject(driver);
        }
        [TearDown]// [TestCleanup]   //@After
        public void CleanUp()
        {
            driver.Quit();
        }
    }
    [TestFixture]
    [Parallelizable]
    public class Gmail2
    {
        IWebDriver driver;
        LoginPageObject login;
        DriverSetUp driverSetUp;
        public Gmail2()
        {
            
        }
        [Test, Category("Smoke")]
        public void ComposeEmail()
        {
            Debug.WriteLine("RC : ComposeEmail");
            login.LaunchApplication();
            login.LoginToApplication();
            Thread.Sleep(20000);
            login.LogoutFromApplication();
            login.CloseApplication();
        }
        [Test, Category("Smoke")]
        public void ReplyEmail()
        {
            Debug.WriteLine("RC : ReplyEmail");
            login.LaunchApplication();
            login.LoginToApplication();
            Thread.Sleep(20000);
            login.LogoutFromApplication();
            login.CloseApplication();
        }
        [SetUp]
        public void Intialize()
        {
            driverSetUp = new DriverSetUp();
            driver = driverSetUp.GetWebDriver("local", "firefox");
            login = new LoginPageObject(driver);
        }
        [TearDown]// [TestCleanup]   //@After
        public void CleanUp()
        {
            driver.Quit();
        }
    }
}
