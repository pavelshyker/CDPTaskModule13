using OpenQA.Selenium;
using TestWebProject.Webdriver;
using TestWebProject.BO;
using OpenQA.Selenium.Support.UI;
using System;

namespace TestWebProject.Pages
{
    public class EmailPage : BasePage
    {
        private static readonly By EmailPageLocator = By.XPath("//div[@class='b-sticky js-not-sticky']//*[@data-group='templates'] | //div[@class='b-sticky']//*[@data-group='templates']");
        private WebDriverWait waiter;

        public EmailPage() : base(EmailPageLocator, "Email Page")
        {
            waiter = new WebDriverWait(Browser.GetDriver(), TimeSpan.FromSeconds(10));
        }
       
        private readonly BaseElement newEmailButton = new BaseElement(By.XPath("//div[@class = 'b-sticky']//a[@data-name='compose'] | //div[@class = 'b-sticky js-not-sticky']//a[@data-name='compose']"));
        private readonly BaseElement toField = new BaseElement(By.XPath("//textarea[@data-original-name='To']"));
        private readonly BaseElement subjectField = new BaseElement(By.XPath("//input[@class='b-input']"));
        private readonly BaseElement textFieldBodyFrame = new BaseElement(By.XPath("//iframe[contains(@id, 'toolkit')]"));
        private readonly BaseElement textField = new BaseElement(By.XPath(".//body[@id='tinymce']"));
        private readonly BaseElement saveDraftButton = new BaseElement(By.XPath(".//div[@class = 'b-sticky']//div[@data-name='saveDraft'] | .//div[@class = 'b-sticky js-not-sticky']//div[@data-name='saveDraft']"));
        private readonly BaseElement draftFolder = new BaseElement(By.XPath("//a[@data-mnemo= 'drafts']"));
        private readonly BaseElement toFieldElement = new BaseElement(By.XPath("//div[@data-blockid='head']//span[@data-text]"));
        private readonly BaseElement emailBody = new BaseElement(By.XPath("//div[contains(@id, 'BODY')]"));
        private readonly BaseElement sendButton2Options = new BaseElement(By.XPath("//div[@class='b-sticky js-not-sticky']//*[@data-name='send'] | //div[@class='b-sticky']//*[@data-name='send']"));
        private readonly BaseElement sentFolder = new BaseElement(By.XPath("//i[contains(@class, 'ico ico_folder_send')]"));

        public void CreateANewEmail(Email email)
        {
            waiter = new WebDriverWait(Browser.GetDriver(), TimeSpan.FromSeconds(10));
            this.toField.SendKeys(email.DataEmail[0]);
            this.subjectField.SendKeys(email.DataEmail[1]);
            driver.SwitchTo().Frame(this.textFieldBodyFrame.GetElement());
            this.textField.SendKeys(email.DataEmail[2]);
            driver.SwitchTo().DefaultContent();
            this.saveDraftButton.Click();
            waiter.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='b-sticky js-not-sticky']//*[@class='time'] | //div[@class='b-sticky']//*[@class='time']")));
        }


        public string GetDraftEmailAddress()
        {
            string emailAttr = this.toFieldElement.GetAttribute("data-text");
            return emailAttr;
        }

        public string GetDraftEmailSubject()
        {
            string subjectAttr = this.subjectField.GetAttribute("name");
            return subjectAttr;
        }

        public string GetDraftEmailText()
        {
            driver.SwitchTo().Frame(this.textFieldBodyFrame.GetElement());
            string textAttr = this.emailBody.Text;
            return textAttr;
        }

        public void SaveAsADraft()
        {
            this.saveDraftButton.Click();
            waiter.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='b-sticky js-not-sticky']//*[@class='time'] | //div[@class='b-sticky']//*[@class='time']")));
        }

        public void SendEmail()
        {
            this.sendButton2Options.Click();
            waiter = new WebDriverWait(Browser.GetDriver(), TimeSpan.FromSeconds(10));
            waiter.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@class='message-sent__info']")));
        }

        public void GoToDraftPage()
        {
            this.draftFolder.Click();
        }

        public void GoToSentPage()
        {
            this.sentFolder.Click();
        }

    }
}