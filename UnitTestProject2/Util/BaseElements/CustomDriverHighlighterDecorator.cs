namespace TestWebProject.Webdriver
{
    using System;
    using System.Collections.ObjectModel;
    using System.Drawing;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;


    public class CustomDriverHighlighterDecorator : IWebDriver
    {
        protected IWebDriver driver;

        public CustomDriverHighlighterDecorator(IWebDriver driver)
        {
            this.driver = driver;
        }

        public string Url { get => this.driver.Url; set => driver.Url = value; }

        public string Title => this.driver.Title;

        public string PageSource => this.driver.PageSource;

        public string CurrentWindowHandle => this.driver.CurrentWindowHandle;

        public ReadOnlyCollection<string> WindowHandles => this.driver.WindowHandles;

        public void Close()
        {
            this.driver.Close();
        }

        public void Dispose()
        {
            this.driver.Dispose();
        }

        public IWebElement FindElement(By by)
        {
            IWebElement el = this.driver.FindElement(by);

            IJavaScriptExecutor executor = (IJavaScriptExecutor)this.driver;
            executor.ExecuteScript("arguments[0].style.backgroundColor = '" + "yellow" + "'", el);

            return el;
        }

        public ReadOnlyCollection<IWebElement> FindElements(By by)
        {
            return this.driver.FindElements(by);
        }

        public IOptions Manage()
        {
            return this.driver.Manage();
        }

        public INavigation Navigate()
        {
            return this.driver.Navigate();
        }

        public void Quit()
        {
            this.driver.Quit();
        }

        public ITargetLocator SwitchTo()
        {
            return this.driver.SwitchTo();
        }


    }
}


