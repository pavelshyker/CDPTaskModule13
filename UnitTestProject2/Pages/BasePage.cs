using OpenQA.Selenium;
using TestWebProject.Webdriver;


namespace TestWebProject.Pages
{
    public class BasePage
    {
        protected By TitleLocator;
        protected string title;
        public IWebDriver driver = Browser.GetDriver();


        protected BasePage(By TitleLocator, string title)
        {
            this.TitleLocator = TitleLocator;
            this.title = title;
            AssertIsOpen();
        }

        public void AssertIsOpen()
        {
            var label = new BaseElement(this.TitleLocator, this.title);
            label.WaitForIsVisible();
        }
    }
}