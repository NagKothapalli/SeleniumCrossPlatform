using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
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
    public class DriverSetUp
    {
        public IWebDriver driver;
        public IWebDriver GetWebDriver()
        {
            var browser = ConfigurationManager.AppSettings["Browser"];
            switch (ConfigurationManager.AppSettings["ExecutionType"].ToLower())
            {
                case "local":
                    driver = GetLocalDriver(browser);
                    break;
                case "remote":
                    driver = GetRemoteDriver(browser);
                    break;
                default:
                    driver = GetLocalDriver(browser);
                    break;
            }
            return driver;
        }
        public void KillChromeDriver()
        {
            var processes = Process.GetProcessesByName("chromedriver");
            foreach (var currentProcess in processes)
            {
                currentProcess.Kill();
            }
        }
        public IWebDriver GetLocalDriver(string browser)
        {
            if(ConfigurationManager.AppSettings["Browser"].ToUpper().Equals("CHROME"))
            {
                var options = new ChromeOptions();
                options.AddArguments("--test-type");
                driver =  new ChromeDriver();
            }
            else if (ConfigurationManager.AppSettings["Browser"].ToUpper().Equals("FIREFOX"))
            {
                var options = new FirefoxOptions();
                options.AddArguments("--test-type");
                driver = new FirefoxDriver();
            }
            else
            {
                var options = new ChromeOptions();
                options.AddArguments("--test-type");
                driver = new ChromeDriver();
            }
            return driver;
        }
        public IWebDriver GetRemoteDriver(string browser)
        {
            var capabilities = new DesiredCapabilities();
            capabilities.SetCapability("name", ConfigurationManager.AppSettings["ApplicationName"]);
            capabilities.SetCapability(CapabilityType.BrowserName, browser);
            capabilities.SetCapability(CapabilityType.Version, ConfigurationManager.AppSettings["BrowserVersion"]);
            capabilities.SetCapability(CapabilityType.Platform, ConfigurationManager.AppSettings["OS"]);
            capabilities.SetCapability("screen-resolution", ConfigurationManager.AppSettings["ScreenResolution"]);
            capabilities.SetCapability("username", ConfigurationManager.AppSettings["SaucelabsUserName"]);
            capabilities.SetCapability("accessKey", ConfigurationManager.AppSettings["SaucelabsAccessKey"]);
            // capabilities.SetCapability(CapabilityType.IsJavaScriptEnabled, true);
            //return new RemoteWebDriver(new Uri(ConfigurationManager.AppSettings["GridURL"]), capabilities);
            return new RemoteWebDriver(new Uri(ConfigurationManager.AppSettings["SaucelabsURL"]), capabilities);
        }
    }
}

