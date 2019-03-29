using OpenQA.Selenium;
using TestWebProject.Webdriver;

namespace TestWebProject.Pages
{
    public class RandomEmailPage : BasePage
    {
        private static readonly By EmailLogo = By.XPath("//h2[contains(text(),'Welcome to 10 Minute Mail')]");

        public RandomEmailPage() : base(EmailLogo, "10 minute email page")
        { }

        private readonly BaseElement _emailField = new BaseElement(By.XPath("//input[@class='mailtext']"), "email Field");

        private string _emailAddress;

        public string EmailAddress => this._emailAddress;

        public void SetEmailAddress()
        {
            this._emailAddress = this._emailField.GetAttribute("value");
        }
    }
}