using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;

namespace TestWebProject.Webdriver
{
    public class BrowserTypes
    {
        public static IWebDriver GetDriver(BrowserType type, int timeOutSec)
        {
            IWebDriver driver = null;

            switch (type)
            {
                case BrowserType.Chrome:
                    {
                        var service = ChromeDriverService.CreateDefaultService();
                        var option = new ChromeOptions();
                        option.AddArgument("disable-infobars");
                        driver = new ChromeDriver(service, option, TimeSpan.FromSeconds(timeOutSec));
                        break;
                    }

                case BrowserType.Firefox:
                    {
                        var service = FirefoxDriverService.CreateDefaultService();
                        var options = new FirefoxOptions();
                        driver = new FirefoxDriver(service, options, TimeSpan.FromSeconds(timeOutSec));
                        break;
                    }

                case BrowserType.RemoteChrome:
                    {
                        var option = new ChromeOptions();
                        option.AddArgument("disable-infobars");
                        option.AddArgument("--no-sandbox");
                        driver = new RemoteWebDriver(new Uri("http://localhost:5566/wd/hub"), option.ToCapabilities());
                        break;
                    }

                case BrowserType.RemoteFirefox:
                    {
                        var cability = DesiredCapabilities.Firefox();
                        cability.SetCapability(CapabilityType.BrowserName, "firefox");
                        cability.SetCapability(CapabilityType.Platform, new Platform(PlatformType.Windows));
                        driver = new RemoteWebDriver(new Uri ("http://localhost:5566/wd/hub"), cability);
                        break;
                    }
            }
            return driver;
        }
    }
}