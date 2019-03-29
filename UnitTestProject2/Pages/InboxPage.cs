using OpenQA.Selenium;
using TestWebProject.Webdriver;

namespace TestWebProject.Pages
{
    public class InboxPage : BasePage
    {
        private static readonly By InboxPageLocator = By.XPath("//div[@class='b-sticky js-not-sticky']//div[@data-name='remove'] | //div[@class='b-sticky']//div[@data-name='remove']");

        public InboxPage() : base(InboxPageLocator, "Inbox Page")
        {

        }

        private readonly BaseElement newEmailButton = new BaseElement(By.XPath("//div[@class = 'b-sticky']//a[@data-name='compose'] | //div[@class = 'b-sticky js-not-sticky']//a[@data-name='compose']"));
        private readonly BaseElement draftFolder = new BaseElement(By.XPath("//a[@data-mnemo= 'drafts']"));
        private readonly BaseElement sentFolder = new BaseElement(By.XPath("//i[contains(@class, 'ico ico_folder_send')]"));
        private readonly BaseElement logoutButton = new BaseElement(By.XPath("//a[@id='PH_logoutLink']"));

        public void GoToNewEmailPage()
        {
            this.newEmailButton.Click();
        }

        public void GoToDraftPage()
        {
            this.draftFolder.Click();
        }

        public void GoToSentPage()
        {
            this.sentFolder.Click();
        }

        public void LogOut()
        {
            this.logoutButton.Click();
        }
    }
}