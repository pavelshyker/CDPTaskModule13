using OpenQA.Selenium;
using TestWebProject.Webdriver;
using TestWebProject.BO;
using OpenQA.Selenium.Interactions;
using System.Linq;

namespace TestWebProject.Pages
{
    public class StartPage : BasePage
    {
        private static readonly By StartPageLocator = By.XPath("//a[@id='PH_authLink']");

        public StartPage() : base(StartPageLocator, "Start Page")
        {
            
        }

        private readonly BaseElement loginButton = new BaseElement(By.XPath("//a[@id='PH_authLink']"));
        private readonly BaseElement signInFrame = new BaseElement(By.ClassName("ag-popup__frame__layout__iframe"));
        private readonly BaseElement loginInputField = new BaseElement(By.XPath("//input[@name='Login']"));
        private readonly BaseElement passwordInputField = new BaseElement(By.XPath("//input[@name='Password']"));
        private readonly BaseElement submitButton = new BaseElement(By.XPath("//button[@type='submit']"));
        private readonly BaseElement newEmailButton = new BaseElement(By.XPath("//div[@class = 'b-sticky']//a[@data-name='compose'] | //div[@class = 'b-sticky js-not-sticky']//a[@data-name='compose']"));
        private readonly BaseElement incorrectCredentialsMessage = new BaseElement(By.XPath("//p[@class = 'c0126 c0126 c0143 c0138']"));
        private readonly BaseElement loginInputField2 = new BaseElement(By.XPath("//input[@id='mailbox:login']"));
        private readonly BaseElement passwordInputField2 = new BaseElement(By.XPath("//input[@id='mailbox:password']"));

        public void Login(User user)
        {
            this.loginButton.JsHighlight();
            this.loginButton.JsClick();
            driver.SwitchTo().Frame(this.signInFrame.GetElement());
            this.loginInputField.Click();
            this.loginInputField.SendKeys(user.DataUser[0]);
            this.passwordInputField.Click();
            this.passwordInputField.SendKeys(user.DataUser[1]);
            this.submitButton.Click();
            Logger.Log.Info("User is logined");
            Logger.Log.Debug("Debug action was performed");
            driver.SwitchTo().DefaultContent();
        }

        public void LoginUsingTabs(User user)
        {
            Actions action = new Actions(driver);

            this.loginInputField2.SendKeys(user.DataUser.ElementAt(0));

            this.passwordInputField2.SendKeys(user.DataUser[1]);

            action.SendKeys(Keys.Enter).Perform();
        }

        public bool LoginSuccessMarker()
        {
            return this.newEmailButton.Displayed;
        }

        public bool LogoutSuccessMarker()
        {
            return this.loginButton.Displayed;
        }

        public bool IncorrectCredentialsMarker()
        {
            return this.incorrectCredentialsMessage.Displayed;
        }
    }
}