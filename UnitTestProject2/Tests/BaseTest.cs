using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace TestWebProject.Webdriver
{
    public class BaseTest
    {
        protected static Browser Browser;

        [TestInitialize]
        public void SetupTest()
        {
            Browser = Browser.Instance;
            Browser.WindowMaximise();
            Browser.NavigateTo(Configuration.BaseUrl);
        }

        [TestCleanup]
        public void CleanUp()
        {
            Browser.Quit();
        }
    }
}
