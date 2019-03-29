namespace TestWebProject.Webdriver
{
    using System;
    using OpenQA.Selenium;
    using System.Linq;
    using OpenQA.Selenium.Support.UI;

    public class Browser
    {
        private static Browser currentInstane;
        private static IWebDriver driver;
        public static BrowserType CurrentBrowser;
        public static int ImplWait;
        public static int TimeoutForElement;
        private static string browser;

        private Browser()
        {
            InitParamas();
            driver = BrowserTypes.GetDriver(CurrentBrowser, ImplWait);
        }

        private static void InitParamas()
        {
            ImplWait = Convert.ToInt32(Configuration.ElementTimeout);
            TimeoutForElement = Convert.ToInt32(Configuration.ElementTimeout);
            browser = Configuration.Browser;
            Enum.TryParse(browser, out CurrentBrowser);
        }

        public static Browser Instance => currentInstane ?? (currentInstane = new Browser());

        public static void WindowMaximise()
        {
            driver.Manage().Window.Maximize();
        }

        public static string OpenNewTab(string url)
        {
            var handle = GetDriver().CurrentWindowHandle;
            var handles = GetDriver().WindowHandles;
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript(string.Format("var d=document, a=d.createElement('a');a.target='_blank';a.href='{0}';" +
                                                   "a.innerHtml='.';d.body.appendChild(a),a.click();", url));
            var newHandles = GetDriver().WindowHandles;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Convert.ToDouble(TimeoutForElement)));
            wait.Until(waiting => GetDriver().WindowHandles.Count > handles.Count);
            string tabHandle = "";
            foreach (var newHandel in newHandles)
            {
                if (!string.Join(",", handles.ToArray()).Contains(newHandel))
                {
                    tabHandle = newHandel;
                }
            }
            GetDriver().SwitchTo().Window(tabHandle);
            return handle;
        }

        public static void NavigateTo(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public static IWebDriver GetDriver()
        {
            return driver;
        }

        public static void Quit()
        {
            driver.Quit();
            currentInstane = null;
            driver = null;
            browser = null;
        }
    }
}
